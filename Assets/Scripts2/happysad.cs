// MainScene용 UIManager.cs
using UnityEngine;
using TMPro;

public class happysad : MonoBehaviour
{
    public GameObject sadPanel;
    public GameObject happyPanel;
    // … 그 외 필드 …

    void Start()
    {
        // 클리어 여부 체크
        bool cleared = PlayerPrefs.GetInt("RhythmCleared", 0) == 1;
        
        sadPanel  .SetActive(!cleared);
        happyPanel.SetActive(cleared);

        //(선택) 초기화
         PlayerPrefs.DeleteKey("RhythmCleared");
    }
}