using System.Collections.Generic;

public class BasicWordValidator : IWordValidator
{
    private readonly List<string> _dictionary = new List<string> { "HELLO", "WORLD", "UNITY", "GAME" };

    public bool IsValidWord(string word)
    {
        return _dictionary.Contains(word);
    }
}
