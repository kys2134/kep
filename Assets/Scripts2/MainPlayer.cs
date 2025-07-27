using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("이동 속도")]
    public float moveSpeed = 5f;

    [Header("맵 경계 (Inspector에서 설정)")]
    public Vector2 minBounds;  // 예: 좌하단 월드 좌표
    public Vector2 maxBounds;  // 예: 우상단 월드 좌표

    private Rigidbody2D rb;
    private Vector2 input;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // 입력 읽기
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        
        // 마지막 이동 방향 저장 (애니메이션용)
        if (input != Vector2.zero)
        {
            animator.SetFloat("LastMoveX", input.x);
            animator.SetFloat("LastMoveY", input.y);
        }

        // 이동 여부
        animator.SetBool("IsMoving", input != Vector2.zero);

        input.Normalize();
    }

    void FixedUpdate()
    {
        // 실제 이동
        rb.velocity = input * moveSpeed;
    }

    void LateUpdate()
    {
        // 물리 계산 후, 화면 밖으로 나가지 않도록 위치 고정
        Vector3 p = transform.position;
        p.x = Mathf.Clamp(p.x, minBounds.x, maxBounds.x);
        p.y = Mathf.Clamp(p.y, minBounds.y, maxBounds.y);
        transform.position = p;
    }
}