using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float deathCooldown = 0f;
    private Animator animator;

    private Rigidbody2D _rigidbody2D;

    public float flapforce = 6f;

    public float forwardspeed = 3f;

    public bool isDead = false;

    bool isFlap = false;

    public bool godMode = false;
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        animator = transform.GetComponentInChildren<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();

        if (animator == null)
            Debug.LogError("Not found animator");
        if (_rigidbody2D == null)
            Debug.LogError("Not found rigidbody2D");
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            if (deathCooldown <= 0)
            {
                //게임 재시작
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    GameManager.Instance.RestartGame();
                }
            }
            else
            {
                deathCooldown -= Time.deltaTime;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                isFlap = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (isDead) return;
        Vector3 velocity = _rigidbody2D.velocity;
        velocity.x = forwardspeed;
        if (isFlap)
        {
            velocity.y = flapforce;
            isFlap = false;
        }

        _rigidbody2D.velocity = velocity;

        float angle = Mathf.Clamp((_rigidbody2D.velocity.y * 10f), -90, 90);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (godMode) return;
        if (isDead) return;
        isDead = true;
        deathCooldown = 1f;

        animator.SetInteger("isDie", 1);
        gameManager.GameOver();
        
    }
   
}
