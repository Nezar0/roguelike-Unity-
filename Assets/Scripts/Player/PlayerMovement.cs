using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    public Joystick joystick;
    public ControlType controlType;
    public enum ControlType { PC, Android}

    public float moveSpead;

    private Rigidbody2D rb;
    private Vector2 moveDir;
    private Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }
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
        if (controlType == ControlType.PC)
        {
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveY = Input.GetAxisRaw("Vertical");
            moveDir = new Vector2(moveX, moveY).normalized;
        }
        else if (controlType == ControlType.Android)
        {
            float moveX = joystick.Horizontal;
            float moveY = joystick.Vertical;
            moveDir = new Vector2(moveX, moveY).normalized;
        }
        if (moveDir.x == 0 || moveDir.y == 0) 
        {
            anim.SetBool("isRunning", false);
        }
        else
        {
            anim.SetBool("isRunning", true);
        }

        if (moveDir.x > 0)
        {
            this.gameObject.transform.localScale = new Vector3(6.25f, 6.25f, 1);
        }
        else if (moveDir.x < 0) 
        {
            this.gameObject.transform.localScale = new Vector3(-6.25f, 6.25f, 1);
        }
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDir.x * moveSpead, moveDir.y * moveSpead);
    }

}
