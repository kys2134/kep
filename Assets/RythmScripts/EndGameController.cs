using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
  // NoteObject, HitResult 등 정의된 네임스페이스가 있다면 추가

public class EndGameController : MonoBehaviour
{
    [Header("음악 / 판정 리듬 스크립트")]
    public AudioSource musicSource;

    [Header("게임 종료 UI")]
    public GameObject gameEndPanel;
    public Button retryButton;
    public Button returnButton;

    private bool hasEnded = false;

    void Start()
    {
        if (gameEndPanel != null)
            gameEndPanel.SetActive(false);

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

        if (musicSource != null && !musicSource.isPlaying)
        {
            // 노래가 끝나면 남은 노트 전부 제거
            ClearAllRemainingNotes();

            ShowGameEndUI();
            hasEnded = true;
        }
    }

    void ShowGameEndUI()
    {
        if (gameEndPanel != null)
            gameEndPanel.SetActive(true);
    }

    /// <summary>
    /// 씬에 남아있는 모든 NoteObject를 찾아서 파괴합니다.
    /// </summary>
    private void ClearAllRemainingNotes()
    {
        // NoteObject 스크립트가 붙은 오브젝트를 모두 찾음
        NoteObject[] notes = FindObjectsOfType<NoteObject>();

        int count = notes.Length;
        foreach (var note in notes)
        {
            Destroy(note.gameObject);
        }

        Debug.Log($"남은 노트 {count}개 삭제 완료");
    }
}



