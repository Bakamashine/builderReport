using dotenv.net.Utilities;

namespace BuilderReport.Helper;

internal class Reader
{
    private string ReadOrNot(string key)
    {
        EnvReader.TryGetStringValue(key, out var value);
        if (string.IsNullOrEmpty(value))
        {
            string? tempString;
            do
            {
                Console.Write($"Enter your {key} file: ");
                tempString = Console.ReadLine();
            } while (string.IsNullOrEmpty(tempString));

            value = tempString;
        }

        return value;
    }

    public string ReadOrWrite(string key, out string _value)
    {
        var tempString = ReadOrNot(key);
        Console.WriteLine($"Value: {tempString}");
        return _value = tempString;
    }

    public string ReadOrWriteFile(string key, out string _value)
    {
        var result = ReadOrNot(key);
        if (File.Exists(result))
        {
            Console.WriteLine($"File: {result}");
            return _value = result;
        }

        throw new FileNotFoundException(result);
    }
}