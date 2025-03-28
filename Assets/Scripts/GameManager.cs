using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public long currentMoney = 0;
    public long targetMoney = 1000000000; // �1B goal

    public delegate void MoneyChanged(long newMoney);
    public event MoneyChanged OnMoneyChanged;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void AddMoney(long amount)
    {
        currentMoney += amount;
        OnMoneyChanged?.Invoke(currentMoney);
        CheckProgression();
    }

    private void CheckProgression()
    {
        if (currentMoney >= targetMoney)
        {
            // Unlock The Dictionary, trigger final animation, etc.
            Debug.Log("The Dictionary unlocked! Game completed.");
            // Additional endgame logic goes here.
        }
    }
}
