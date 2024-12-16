using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _HP;
    [SerializeField] private float _jumpForce;
    private bool _isGround = false;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _ground;   

    private Rigidbody2D rb;
    private SpriteRenderer sprite;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }
    private void Update()
    {
        if (Input.GetButton("Horizontal"))
        {
            Run();
        }
        Jump();
        CheckGround();
    }

    private void Run()
    {
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, _speed * Time.deltaTime);

        sprite.flipX = dir.x < 0f;
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGround)
        {
            rb.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
        }
    }
    private void CheckGround()
    {
        _isGround = Physics2D.OverlapCircle(_groundCheck.position, 0.2f, _ground);

    }
}
