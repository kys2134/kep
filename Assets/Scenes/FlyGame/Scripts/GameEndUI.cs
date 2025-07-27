using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEndUI : MonoBehaviour
{
    public GameObject returnButton;
    public void ReturnToVillage()
    {
        SceneManager.LoadScene("MainScene");  
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ShowGameOverUI()
    {
     returnButton.SetActive(true);
    }
}