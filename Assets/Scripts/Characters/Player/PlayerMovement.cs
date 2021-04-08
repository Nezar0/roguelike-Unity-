using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    public Joystick joystick;
    public ControlType controlType;
    public enum ControlType { PC, Android}

    public float maxMoveSpeed;
    public float currentMoveSpeed;
    public AddSpeed addSpeedTimer;

    public GameObject keyImg;

    private Rigidbody2D rb;
    private Vector2 moveDir;
    private Animator anim;
    private bool isKey;

    private void Start()
    {
        currentMoveSpeed = maxMoveSpeed;
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
        if (moveDir.x == 0 && moveDir.y == 0) 
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("potion_yellow"))
        {
            if (!addSpeedTimer.isCooldown)
            {
                currentMoveSpeed += (maxMoveSpeed / 100) * 20;
                addSpeedTimer.gameObject.SetActive(true);
                addSpeedTimer.isCooldown = true;                
                Destroy(collision.gameObject);
            }
            else
            {
                addSpeedTimer.ResetTimer();
                Destroy(collision.gameObject);
            }
        }
        else if(collision.CompareTag("Key"))
        {
            keyImg.SetActive(true);
            Destroy(collision.gameObject);
            isKey = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Door_close") && isKey)
        {
            keyImg.SetActive(false);
            collision.gameObject.GetComponent<Animator>().SetBool("open", true);
            isKey = false;
        }
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDir.x * currentMoveSpeed, moveDir.y * currentMoveSpeed);
    }

}
