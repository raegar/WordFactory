using UnityEngine;

public class RandomLetterStrategy : ILetterSelectionStrategy
{
    private readonly string[] _letterPool;
    public RandomLetterStrategy(string[] letterPool)
    {
        _letterPool = letterPool;
    }

    public string GetLetter()
    {
        int index = Random.Range(0, _letterPool.Length);
        return _letterPool[index];
    }
}
