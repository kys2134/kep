// PlatformTrigger.cs
using UnityEngine;

public class PlatformTrigger : MonoBehaviour
{
    [Tooltip("리듬게임 시작 여부 묻는 UI 패널")]
    public GameObject uiPanel;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            uiPanel.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            uiPanel.SetActive(false);
    }
}
