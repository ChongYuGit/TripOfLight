using UnityEngine;

public class EnemyCondition : Condition
{
    public bool isDead;
    public EnemyPool enemyPool;
    public GameObject hurt,boom;

    void FixedUpdate()
    {
        Hurt();
        DEF();
    }

    void Hurt()
    {

        if (time < 0.2f)
        {
            hurt.SetActive(true);
        }
        else if (time <= 0.22)
        {
            hurt.SetActive(false);
        }
        if(nowHP <= 0)
        {
            GetComponent<BoxCollider2D>().enabled = false;
            boom.SetActive(true);
            if(time > 0.3f)
            {
                isDead = true;
            }
        }
    }
}
