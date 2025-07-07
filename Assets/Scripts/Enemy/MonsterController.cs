using UnityEngine;

public class MonsterController : MonoBehaviour
{
    float time;
    bool isBack;
    public float speed;
    public int i;
    public bool isLoop;//路径是否循环

    public Transform[] transforms;
    private EnemyCondition enemyCondition;
    private Rigidbody2D rigidbody2D;

    private void Start()
    {
        enemyCondition = GetComponent<EnemyCondition>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        i = 0;
    }

    private void FixedUpdate()
    {
        if(enemyCondition.isDead)
        {
            Destroy(gameObject);
        }
        time += Time.fixedDeltaTime;
        //移动
        rigidbody2D.velocity = (transforms[i].position - transform.position).normalized * speed;
        //旋转
        Rotate();
        //目标判断
        if(!isLoop)
        {
            //来回
            ToBack();
        }
        else
        {
            //循环
            Loop();
        }
    }

    void ToBack()
    {
        if ((transform.position - transforms[i].position).magnitude <= 0.1f)
        {
            if (!isBack)
            {
                i++;
                if (i > transforms.Length - 1)
                {
                    isBack = true;
                    i--;
                }
            }
            else
            {
                i--;
                if (i < 0)
                {
                    isBack = false;
                    i++;
                }
            }
        }
    }

    void Loop()
    {
        if ((transform.position - transforms[i].position).magnitude <= 0.02f)
        {
            i++;
            if (i > transforms.Length - 1)
            {
                i = 0;
            }
        }
    }

    void Rotate()
    {
        if(isBack)
        {
            transform.localEulerAngles = new Vector3(0, 0, Mathf.Rad2Deg * Mathf.Atan2(transform.position.y - transforms[i].position.y, transform.position.x - transforms[i].position.x));
        }
        else
        {
            transform.localEulerAngles = new Vector3(0, 0, Mathf.Rad2Deg * Mathf.Atan2(transforms[i].position.y - transform.position.y, transforms[i].position.x - transform.position.x));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && time>=1)
        {
            time = 0;
            collision.GetComponent<Condition>().Hurt(enemyCondition.ATK);
        }
    }
}
