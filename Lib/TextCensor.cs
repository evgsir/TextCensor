namespace Censor01;

public abstract class TextCensor
{
    public static (List<string>,string) Text(string str)
    {
        var info = RegexTextEdit.Info(str, JsonStringArr.Import("badwords.json"));
        if (info.Count > 0)
        {
            str = RegexTextEdit.Replace(str, JsonStringArr.Import("badwords.json"));
        }
        return (info,str);
    }
    public static List<string> FileText (string path)
    {
        var str = TextFile.Import(path);
        var info = TextCensor.Text(str);
        if (info.Item1.Count > 0)
        {
            str = info.Item2;   
            TextFile.Export(path, str);
        }
        return info.Item1;
    }
}