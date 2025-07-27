using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class FlyUIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI restartText;
    
    public Button returnButton;
    // Start is called before the first frame update
    void Start()
    {
        if (restartText == null)
            Debug.LogError("restartText is null");
        if (scoreText == null)
            Debug.LogError("scoreText is null");
        restartText.gameObject.SetActive(false);
        returnButton.gameObject.SetActive(false);
       
    }

    public void SetRestart()
    {
        restartText.gameObject.SetActive(true);
        returnButton.gameObject.SetActive(true);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void ReturnText()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainScene");
    }

}
