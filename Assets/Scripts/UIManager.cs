using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
        UpdateMoneyDisplay(0);
    }

    public void UpdateMoneyDisplay(long currentMoney)
    {
        moneyText.text = "£" + currentMoney.ToString("N0");
    }
}
