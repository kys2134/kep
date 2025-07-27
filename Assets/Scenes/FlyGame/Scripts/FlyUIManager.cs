using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class FlyUIManager : MonoBehaviour
{
    [Header("라이브 게임 UI")]
    public TextMeshProUGUI scoreText;

    [Header("게임 오버 버튼")]
    public Button retryButton;     // 재시작 전용
    public Button returnButton;    // 마을로 돌아가기 전용

    void Awake()
    {
        // 씬 로드 콜백 등록
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void Start()
    {
        // 슬롯 누락 체크
        if (scoreText    == null) Debug.LogError("FlyUIManager ▶ scoreText 할당 안됨");
        if (retryButton  == null) Debug.LogError("FlyUIManager ▶ retryButton 할당 안됨");
        if (returnButton == null) Debug.LogError("FlyUIManager ▶ returnButton 할당 안됨");

        // 버튼 리스너를 Start에도 한 번 등록해두면 씬 재로딩 없이 테스트할 때 편합니다.
        BindButtons();
    }

    // 씬이 로드될 때마다 실행
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name != "FlyGame") 
            return;

        // 씬 로드 직후엔 무조건 숨기고,
        retryButton .gameObject.SetActive(false);
        returnButton.gameObject.SetActive(false);

        // 그리고 리스너도 재등록
        BindButtons();

        // 점수 초기화
        if (scoreText != null)
            scoreText.text = "0";
    }

    void BindButtons()
    {
        // Retry 버튼 → 현재 씬 재시작
        retryButton.onClick.RemoveAllListeners();
        retryButton.onClick.AddListener(() =>
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        });

        // Return 버튼 → MainScene 로드
        returnButton.onClick.RemoveAllListeners();
        returnButton.onClick.AddListener(() =>
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("MainScene");
        });
    }

    /// <summary>
    /// GameManager.GameOver()에서 호출
    /// </summary>
    public void SetRestart()
    {
        retryButton .gameObject.SetActive(true);
        returnButton.gameObject.SetActive(true);
    }

    /// <summary>
    /// 점수 갱신
    /// </summary>
    public void UpdateScore(int score)
    {
        if (scoreText != null)
            scoreText.text = score.ToString();
    }

}





