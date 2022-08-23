using System.Text;

namespace Censor01;

public class TextFile
{
    public static string Import(string path)
    {
        var file = new StreamReader(path);
        var str = file.ReadToEnd();
        file.Close();
        return str;
    }
    public static void Export(string path, string str)
    {
        var file = new StreamWriter(path, false, Encoding.UTF8);
        file.WriteLine(str);
        file.Close();
    }
}