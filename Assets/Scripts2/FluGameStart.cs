using UnityEngine;

public class FluGameStart : MonoBehaviour
{
    public GameObject uiPanel; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            uiPanel.SetActive(true); 
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            uiPanel.SetActive(false); 
        }
    }
}