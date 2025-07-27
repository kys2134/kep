using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGameController : MonoBehaviour
{
    [Header("음악 재생 소스")]
    public AudioSource musicSource;

    [Header("게임 종료 UI")]
    public GameObject gameEndPanel;  // Panel 전체
    public Button retryButton;       // Retry 버튼
    public Button returnButton;      // Return 버튼

    [Header("메인씬 감정 토글")]
    public GameObject sadPanel;      // Canvas 안의 Sad 오브젝트
    public GameObject happyPanel;    // Canvas 안의 Happy 오브젝트

    private bool hasEnded = false;

    void Start()
    {
        // 1) 시작할 때 패널 숨기기
        if (gameEndPanel != null)
            gameEndPanel.SetActive(false);

        // 2) 감정 패널 초기 상태: Sad 켜고 Happy 끄기
        if (sadPanel   != null) sadPanel.SetActive(true);
        if (happyPanel != null) happyPanel.SetActive(false);

        // 3) 버튼 리스너 설정
        retryButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        });
        returnButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("MainScene");
        });
    }

    void Update()
    {
        if (hasEnded) return;

        // 4) 음악이 끝났으면 한 번만 EndGame 실행
        if (musicSource != null && !musicSource.isPlaying)
        {
            hasEnded = true;
            EndGame();
        }
    }

    private void EndGame()
    {
        PlayerPrefs.SetInt("RhythmCleared", 1);
        PlayerPrefs.Save();
        // 5) 남은 노트 모두 정리
        ClearAllRemainingNotes();

        // 6) 게임 종료 패널 활성화
        if (gameEndPanel != null)
            gameEndPanel.SetActive(true);

        // 7) Sad → 꺼기, Happy → 켜기
        if (sadPanel   != null) sadPanel.SetActive(false);
        if (happyPanel != null) happyPanel.SetActive(true);

        // 8) UIManager로 재시작/리턴 버튼 켜기
        UIManager.Instance.SetRestart();

        // 9) 최종 스코어 · 최대 콤보 보여주기
        int finalScore = ScoreManager.Instance.currentScore;
        int maxCombo   = ScoreManager.Instance.maxCombo;
        UIManager.Instance.ShowResults(finalScore, maxCombo);

        Debug.Log($"[EndGame] Score={finalScore}, MaxCombo={maxCombo}");
    }

    /// <summary>
    /// 씬에 남아있는 모든 NoteObject를 찾아서 파괴합니다.
    /// </summary>
    private void ClearAllRemainingNotes()
    {
        var notes = FindObjectsOfType<NoteObject>();
        int count = notes.Length;
        for (int i = 0; i < notes.Length; i++)
        {
            Destroy(notes[i].gameObject);
        }
        Debug.Log($"남은 노트 {count}개 삭제 완료");
    }
}

