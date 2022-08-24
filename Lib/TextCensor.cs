namespace Censor01;

public abstract class TextCensor
{
    public static (Information Info, string CensString) Text (string str)
    {
        var info = RegexTextEdit.Info(str, JsonStringArr.Import("badwords.json"));
        if (info.findWords.Count > 0)
        {
            str = RegexTextEdit.Replace(str, JsonStringArr.Import("badwords.json"));
        }
        return (info, str);
    }
    public static Information FileText (string path)
    {
        var str = TextFile.Import(path);
        var info = TextCensor.Text(str);
        if (info.Info.findWords.Count > 0)
        {
            str = info.CensString;   
            TextFile.Export(path, str);
        }
        return info.Info;
    }
}