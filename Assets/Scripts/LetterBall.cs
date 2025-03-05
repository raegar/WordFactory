using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class LetterBall : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public string letter;
    public TextMeshProUGUI letterText;

    private Rigidbody2D rb;
    private float originalGravityScale;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb != null)
            originalGravityScale = rb.gravityScale;
    }

    public void SetLetter(string newLetter)
    {
        letter = newLetter;
        if (letterText != null)
            letterText.text = letter;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Disable gravity while dragging.
        if (rb != null)
        {
            rb.gravityScale = 0;
            rb.velocity = Vector2.zero;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Convert screen position to world position.
        Vector3 screenPosition = eventData.position;
        screenPosition.z = Camera.main.WorldToScreenPoint(transform.position).z;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        transform.position = worldPosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Check if the letter ball is over the rack based on its world position.
        if (WordRack.Instance != null && WordRack.Instance.IsOverRack(transform.position))
        {
            WordRack.Instance.AddLetter(this);
        }
        else
        {
            // Re-enable gravity if not dropped on the rack.
            if (rb != null)
                rb.gravityScale = originalGravityScale;
        }
    }
}
