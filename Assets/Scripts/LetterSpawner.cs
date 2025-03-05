using UnityEngine;

public class LetterSpawner : MonoBehaviour
{
    public float spawnInterval = 3f;
    public GameObject letterBallPrefab;

    // Instead of a hardcoded array, we inject a strategy.
    public ILetterSelectionStrategy letterSelectionStrategy;

    private float timer;

    private void Awake()
    {
        // Default strategy using the default letter pool.
        if (letterSelectionStrategy == null)
            letterSelectionStrategy = new RandomLetterStrategy(new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" });
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnLetter();
            timer = 0;
        }
    }

    private void SpawnLetter()
    {
        string letter = letterSelectionStrategy.GetLetter();
        Vector3 spawnPos = transform.position;
        spawnPos.x += Random.Range(-2f, 2f);
        GameObject letterBall = Instantiate(letterBallPrefab, spawnPos, Quaternion.identity);
        letterBall.GetComponent<LetterBall>().SetLetter(letter);
    }
}
