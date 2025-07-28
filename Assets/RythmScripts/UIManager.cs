using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    // 싱글톤
    public static UIManager Instance { get; private set; }

    [Header("▶ In‑Game UI")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI comboText;

    [Header("▶ Game Over UI")]
    public GameObject retryButton;
    public GameObject returnButton;

    [Header("▶ Final Results UI")]
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI maxComboText;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
       
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void Start()
    {
        // Play 모드로 바로 시작했을 때도 초기 상태를 맞추기 위해 호출
      
    }

    // 씬 전환 직후마다 불립니다
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        
        bool isFriday = scene.name == "Friday";

        // 리듬게임 씬일 때만 실시간 점수/콤보 보이기
        scoreText   .gameObject.SetActive(isFriday);
        comboText   .gameObject.SetActive(isFriday);

        // 게임오버·결과 UI는 항상 숨김으로 초기화
        retryButton     .SetActive(false);
        returnButton    .SetActive(false);
        finalScoreText  .gameObject.SetActive(false);
        maxComboText    .gameObject.SetActive(false);
    }

    // 호출 시 점수 텍스트 갱신
    public void UpdateScore(int score)
    {
        if (scoreText.gameObject.activeSelf)
            scoreText.text = "Score :"+score.ToString();
    }

    // 호출 시 콤보 텍스트 갱신
    public void UpdateCombo(int combo)
    {
        if (comboText.gameObject.activeSelf)
            comboText.text ="Combo :"+combo.ToString();
    }

    // 게임오버 시 재시작·리턴 버튼 보이기
    public void SetRestart()
    {
        retryButton  .SetActive(true);
        returnButton .SetActive(true);
    }

    // 최종 결과 표시
    public void ShowResults(int finalScore, int maxCombo)
    {
        finalScoreText.text = $"Score: {finalScore}";
        maxComboText  .text = $"Max Combo: {maxCombo}";
        finalScoreText.gameObject.SetActive(true);
        maxComboText  .gameObject.SetActive(true);
    }

    // 마을로 돌아가기 버튼
    public void ReturnToVillage()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainScene");
    }
}








