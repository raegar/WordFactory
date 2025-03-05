using UnityEngine;

public class VowelLetterStrategy : ILetterSelectionStrategy
{
    private readonly string[] vowels = { "A", "E", "I", "O", "U" };

    public string GetLetter()
    {
        int index = Random.Range(0, vowels.Length);
        return vowels[index];
    }
}
