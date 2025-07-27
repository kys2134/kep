using UnityEngine;
       // HitResult enum namespace (프로젝트 구조에 따라 바꿔주세요)

public class JudgeZone : MonoBehaviour
{
    public enum Direction { Up, Down, Left, Right }
    public Direction judgeDirection;   // Inspector 에서 드롭다운으로 선택

    private NoteObject currentNote;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Note"))
            currentNote = other.GetComponent<NoteObject>();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // 존을 떠나는 노트는 취소
        if (other.CompareTag("Note") &&
            other.GetComponent<NoteObject>() == currentNote)
            currentNote = null;
    }

    void Update()
    {
        if (currentNote == null) return;

        // 한 번만 감지되는 GetKeyDown
        if (Input.GetKeyDown(GetKeyCode(judgeDirection)))
        {
            // 방향이 일치하면 Hit 호출
            if (currentNote.noteDirection == judgeDirection.ToString())
            {
                // TODO: 실제 판정 로직에 따라 Perfect/Good/Miss 골라주세요
                currentNote.Hit(HitResult.Perfect);

                currentNote = null;
            }
        }
    }

    KeyCode GetKeyCode(Direction dir)
    {
        switch (dir)
        {
            case Direction.Up:    return KeyCode.UpArrow;
            case Direction.Down:  return KeyCode.DownArrow;
            case Direction.Left:  return KeyCode.LeftArrow;
            case Direction.Right: return KeyCode.RightArrow;
        }
        return KeyCode.None;
    }
}





