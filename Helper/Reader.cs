using dotenv.net.Utilities;

namespace BuilderReport.Helper;

class Reader
{

    private string ReadOrNot(string key)
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
        }
        return value;
    }

    public string ReadOrWrite(string key, out string _value)
    {
        string tempString = this.ReadOrNot(key);
        Console.WriteLine($"Value: {tempString}");
        return _value = tempString;
    }

    public string ReadOrWriteFile(string key, out string _value)
    {
        string result = this.ReadOrNot(key);
        if (File.Exists(result))
        {
            Console.WriteLine($"File: {result}");
            return _value = result;
        }
        else throw new FileNotFoundException(result);
    }

}