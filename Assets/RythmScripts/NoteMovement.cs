using UnityEngine;

public class NoteMovement : MonoBehaviour
{
    public float speed = 0.1f;  // 스폰 스크립트에서 설정됨

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
}