using UnityEngine;

public class LetterSpawner : MonoBehaviour
{
    public float spawnInterval = 3f;
    public GameObject letterBallPrefab;
    public string[] letterPool = { "A", "B", "C", "D", "E" }; // Default letters

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnLetter();
            timer = 0;
        }
    }

    void SpawnLetter()
    {
        // Pick a random letter from the pool.
        int index = Random.Range(0, letterPool.Length);
        string letter = letterPool[index];

        // Instantiate the letter ball at the spawner's position.
        Vector3 spawPos = transform.position;
        spawPos.x += Random.Range(-2f, 2f);
        GameObject letterBall = Instantiate(letterBallPrefab, spawPos, Quaternion.identity);
        letterBall.GetComponent<LetterBall>().SetLetter(letter);
    }
}
