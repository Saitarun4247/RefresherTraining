using System;

class Program
{
    static string FormatLogMessage(string template, params object[] arguments)
    {
        string ProcessArguments()
        {
            Span<char> buffer = stackalloc char[1024];
            int position = 0;

            for (int i = 0; i < template.Length; i++)
            {
                if (template[i] == '{')
                {
                    int end = template.IndexOf('}', i);

                    if (end != -1)
                    {
                        string placeholder = template.Substring(i + 1, end - i - 1);

                        if (int.TryParse(placeholder, out int index) &&
                            index >= 0 &&
                            index < arguments.Length)
                        {
                            string value;

                            if (arguments[index] is DateTime dateTime)
                            {
                                value = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
                            }
                            else
                            {
                                value = arguments[index]?.ToString() ?? "";
                            }

                            foreach (char ch in value)
                            {
                                if (position >= buffer.Length)
                                {
                                    return "Log message is too long.";
                                }

                                buffer[position++] = ch;
                            }

                            i = end;
                            continue;
                        }
                    }
                }

                if (position >= buffer.Length)
                {
                    return "Log message is too long.";
                }

                buffer[position++] = template[i];
            }

            return new string(buffer[..position]);
        }

        return ProcessArguments();
    }

    static void Main()
    {
        string template = "User {0} logged in from {1} at {2}";

        string message = FormatLogMessage(
            template,
            "JohnDoe",
            "192.168.1.1",
            DateTime.Now
        );

        Console.WriteLine(message);
    }
}