using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpead;

    public Rigidbody2D rb;

    private Vector2 moveDir;

    private void Update()
    {
        ProcessInputs();   
    }
    void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDir = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDir.x * moveSpead, moveDir.y * moveSpead);
    }
}
