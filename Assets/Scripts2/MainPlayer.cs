using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
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
        
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        
        if (input != Vector2.zero)
        {
            animator.SetFloat("LastMoveX", input.x);
            animator.SetFloat("LastMoveY", input.y);
        }


        animator.SetBool("IsMoving", input != Vector2.zero);

        
        input.Normalize();
    }

    void FixedUpdate()
    {
    
        rb.velocity = input * moveSpeed;
    }
}