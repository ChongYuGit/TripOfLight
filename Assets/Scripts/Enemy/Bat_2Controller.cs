using UnityEngine;

public class Bat_2Controller : MonoBehaviour
{
    Vector2 moveV2;//移动向量
    short state;//0追赶1攻击2逃跑
    float distence;//与玩家的距离
    float time, atktime;
    public bool canAttack;//能否移动、攻击
    public int attackGap;//攻击间隔
    public float speed, escapeSpeed;//追赶速度、逃跑速度
    public float minDistence;//追赶最小距离

    public GameObject bullet;
    public SpriteRenderer spriteRenderer;//警示
    private EnemyCondition enemyCondition;
    private Transform playerTrans;
    private Rigidbody2D rigidbody2D;
    void Start()
    {
        enemyCondition = GetComponent<EnemyCondition>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        playerTrans = GameObject.Find("Player").transform;
        canAttack = true;
    }

    private void FixedUpdate()
    {
        if (enemyCondition.isDead)
            enemyCondition.enemyPool.Put("Bat_2", gameObject);
        State();
        Move();
    }

    void State()
    {
        //数值计算
        distence = (transform.position - playerTrans.position).magnitude;
        //状态判断
        if (time >= attackGap)
        {
            time = 0;
            canAttack = true;
        }
        if (distence <= minDistence)
        {
            if (canAttack)
            {
                state = 1;
                time = 0;
            }
            else
            {
                state = 2;
            }
        }
        if(distence >= minDistence)
        {
            state = 0;
        }
        //警示
        spriteRenderer.enabled = (distence <= minDistence);
    }

    void Move()
    {
        if (state == 0)//追赶
        {
            moveV2 = (playerTrans.position - transform.position).normalized;
            rigidbody2D.velocity = moveV2 * speed;
            time += Time.fixedDeltaTime;
        }
        if (state == 1)//攻击
        {
            atktime += Time.deltaTime;
            if (atktime > 0.5)
            {
                Instantiate(bullet,transform.position,Quaternion.identity);
                state = 2;
                time = 0;
                atktime = -3;
            }
        }
        if (state == 2)//逃跑
        {
            moveV2 = (playerTrans.position - transform.position).normalized;
            rigidbody2D.velocity = -moveV2 * escapeSpeed;
            time += Time.fixedDeltaTime;
            if (distence >= minDistence * 1.5)
            {
                state = 0;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canAttack = false;
            state = 2;
            atktime = 0;
            time = 0;
            collision.GetComponent<Condition>().Hurt(enemyCondition.ATK);
        }
    }
}
