using System;
using System.Collections;

public class Album
{
    public string Title { get; set; }
    public string Artist { get; set; }
}

public class Program
{
    public static void Main(string[] args)
    {
        ArrayList albums = new ArrayList();

        while (true)
        {
            string title = Console.ReadLine();

            if (string.Equals(title, "quit",
                StringComparison.OrdinalIgnoreCase))
            {
                break;
            }

            string artist = Console.ReadLine();

            if (IsValidInput(title) && IsValidInput(artist))
            {
                Album album = new Album
                {
                    Title = title,
                    Artist = artist
                };

                albums.Add(album);
            }
        }

        DisplayAlbums(albums);
    }

    private static bool IsValidInput(string input)
    {
        return !string.IsNullOrWhiteSpace(input);
    }

    private static void DisplayAlbums(ArrayList albums)
    {
        foreach (Album album in albums)
        {
            Console.WriteLine(
                $"Title: {album.Title}, Artist: {album.Artist}");
        }
    }
}