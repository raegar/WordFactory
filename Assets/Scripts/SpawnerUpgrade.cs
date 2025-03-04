using UnityEngine;

public class SpawnerUpgrade : MonoBehaviour
{
    public enum SpawnerType
    {
        Basic,
        Common,
        Vowel,
        Consonant,
        Digraph,
        Trigraph,
        Balanced,
        QXZ,
        Suffix,
        Prefix,
        Custom,
        Wildcard,
        Smart,
        Mega,
        WordFragment,
        AutoSolver
    }

    public SpawnerType spawnerType;
    public long cost;
    public float spawnRateModifier = 1.2f; // Example modifier.

    public void UpgradeSpawner(LetterSpawner spawner)
    {
        spawner.spawnInterval /= spawnRateModifier;
        // Adjust letter pool based on spawner type.
        switch (spawnerType)
        {
            case SpawnerType.Vowel:
                spawner.letterPool = new string[] { "A", "E", "I", "O", "U" };
                break;
                // Add additional cases for each spawner type.
        }
    }
}
