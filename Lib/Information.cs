namespace Censor01;

public class Information
{
    public Information(List<string> info, int countChangeLetters)
    {
        findWords = info;
        countChangedLetters = countChangeLetters;
    }
    public List<string> findWords { get; init; }
    public int countChangedLetters { get; init; }
}