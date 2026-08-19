using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

class TravelSummary
{
    public long lastEntryStation;
    public long lastExitStation;
    public long lastEntryTime;
    public long lastExitTime;
    public double totalFarePaid;
    public int totalTrips;
    public double averageFarePerTrip;
}

class Commuter
{
    public int cardNumber;
    public string commuterName;
    public string commuterType;
    public TravelSummary travelSummary;
}

class Station
{
    public int stationId;
    public string stationName;
    public int zone;
    public double latitude;
    public double longitude;
}

interface MetroOperations
{
    void issueCard(int cardNumber, string commuterName, string commuterType);

    bool tapIn(int cardNumber, int stationId, long epochTime);

    bool tapOut(int cardNumber, int stationId, long epochTime);

    Commuter getCommuterInfo(int cardNumber);

    List<double> fareHistory(int cardNumber);

    Dictionary<string, double> getZoneWiseRevenue(
        long startTime, long endTime);

    List<string> getFrequentRoute(int cardNumber);

    double getDailyPassSavings(int cardNumber, long date);
}

class Journey
{
    public int entryStation;
    public long entryTime;

    public Journey(int entryStation, long entryTime)
    {
        this.entryStation = entryStation;
        this.entryTime = entryTime;
    }
}

class TripRecord
{
    public int cardNumber;
    public int entryStation;
    public int exitStation;
    public long entryTime;
    public long exitTime;
    public double fare;

    public TripRecord(
        int cardNumber,
        int entryStation,
        int exitStation,
        long entryTime,
        long exitTime,
        double fare)
    {
        this.cardNumber = cardNumber;
        this.entryStation = entryStation;
        this.exitStation = exitStation;
        this.entryTime = entryTime;
        this.exitTime = exitTime;
        this.fare = fare;
    }
}

class MetroCardManager : MetroOperations
{
    private Dictionary<int, Commuter> commuters;
    private Dictionary<int, Station> stations;
    private Dictionary<int, Journey> activeJourneys;

    private List<TripRecord> trips;

    private double baseFare;
    private double perKmRate;
    private double maxDailyCap;

    public MetroCardManager(
        List<Station> stationList,
        double baseFare,
        double perKmRate,
        double maxDailyCap)
    {
        commuters = new Dictionary<int, Commuter>();
        stations = new Dictionary<int, Station>();
        activeJourneys = new Dictionary<int, Journey>();
        trips = new List<TripRecord>();

        this.baseFare = baseFare;
        this.perKmRate = perKmRate;
        this.maxDailyCap = maxDailyCap;

        foreach (Station station in stationList)
        {
            stations[station.stationId] = station;
        }
    }

    // --------------------------------------------------
    // 1. ISSUE CARD
    // --------------------------------------------------

    public void issueCard(
        int cardNumber,
        string commuterName,
        string commuterType)
    {
        if (commuters.ContainsKey(cardNumber))
            return;

        Commuter commuter = new Commuter();

        commuter.cardNumber = cardNumber;
        commuter.commuterName = commuterName;
        commuter.commuterType = commuterType;

        commuter.travelSummary = new TravelSummary();

        commuter.travelSummary.lastEntryStation = 0;
        commuter.travelSummary.lastExitStation = 0;
        commuter.travelSummary.lastEntryTime = 0;
        commuter.travelSummary.lastExitTime = 0;
        commuter.travelSummary.totalFarePaid = 0;
        commuter.travelSummary.totalTrips = 0;
        commuter.travelSummary.averageFarePerTrip = 0;

        commuters.Add(cardNumber, commuter);
    }

    // --------------------------------------------------
    // 2. TAP IN
    // --------------------------------------------------

    public bool tapIn(
        int cardNumber,
        int stationId,
        long epochTime)
    {
        // Card must exist
        if (!commuters.ContainsKey(cardNumber))
            return false;

        // Station must exist
        if (!stations.ContainsKey(stationId))
            return false;

        // Already has active journey
        if (activeJourneys.ContainsKey(cardNumber))
            return false;

        Commuter commuter = commuters[cardNumber];

        commuter.travelSummary.lastEntryStation = stationId;
        commuter.travelSummary.lastEntryTime = epochTime;

        activeJourneys.Add(
            cardNumber,
            new Journey(stationId, epochTime));

        return true;
    }

    // --------------------------------------------------
    // 3. TAP OUT
    // --------------------------------------------------

    public bool tapOut(
        int cardNumber,
        int stationId,
        long epochTime)
    {
        // Card must exist
        if (!commuters.ContainsKey(cardNumber))
            return false;

        // Must have active journey
        if (!activeJourneys.ContainsKey(cardNumber))
            return false;

        // Exit station must exist
        if (!stations.ContainsKey(stationId))
            return false;

        Journey journey = activeJourneys[cardNumber];

        // Exit time must be after entry
        if (epochTime <= journey.entryTime)
            return false;

        // Entry and exit stations must differ
        if (journey.entryStation == stationId)
            return false;

        Station entryStation = stations[journey.entryStation];
        Station exitStation = stations[stationId];

        // Calculate distance
        double distance =
            calculateDistance(entryStation, exitStation);

        // Duration in minutes
        double duration =
            (epochTime - journey.entryTime) / (1000.0 * 60.0);

        double fare;

        // More than 2 hours
        if (duration > 120)
        {
            fare = baseFare * 3;
        }
        else
        {
            fare = baseFare + (distance * perKmRate);
        }

        // Apply commuter discount
        Commuter commuter = commuters[cardNumber];

        double discount = GetDiscount(
            commuter.commuterType);

        fare = fare * (1 - discount);

        // Apply daily cap
        long date = GetDateKey(journey.entryTime);

        double alreadyPaid =
            GetDailyFare(cardNumber, date);

        double remaining =
            Math.Max(0, maxDailyCap - alreadyPaid);

        if (alreadyPaid >= maxDailyCap)
        {
            fare = 0;
        }
        else if (fare > remaining)
        {
            fare = remaining;
        }

        // Update summary
        commuter.travelSummary.lastExitStation = stationId;
        commuter.travelSummary.lastExitTime = epochTime;

        commuter.travelSummary.totalFarePaid += fare;
        commuter.travelSummary.totalTrips++;

        commuter.travelSummary.averageFarePerTrip =
            commuter.travelSummary.totalFarePaid /
            commuter.travelSummary.totalTrips;

        // Store completed trip
        trips.Add(new TripRecord(
            cardNumber,
            journey.entryStation,
            stationId,
            journey.entryTime,
            epochTime,
            fare));

        // End journey
        activeJourneys.Remove(cardNumber);

        return true;
    }

