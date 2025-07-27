// NoteObject.cs
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    [Header("판정 방향 (Up/Down/Left/Right)")] public string noteDirection; // Inspector에 설정된 대로

    [HideInInspector] public float spawnTime; // 스폰 시점 기록

    // 원래 Hit 메서드 (Perfect/Good/Miss 모두 여기서 처리)
    public void Hit(HitResult result)
    {
        ScoreManager.Instance.AddHit(result);
        UIManager.Instance.ShowResult(result);
      if (result != HitResult.Miss)
        {
            CharacterAnimator.Instance.PlayHit(noteDirection);
        }
        Destroy(gameObject);
    }

   
}