using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // 싱글톤 인스턴
    private FlyUIManager flyUI;
    public static GameManager Instance { get; private set; }

    // FlyGame 전용 UI 매니저
    private FlyUIManager uiManager;

    // 현재 점수
    private int currentScore = 0;

    private void Awake()
    {
        // 싱글톤 중복 방지
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        // 씬 전환 시 파괴되지 않도록
        DontDestroyOnLoad(gameObject);

        // 초기 씬(대개 MainScene)에서 FlyUIManager가 있으면 찾아두기
        uiManager = FindObjectOfType<FlyUIManager>();
        if (uiManager == null)
            Debug.LogWarning($"[GameManager] FlyUIManager not found in scene '{SceneManager.GetActiveScene().name}'");
    }

    private void OnEnable()
    {
        // 씬이 새로 로드될 때마다 호출
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // 씬 로드 직후에 FlyUIManager를 찾아 재할당
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "FlyGame")
        {
            flyUI = FindObjectOfType<FlyUIManager>();
            if (flyUI == null)
                Debug.LogError($"[GameManager] FlyUIManager를 찾을 수 없습니다: '{scene.name}' 씬");
            else
                flyUI.UpdateScore(currentScore);
        }
    }

    private void Start()
    {
        // 게임 시작 시 점수 초기화
        currentScore = 0;
        uiManager?.UpdateScore(0);
    }

    /// <summary>
    /// 노트 히트 등으로 점수를 추가할 때 호출
    /// </summary>
    public void AddScore(int score)
    {
        currentScore += score;
        Debug.Log($"[GameManager] Score: {currentScore}");
        uiManager?.UpdateScore(currentScore);
    }

    /// <summary>
    /// 리듬게임 종료 시 호출
    /// </summary>
    public void GameOver()
    {
        Debug.Log("[GameManager] Game Over");
        uiManager?.SetRestart();
        FindObjectOfType<GameEndUI>()?.ShowGameOverUI();
    }

    /// <summary>
    /// 재시작 버튼에서 호출
    /// </summary>
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        currentScore = 0;
    }
}

