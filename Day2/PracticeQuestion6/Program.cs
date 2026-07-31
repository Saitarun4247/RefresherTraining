using System;
using System.Collections.Generic;

class Configuration
{
    public Dictionary<string, string> Settings { get; set; } = new();
}

interface IConfigurationSource
{
    bool TryLoad(out Configuration configuration);
}

class EnvironmentVariableSource : IConfigurationSource
{
    public bool TryLoad(out Configuration configuration)
    {
        configuration = new Configuration();

        Console.WriteLine("Trying EnvironmentVariableSource...");

        return false;
    }
}

class JsonFileSource : IConfigurationSource
{
    public bool TryLoad(out Configuration configuration)
    {
        configuration = new Configuration();

        Console.WriteLine("Trying JsonFileSource...");

        return false;
    }
}

class DatabaseSource : IConfigurationSource
{
    public bool TryLoad(out Configuration configuration)
    {
        configuration = new Configuration();

        Console.WriteLine("Trying DatabaseSource...");

        configuration.Settings["ConnectionString"] = "Server=localhost";
        configuration.Settings["DatabaseName"] = "ApplicationDB";

        return true;
    }
}

static class ConfigurationLoader
{
    public static Configuration? Load(params IConfigurationSource[] sources)
    {
        foreach (IConfigurationSource source in sources)
        {
            if (source.TryLoad(out Configuration configuration))
            {
                Console.WriteLine(
                    $"Successfully loaded configuration from {source.GetType().Name}."
                );

                return configuration;
            }

            Console.WriteLine(
                $"{source.GetType().Name} failed. Trying next source."
            );
        }

        Console.WriteLine("Unable to load configuration from any source.");

        return null;
    }
}

class Program
{
    static void Main()
    {
        IConfigurationSource environment =
            new EnvironmentVariableSource();

        IConfigurationSource json =
            new JsonFileSource();

        IConfigurationSource database =
            new DatabaseSource();

        Configuration? configuration =
            ConfigurationLoader.Load(environment, json, database);

        if (configuration != null)
        {
            Console.WriteLine("\n----- CONFIGURATION -----");

            foreach (var setting in configuration.Settings)
            {
                Console.WriteLine($"{setting.Key}: {setting.Value}");
            }
        }
    }
}