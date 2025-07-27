using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStartUI : MonoBehaviour
{
    public string miniGameSceneName = "FlyGame"; // 이동할 씬 이름

    public void OnClickStartGame()
    {
        SceneManager.LoadScene("FlyGame");
    }

    public void OnClickCancel()
    {
        gameObject.SetActive(false); // UI 끄기
    }
}
