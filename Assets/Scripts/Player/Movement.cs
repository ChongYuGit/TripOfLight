using UnityEngine;

public class Movement : MonoBehaviour
{
    float time;
    public float gravity;//重力
    public float moveSpeed;//移动速度
    public float jumpSpeed,jumpTime1,jumpTime2;//跳跃速度、时间
    public bool canJump1, canJump2, isJump1,isJump2, isFall;//跳跃状态
    public float rayLength;//射线检测长度

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Rigidbody2D rigidbody2D;
    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        JumpCheck();
    }
    private void FixedUpdate()
    {
        Move();
        Gravity();
        Jump();
    }
    void JumpCheck()
    {
        //下方检测
        if (Physics2D.Raycast(new Vector2(transform.localPosition.x, transform.localPosition.y), Vector2.down,rayLength,LayerMask.GetMask("Map","ObjectF")))
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 0);
            canJump1 = true;
            isFall = false;
        }
        else
        {
            isFall = true;
            canJump1 = false;
        }
        //上方检测
        if (Physics2D.Raycast(new Vector2(transform.localPosition.x, transform.localPosition.y + 0.28f), Vector2.up,rayLength ,LayerMask.GetMask("Map", "ObjectF")))
        {
            isJump1 = isJump2 = false; 
        }
        //空格输入
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canJump1)
            {
                isJump1 = true;
                isJump2 = false;
                canJump1 = false;
                canJump2 = true;
            }
            else if(canJump2)
            {
                isJump1 = false;
                isJump2 = true;
                canJump2 = false;
                time = 0;
            }
        }
        //动画跳跃、掉落赋值
        if (rigidbody2D.velocity.y > 0)
        {
            animator.SetBool("isJump", true);
            animator.SetBool("isFall", false);
        }
        else if (rigidbody2D.velocity.y < 0)
        {
            animator.SetBool("isJump", false);
            animator.SetBool("isFall", true);
        }
        else
        {
            animator.SetBool("isJump", false);
            animator.SetBool("isFall", false);
        }
    }
    private void Move()
    {
        //奔跑
        rigidbody2D.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, rigidbody2D.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(rigidbody2D.velocity.x));
        //转身
        //spriteRenderer.flipX = !((Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x) > 0);
        if(Input.GetAxis("Horizontal") != 0)
        {
            spriteRenderer.flipX = Input.GetAxis("Horizontal") < 0;
        }
    }
    void Jump()
    {
        //一段跳
        if (isJump1)
        {
            time += Time.fixedDeltaTime;
            if (time < jumpTime1 && Input.GetKey(KeyCode.Space))
            {
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpSpeed);
            }
            else
            {
                isFall = true;
                isJump1 = false;
                time = 0;
            }
        }
        //二段跳
        if (isJump2)
        {
            time += Time.fixedDeltaTime;
            if (time < jumpTime2 && Input.GetKey(KeyCode.Space))
            {
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpSpeed);
            }
            else
            {
                isFall = true;
                isJump2 = false;
                time = 0;
            }
        }
    }
    void Gravity()
    {
        //重力
        if(isFall)
        {
            rigidbody2D.velocity += new Vector2(0, -gravity * Time.fixedDeltaTime);
        }
    }
}
