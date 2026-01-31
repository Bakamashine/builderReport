using dotenv.net.Utilities;

namespace BuilderReport.Helper;

class ReaderStatic
{

    public static string ReadOrWrite(string key, out string _value)
    {
        EnvReader.TryGetStringValue(key, out string? value);
        if (string.IsNullOrEmpty(value))
        {
            string? tempString;
            do
            {
                tempString = Console.ReadLine();
            } while (string.IsNullOrEmpty(tempString));
            value = tempString;
        }
        _value = value;
        return _value;
    }

    public static string ReadOrWriteFile(string key, out string _value)
    {
        EnvReader.TryGetStringValue(key, out string? value);
        if (string.IsNullOrEmpty(value))
        {
            string? tempString;
            do
            {
                Console.Write($"Enter your {key} file: ");
                tempString = Console.ReadLine();
            } while (string.IsNullOrEmpty(tempString));
            value = tempString;
            // return _value;
        }

        if (Path.Exists(value))
        {
            _value = value;
            Console.WriteLine($"File: {_value}");
            return _value;
        }
        else throw new FileNotFoundException(value);
    }
}