using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float runspeed = 20;
    private float walkspeed = 10;
    public float speed;
    private string runanim = "run";
    private string walkanim = "walk";
    private string anim;
    private string idleanim = "idle";

    private float jumpForce = 10;
    private bool isRunMode = false;
    private Rigidbody2D rb;
    private StaminaComponent stamina;
    private AnimStateMachine animStateMachine;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        stamina = GetComponent<StaminaComponent>();
        animStateMachine = GetComponent<AnimStateMachine>();
        stamina.Init(100, 100, 1);
    }

    void Update()
    {
        inputHandler();
        PhisicsAddForceMove();
        Jump();
        stamina.Regen();
        //Idle();
    }

    void PhisicsAddForceMove()
    {

        if (isRunMode == true)
        {
            speed = runspeed;
            anim = runanim;
        }
        else
        {
            speed = walkspeed;
            anim = walkanim;
        }
        if (Input.GetKey(KeyCode.D))
        {
            animStateMachine.isRun = true;
            rb.AddForce(new Vector2(speed * Time.deltaTime, 0), ForceMode2D.Impulse);
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }
        if (Input.GetKey(KeyCode.A))
        {
            animStateMachine.isRun = true;
            rb.AddForce(new Vector2(speed * Time.deltaTime * (-1), 0), ForceMode2D.Impulse);
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x) * (-1), transform.localScale.y);
        }
    }

    void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && rb.velocity.y == 0 && stamina.Check(7))
        {
            stamina.Reduce(7);
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    void Idle()
    {
        if (rb.velocity.x == 0 && rb.velocity.y == 0)
        {
            animStateMachine.isIdle = true;
        }
        else
        {
            animStateMachine.isIdle = false;
        }
    }

    void inputHandler()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isRunMode = !isRunMode;
        }
    }



    // void PhisicsVelocityMove() {
    //     if (Input.GetKey(KeyCode.D)) {
    //         // rb.AddForce(new Vector2(runspeed, 0));
    //         rb.velocity = new Vector2(runspeed, 0);
    //         transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
    //     }
    //     if (Input.GetKey(KeyCode.A)) {
    //         // rb.AddForce(new Vector2(runspeed*(-1), 0));
    //         rb.velocity = new Vector2(runspeed*(-1), 0);
    //         transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x)*(-1), transform.localScale.y);
    //     }
    //     if (Input.GetKey(KeyCode.W)) {
    //         // rb.AddForce(new Vector2(0, runspeed));
    //         rb.velocity = new Vector2(0, runspeed);
    //     }
    //     if (Input.GetKey(KeyCode.S)) {
    //         // rb.AddForce(new Vector2(0, runspeed*(-1)));
    //         rb.velocity = new Vector2(0, runspeed*(-1));
    //     }
    // }


    // void CoordMove() {
    //     // Input.GetKey - зажатие
    //     // Input.GetKeyDown - одно нажание 
    //     // Input.GetKeyUp - отжатие клавиши
    //     if (Input.GetKey(KeyCode.D)) {
    //         transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
    //         transform.position = new Vector2(transform.position.x +  runspeed * Time.deltaTime, transform.position.y + 0);

    //     }

    //     if (Input.GetKey(KeyCode.A)) {
    //         transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x)*(-1), transform.localScale.y);
    //         transform.position = new Vector2(transform.position.x - runspeed * Time.deltaTime, transform.position.y - 0);
    //     }

    //     if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space)) {
    //         transform.position = new Vector2(transform.position.x + 0, transform.position.y + runspeed * Time.deltaTime);

    //     }

    //     if (Input.GetKey(KeyCode.S)) {
    //         transform.position = new Vector2(transform.position.x - 0, transform.position.y - runspeed * Time.deltaTime);

    //     }
    // }
}
