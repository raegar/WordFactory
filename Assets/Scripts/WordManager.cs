using UnityEngine;
using System.Collections.Generic;

public class WordManager : MonoBehaviour
{
    public static WordManager Instance;
    public List<string> validDictionary; // In the future load this from a file/resource.
    public HashSet<string> discoveredWords = new HashSet<string>();

    private void Awake()
    {
        Instance = this;
        // Load a small demo dictionary; replace with an extensive list as needed.
        validDictionary = new List<string> { "HELLO", "WORLD", "UNITY", "GAME" };
    }

    public bool SubmitWord()
    {
        string word = WordRack.Instance.GetFormedWord().ToUpper();
        if (discoveredWords.Contains(word))
        {
            Debug.Log("Word already submitted.");
            return false;
        }
        if (validDictionary.Contains(word))
        {
            discoveredWords.Add(word);
            long reward = CalculateReward(word);
            GameManager.Instance.AddMoney(reward);

            // Remove or destroy used letter balls.
            foreach (var letter in WordRack.Instance.currentLetters)
            {
                Destroy(letter.gameObject);
            }
            WordRack.Instance.ClearRack();
            return true;
        }
        else
        {
            Debug.Log("Invalid word.");
            return false;
        }
    }

    long CalculateReward(string word)
    {
        // A simple exponential reward based on length.
        long baseReward = (long)Mathf.Pow(word.Length, 2) * 10;

        // Bonus for rarer letters (Q, X, Z).
        int bonus = 0;
        foreach (char c in word)
        {
            if ("QXZ".Contains(c.ToString()))
                bonus += 20;
        }
        return baseReward + bonus;
    }
}