    // --------------------------------------------------
    // 4. COMMUTER INFO
    // --------------------------------------------------

    public Commuter getCommuterInfo(int cardNumber)
    {
        if (commuters.ContainsKey(cardNumber))
            return commuters[cardNumber];

        return null;
    }

    // --------------------------------------------------
    // 5. FARE HISTORY
    // --------------------------------------------------

    public List<double> fareHistory(int cardNumber)
    {
        if (!commuters.ContainsKey(cardNumber))
            return new List<double>();

        return trips
            .Where(t => t.cardNumber == cardNumber)
            .OrderByDescending(t => t.exitTime)
            .Take(5)
            .Select(t => t.fare)
            .OrderByDescending(f => f)
            .ToList();
    }

    // --------------------------------------------------
    // 6. ZONE-WISE REVENUE
    // --------------------------------------------------

    public Dictionary<string, double> getZoneWiseRevenue(
        long startTime,
        long endTime)
    {
        Dictionary<string, double> revenue =
            new Dictionary<string, double>();

        foreach (TripRecord trip in trips)
        {
            if (trip.exitTime < startTime ||
                trip.exitTime > endTime)
                continue;

            Station entry = stations[trip.entryStation];
            Station exit = stations[trip.exitStation];

            string key =
                "Zone" + entry.zone +
                "-Zone" + exit.zone;

            if (!revenue.ContainsKey(key))
                revenue[key] = 0;

            revenue[key] += trip.fare;
        }

        return revenue
            .Where(x => x.Value > 0)
            .OrderByDescending(x => x.Value)
            .ToDictionary(x => x.Key, x => x.Value);
    }

    // --------------------------------------------------
    // 7. FREQUENT ROUTE
    // --------------------------------------------------

    public List<string> getFrequentRoute(int cardNumber)
    {
        if (!commuters.ContainsKey(cardNumber))
            return new List<string>();

        Dictionary<string, int> routeCount =
            new Dictionary<string, int>();

        foreach (TripRecord trip in trips)
        {
            if (trip.cardNumber != cardNumber)
                continue;

            string route =
                stations[trip.entryStation].stationName +
                " to " +
                stations[trip.exitStation].stationName;

            if (!routeCount.ContainsKey(route))
                routeCount[route] = 0;

            routeCount[route]++;
        }

        return routeCount
            .OrderByDescending(x => x.Value)
            .ThenBy(x => x.Key)
            .Take(3)
            .Select(x => x.Key)
            .ToList();
    }

    // --------------------------------------------------
    // 8. DAILY PASS SAVINGS
    // --------------------------------------------------

    public double getDailyPassSavings(
        int cardNumber,
        long date)
    {
        if (!commuters.ContainsKey(cardNumber))
            return 0;

        double actualFare =
            GetDailyFare(cardNumber, date);

        if (actualFare == 0)
            return 0;

        double dailyPassCost =
            maxDailyCap * 0.8;

        double savings =
            actualFare - dailyPassCost;

        return Math.Max(0, savings);
    }

    // --------------------------------------------------
    // HELPER METHODS
    // --------------------------------------------------

    private double GetDiscount(string type)
    {
        switch (type)
        {
            case "SENIOR":
                return 0.50;

            case "STUDENT":
                return 0.25;

            case "CHILD":
                return 0.75;

            case "ADULT":
            default:
                return 0;
        }
    }

    private double GetDailyFare(
        int cardNumber,
        long date)
    {
        double total = 0;

        foreach (TripRecord trip in trips)
        {
            if (trip.cardNumber == cardNumber &&
                GetDateKey(trip.entryTime) == date)
            {
                total += trip.fare;
            }
        }

        return total;
    }

    private long GetDateKey(long epochTime)
    {
        DateTime date =
            DateTimeOffset
                .FromUnixTimeMilliseconds(epochTime)
                .DateTime;

        return long.Parse(date.ToString("yyyyMMdd"));
    }

    private double calculateDistance(
        Station s1,
        Station s2)
    {
        double lat1 =
            Math.PI * s1.latitude / 180.0;

        double lon1 =
            Math.PI * s1.longitude / 180.0;

        double lat2 =
            Math.PI * s2.latitude / 180.0;

        double lon2 =
            Math.PI * s2.longitude / 180.0;

        double dlat = lat2 - lat1;
        double dlon = lon2 - lon1;

        double a =
            Math.Pow(Math.Sin(dlat / 2), 2) +
            Math.Cos(lat1) *
            Math.Cos(lat2) *
            Math.Pow(Math.Sin(dlon / 2), 2);

        double c =
            2 * Math.Asin(Math.Sqrt(a));

        double r = 6371;

        return r * c;
    }
}