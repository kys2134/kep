// RhythmGameStartUI.cs
using UnityEngine;
using UnityEngine.SceneManagement;

public class RhythmGameStartUI : MonoBehaviour
{
    [Tooltip("이 패널에 붙어 있습니다")]
    public GameObject panel;

    [Tooltip("로딩할 리듬 게임 씬 이름")]
    public string rhythmSceneName = "Friday";

    // 버튼 OnClick 이벤트에 연결
    public void OnClickStart()
    {
        SceneManager.LoadScene("Friday");
    }

    public void OnClickCancel()
    {
        panel.SetActive(false);
    }
}