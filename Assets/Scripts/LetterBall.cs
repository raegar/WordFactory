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

    // This method is called every time the object is activated.
    private void OnEnable()
    {
        // Re-enable physics by ensuring simulation is on and resetting velocities.
        if (rb != null)
        {
            rb.simulated = true;
            rb.isKinematic = false;
            rb.gravityScale = originalGravityScale;
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }
    }

    public void SetLetter(string newLetter)
    {
        letter = newLetter;
        if (letterText != null)
            letterText.text = letter;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (rb != null)
        {
            rb.gravityScale = 0;
            rb.velocity = Vector2.zero;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 screenPosition = eventData.position;
        screenPosition.z = Camera.main.WorldToScreenPoint(transform.position).z;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        transform.position = worldPosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (WordRack.Instance != null && WordRack.Instance.IsOverRack(transform.position))
        {
            WordRack.Instance.AddLetter(this);
        }
        else if (rb != null)
        {
            rb.gravityScale = originalGravityScale;
        }
    }
}
