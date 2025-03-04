using UnityEngine;
using System.Collections.Generic;

public class WordRack : MonoBehaviour
{
    public static WordRack Instance;
    public List<LetterBall> currentLetters = new List<LetterBall>();

    private void Awake()
    {
        Instance = this;
    }

    public bool IsOverRack(Vector3 position)
    {
        // Implement logic to determine if a given screen/world position is over the rack area.
        // This could involve using RectTransformUtility or colliders.
        return true; // Replace with proper bounds checking.
    }

    public void AddLetter(LetterBall letterBall)
    {
        currentLetters.Add(letterBall);
        // Snap the letterBall to a specific slot on the rack if needed.
        // We may also want to disable further dragging.
    }

    public void ClearRack()
    {
        currentLetters.Clear();
    }

    public string GetFormedWord()
    {
        string word = "";
        foreach (var letter in currentLetters)
        {
            word += letter.letter;
        }
        return word;
    }
}
