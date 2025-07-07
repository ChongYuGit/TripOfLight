using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_2Controller : MonoBehaviour
{
    float time;
    public float range;
    public float distence;
    public GameObject bullets;
    private SpriteRenderer spriteRenderer;
    private EnemyCondition enemyCondition;
    private Transform playerV3;
    void Start()
    {
        time = 5;
        enemyCondition = GetComponent<EnemyCondition>();
        playerV3 = GameObject.Find("Player").transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        spriteRenderer.flipX = (playerV3.position.x - transform.position.x) < 0;
        distence = (playerV3.position - transform.position).magnitude;
        if(distence <= range)
        {
            time += Time.fixedDeltaTime;
            Attack();
        }
    }

    void Attack()
    {
        if(time >= 6)
        {
            time = 0;
            Instantiate(bullets, transform.position, Quaternion.identity);
        }
    }

}
