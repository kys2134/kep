// UIManager.cs
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // ★ 여기 타입을 UIManager 로 고칩니다.
    public static UIManager Instance { get; private set; }

    [Header("리듬게임 UI")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI comboText;
    public TextMeshProUGUI resultText;

    [Header("게임 오버 UI")]
    public GameObject restartButton;
    public GameObject returnButton;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        UpdateScore(0);
        UpdateCombo(0);
        resultText.text = "";
        restartButton.SetActive(false);
        returnButton.SetActive(false);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = $"Score: {score}";
    }

    public void UpdateCombo(int combo)
    {
        comboText.text = combo > 1 ? $"Combo {combo}" : "";
    }

    public void ShowResult(HitResult result)
    {
        resultText.text = result.ToString();
        CancelInvoke(nameof(ClearResult));
        Invoke(nameof(ClearResult), 0.7f);
    }

    void ClearResult()
    {
        resultText.text = "";
    }

    public void SetRestart()
    {
        restartButton.SetActive(true);
        returnButton.SetActive(true);
    }
}





