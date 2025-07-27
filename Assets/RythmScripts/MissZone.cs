using UnityEngine;

public class MissZone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Note")) return;

        // NoteObject가 있으면 Hit(Miss) 호출,
        // 없으면 그냥 파괴
        var note = other.GetComponent<NoteObject>();
        if (note != null)
            note.Hit(HitResult.Miss);
        else
            Destroy(other.gameObject);
    }
}

