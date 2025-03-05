using UnityEngine;
using System.Collections.Generic;

public class WordRack : MonoBehaviour
{
    public static WordRack Instance;
    // Reference to the BoxCollider2D that defines the rack area.
    public BoxCollider2D rackCollider;
    public List<LetterBall> currentLetters = new List<LetterBall>();

    private void Awake()
    {
        Instance = this;
        // If not assigned via Inspector, try to get the BoxCollider2D from the same GameObject.
        if (rackCollider == null)
            rackCollider = GetComponent<BoxCollider2D>();
    }

    // Check if a world space position is within the rack's collider bounds.
    public bool IsOverRack(Vector3 worldPos)
    {
        if (rackCollider != null)
        {
            return rackCollider.bounds.Contains(worldPos);
        }
        return false;
    }

    // Called to add a letter ball to the rack.
    public void AddLetter(LetterBall letterBall)
    {
        currentLetters.Add(letterBall);
        UpdateRackLayout();
    }

    // Optionally reposition the letter balls inside the rack.
    private void UpdateRackLayout()
    {
        // Example: align balls horizontally with a fixed spacing.
        float spacing = 1.0f; // Adjust as needed.
        Vector3 startPos = transform.position - new Vector3((currentLetters.Count - 1) * spacing * 0.5f, 0, 0);
        for (int i = 0; i < currentLetters.Count; i++)
        {
            // Position each letter ball.
            currentLetters[i].transform.position = startPos + new Vector3(i * spacing, 0, 0);
            // Disable physics so it doesn't move anymore.
            Rigidbody2D rb = currentLetters[i].GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.simulated = false;
                // Alternatively, you can set rb.isKinematic = true;
            }
        }
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
