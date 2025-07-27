using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    // ─────────────────────────────────────────────
    // 싱글톤 인스턴스
    public static UIManager Instance { get; private set; }
    // ─────────────────────────────────────────────

    [Header("▶ In-Game UI")]
    public TextMeshProUGUI scoreText;      // 실시간 점수
    public TextMeshProUGUI comboText;      // 실시간 콤보

    [Header("▶ Game Over UI")]
    public GameObject retryButton;    // "클릭하여 재시작"
    public GameObject returnButton;        // "마을로 돌아가기"

    [Header("▶ Final Results UI")]
    public TextMeshProUGUI finalScoreText; // 최종 점수
    public TextMeshProUGUI maxComboText;   // 최대 콤보
    // ─────────────────────────────────────────────

    void Awake()
    {
        // 싱글톤 초기화
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        // In-Game UI 초기화
        scoreText.text = "0";
        comboText.text = "0";

        // Game Over UI & Final Results UI 처음엔 모두 숨김
        retryButton.SetActive(false);
        returnButton .SetActive(false);
        finalScoreText .gameObject.SetActive(false);
        maxComboText   .gameObject.SetActive(false);
    }

    // ▶ 라이브러리 / 게임 진행 중 호출
    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString("Score : "+score);
    }

    public void UpdateCombo(int combo)
    {
        comboText.text = combo.ToString("Combo :"+combo);
    }

    // ▶ 플레이어 사망 또는 게임 종료 시 호출
    public void SetRestart()
    {
        retryButton.SetActive(true);
        returnButton.SetActive(true);
        
    }

    // ▶ 게임 종료 후 결과 표시
    //    finalScore: 최종 획득 점수
    //    maxCombo:   플레이 도중 달성한 최대 콤보
    public void ShowResults(int finalScore, int maxCombo)
    {
        // 텍스트 갱신
        finalScoreText.text = $"Score: {finalScore}";
        maxComboText  .text = $"Max Combo: {maxCombo}";

        // 결과 UI 활성화
        finalScoreText.gameObject.SetActive(true);
        maxComboText  .gameObject.SetActive(true);
    }

    // ▶ 버튼 이벤트에 연결
    public void ReturnToVillage()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainScene");
    }
}







