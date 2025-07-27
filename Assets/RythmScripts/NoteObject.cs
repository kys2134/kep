// NoteObject.cs
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    [Header("판정 방향 (Up/Down/Left/Right)")]
    public string noteDirection;
    private bool _hasBeenHit = false;
    [HideInInspector]
    public float spawnTime;

    public void Hit(HitResult result)
    {
        if (_hasBeenHit) 
            return;                // 이미 처리했으면 무시
        _hasBeenHit = true;
        
        // 1) 스코어/콤보 계산
        ScoreManager.Instance.AddHit(result);

        // 2) 실시간 UI 갱신
        UIManager.Instance.UpdateScore(ScoreManager.Instance.currentScore);
        UIManager.Instance.UpdateCombo(ScoreManager.Instance.currentCombo);

        // 3) 히트 애니메이션
        if (result != HitResult.Miss)
            CharacterAnimator.Instance.PlayHit(noteDirection);

        // 4) 노트 제거
        Destroy(gameObject);
    }
}