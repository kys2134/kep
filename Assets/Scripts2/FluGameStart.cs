using UnityEngine;

public class FluGameStart : MonoBehaviour
{
    [Header("리듬게임 시작 UI 패널")]
    public GameObject uiPanel; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && uiPanel != null)
        {
            uiPanel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && uiPanel != null)
        {
            uiPanel.SetActive(false);
        }
    }
}