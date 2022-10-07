using System.Text;

namespace Censor01;

public abstract class TextFile
{
    public static string Import(string path)
    {
        string str = null;
        try
        {
            using var file = new StreamReader(path);
            str = file.ReadToEnd();
        }
        catch (IOException e)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }
        return str;
    }
    public static void Export(string path, string str)
    {
        var file = new StreamWriter(path, false, Encoding.UTF8);
        file.WriteLine(str);
        file.Close();
    }
}