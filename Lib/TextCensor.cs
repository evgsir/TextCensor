namespace Censor01;

public class TextCensor
{
    public static List<string> Edit(string path)
    {
        var str = TextFile.Import(path);

        var info = RegexTextEdit.Info(str, JsonStringArr.Import("badwords.json"));
        if (info.Count > 0)
        {
            var n_str = RegexTextEdit.Replace(str, JsonStringArr.Import("badwords.json"));
            TextFile.Export(path, n_str);
        }

        return info;
    }
}