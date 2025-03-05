using UnityEngine;
using System.Collections.Generic;

public class WordManager : MonoBehaviour
{
    public static WordManager Instance;
    public List<string> validDictionary; // In the future load this from a file/resource.
    public HashSet<string> discoveredWords = new HashSet<string>();
    public IWordValidator WordValidator { get; set; } = new BasicWordValidator();


    private void Awake()
    {
        Instance = this;
        // Load a small demo dictionary; replace with an extensive list as needed.
        validDictionary = new List<string> { "HELLO", "WORLD", "UNITY", "GAME" };
    }

    public void SubmitWord()
    {
        string word = WordRack.Instance.GetFormedWord().ToUpper();
        if (discoveredWords.Contains(word))
        {
            Debug.Log("Word already submitted.");
            ClearRack();
            return;
        }

        if (WordValidator.IsValidWord(word))
        {
            discoveredWords.Add(word);
            long reward = CalculateReward(word);
            GameManager.Instance.AddMoney(reward);

            foreach (var letter in WordRack.Instance.currentLetters)
            {
                Destroy(letter.gameObject);
            }
            WordRack.Instance.ClearRack();
            Debug.Log("Submitted word: " + word + " | Reward: £" + reward);
        }
        else
        {
            Debug.Log("Invalid word: " + word);
            ClearRack();
        }
    }


    private void ClearRack()
    {
        // For an invalid word, unparent the letters so they can fall off.
        foreach (var letter in WordRack.Instance.currentLetters)
        {
            // Unparent so the letter is free in the scene.
            letter.transform.SetParent(null);
            Rigidbody2D rb = letter.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // Re-enable physics.
                rb.simulated = true;
                rb.isKinematic = false;

                // Apply a downward force.
                rb.AddForce(Vector2.down * 5f + Vector2.left * (Random.Range(-1f, 1f)), ForceMode2D.Impulse);

                // Apply a small random torque (spin).
                float randomTorque = Random.Range(-1f, 1f); // Adjust range as needed.
                rb.AddTorque(randomTorque, ForceMode2D.Impulse);
            }
        }


        // Finally, clear the rack's letter list.
        WordRack.Instance.ClearRack();
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
