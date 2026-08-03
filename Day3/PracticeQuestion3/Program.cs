using System;
using System.Reflection;

//---------------------- Interface ----------------------
namespace PluginSystem
{
    public interface IPlugin
    {
        void Execute();
    }
}

//---------------------- Tax Plugin ----------------------
namespace Plugins.Tax
{
    using PluginSystem;

    public class TaxPlugin : IPlugin
    {
        internal string TaxName = "GST";

        public void Execute()
        {
            Console.WriteLine("Tax Plugin Executed");
        }
    }
}

//---------------------- Payment Plugin ----------------------
namespace Plugins.Payment
{
    using PluginSystem;

    public class PaymentPlugin : IPlugin
    {
        private string PaymentType = "UPI";

        public void Execute()
        {
            Console.WriteLine("Payment Plugin Executed");
        }
    }
}

//---------------------- Logging Plugin ----------------------
namespace Plugins.Logging
{
    using PluginSystem;

    public class LoggingPlugin : IPlugin
    {
        protected string LogFile = "log.txt";

        public void Execute()
        {
            Console.WriteLine("Logging Plugin Executed");
        }
    }
}

//---------------------- Generic Plugin Loader ----------------------
namespace Loader
{
    using PluginSystem;

    public class PluginLoader<T> where T : IPlugin, new()
    {
        public static void Load()
        {
            T plugin = new T();

            Console.WriteLine("Loading Plugin...");
            plugin.Execute();
        }
    }
}

//---------------------- Main Program ----------------------
namespace PluginApplication
{
    using PluginSystem;
    using Loader;

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Plugins Loaded From Assembly");

            Assembly assembly = Assembly.GetExecutingAssembly();

            foreach (Type type in assembly.GetTypes())
            {
                if (typeof(IPlugin).IsAssignableFrom(type)
                    && !type.IsInterface
                    && !type.IsAbstract)
                {
                    IPlugin plugin = (IPlugin)Activator.CreateInstance(type);
                    plugin.Execute();
                }
            }

            Console.WriteLine();

            Console.WriteLine("Generic Plugin Loader");

            PluginLoader<Plugins.Tax.TaxPlugin>.Load();

            PluginLoader<Plugins.Payment.PaymentPlugin>.Load();

            PluginLoader<Plugins.Logging.LoggingPlugin>.Load();
        }
    }
}