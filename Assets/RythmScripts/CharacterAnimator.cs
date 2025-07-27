// Assets/RythmScripts/CharacterAnimator.cs
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    public static CharacterAnimator Instance { get; private set; }
    Animator animator;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            animator = GetComponent<Animator>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// noteDirection ("Up","Down","Left","Right") 과 동일한 Trigger를 재생합니다.
    /// </summary>
    public void PlayHit(string direction)
    {
        // Animator Controller 에서 동일 이름의 Trigger 가 있어야 합니다.
        animator.SetTrigger(direction);
    }
}
//깃연결 확인