using UnityEngine;

public class KillZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object is a letter ball by its tag.
        if (other.CompareTag("LetterBall"))
        {
            Debug.Log("Letter ball has fallen off the screen and will be removed.");
            Destroy(other.gameObject);
        }
    }
}
