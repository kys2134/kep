using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private FlyUIManager uiManager;
    private int currentScore = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        // 씬 로드 콜백 등록
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        // 씬 로드 콜백 해제
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // 씬이 로드될 때마다 호출됩니다.
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "FlyGame")
        {
            // FlyGame 씬일 때만 UIManager를 찾아 연결
            uiManager = FindObjectOfType<FlyUIManager>();
            if (uiManager == null)
                Debug.LogError("GameManager ▶ FlyUIManager를 찾을 수 없습니다!");
            else
                uiManager.UpdateScore(0);  // 씬 로드 직후 점수 초기화
        }
        else
        {
            uiManager = null;
        }
    }

    /// <summary>
    /// 외부(플레이어 충돌 등)에서 호출: 점수를 추가합니다.
    /// </summary>
    public void AddScore(int amount)
    {
        // 내부 점수 누적
        currentScore += amount;

        // UI에 반영
        if (uiManager != null)
            uiManager.UpdateScore(currentScore);
    }

    /// <summary>
    /// 외부(플레이어 사망 등)에서 호출: 게임 오버 처리
    /// </summary>
    public void GameOver()
    {
        Debug.Log("Game Over");
        if (uiManager != null)
            uiManager.SetRestart();
    }

    /// <summary>
    /// Retry 버튼이나, 스페이스/클릭 리스폰 로직에서 호출: 씬을 재시작합니다.
    /// </summary>
    public void RestartGame()
    {
        // 점수 초기화
        currentScore = 0;

        // 현재 씬 이름으로 다시 로드
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}



