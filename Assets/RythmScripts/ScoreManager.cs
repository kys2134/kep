// ScoreManager.cs
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    private int score;
    private int combo;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void AddHit(HitResult result)
    {
        // 예: Perfect면 +100, Good면 +50
        int points = result == HitResult.Perfect ? 100 : 50;
        score += points;
        combo = result == HitResult.Miss ? 0 : combo + 1;
        UIManager.Instance.UpdateScore(score);
        UIManager.Instance.UpdateCombo(combo);
    }
}


