// ScoreManager.cs
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    public int currentScore  { get; private set; }
    public int currentCombo  { get; private set; }
    public int maxCombo      { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    void Start()
    {
        currentScore = 0;
        currentCombo = 0;
        maxCombo     = 0;
    }

    /// <summary>
    /// 노트를 히트했을 때 호출됩니다.
    /// 한 번에 더해지는 점수는 최대 +3으로 제한됩니다.
    /// </summary>
    public void AddHit(HitResult result)
    {
        // 1) 원래 계산할 점수
        int delta = 0;
        switch (result)
        {
            case HitResult.Perfect:
                delta = 5;   // 예: Perfect는 5점
                currentCombo++;
                break;
            case HitResult.Miss:
                delta = -1;  // Miss는 -1점
                currentCombo = 0;
                break;
        }

        // 2) 한 번에 더해지는 점수(+일 때) 최대 3점으로 제한
        if (delta > 0)
            delta = Mathf.Min(delta, 3);

        // 3) 실제 적용
        currentScore += delta;
        if (currentScore < 0)
            currentScore = 0;  // 음수 방지

        // 4) 최대 콤보 갱신
        if (currentCombo > maxCombo)
            maxCombo = currentCombo;

        Debug.Log($"AddHit: {result}, appliedDelta={delta}, newScore={currentScore}, combo={currentCombo}");
    }
}


