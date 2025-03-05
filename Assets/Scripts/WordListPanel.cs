using UnityEngine;
using TMPro;
using System.Linq;

public class WordListPanel : MonoBehaviour
{
    // Reference to the TextMeshProUGUI component that displays the word list.
    public TextMeshProUGUI wordListText;

    private void Start()
    {
        UpdateWordList();
        WordManager.Instance.OnWordSubmitted += UpdateWordList;
    }


    public void UpdateWordList()
    {
        // Get the submitted words from WordManager, convert to a list, and sort them alphabetically.
        var sortedWords = WordManager.Instance.discoveredWords.ToList();
        sortedWords.Sort();

        // Join the words with a newline separator.
        wordListText.text = string.Join("\n", sortedWords);
    }

    // Optionally, unsubscribe from events when destroyed.
    private void OnDestroy()
    {
        // if (WordManager.Instance != null)
        //     WordManager.Instance.OnWordSubmitted -= UpdateWordList;
    }
}
