using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public TextMeshProUGUI moneyText;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        GameManager.Instance.OnMoneyChanged += UpdateMoneyDisplay;
        UpdateMoneyDisplay(GameManager.Instance.currentMoney);
    }

    public void UpdateMoneyDisplay(long currentMoney)
    {
        moneyText.text = "£" + currentMoney.ToString("N0");
    }
}
