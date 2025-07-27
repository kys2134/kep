using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform target;  

    private Vector3 offset;   

    void Start()
    {
        if (target == null)
        {
            Debug.LogWarning("FollowCamera: 타겟이 할당되지 않았습니다.");
            return;
        }

        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        if (target == null) return;

       
        transform.position = target.position + offset;
    }
}