using UnityEngine;

public class BulletController : MonoBehaviour
{
    float time;
    public float speed, ATK;
    public Vector3 startV3, toV3, betweenV3;

    public GameObject boom;
    public BulletPool bulletPool;

    private void OnEnable()
    {
        time = 0;
    }

    void FixedUpdate()
    {
        time += Time.fixedDeltaTime * speed;
        Track();
        if(time > 1)
        {
            bulletPool.Put(gameObject);
        }
    }

    void Track()
    { 
        //±´Èû¶ûÇúÏß
        Vector3 V31 = Vector3.Lerp(startV3, betweenV3, time);
        Vector3 V32 = Vector3.Lerp(betweenV3, toV3, time);
        transform.position = Vector3.Lerp(V31, V32, time);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            Instantiate(boom,transform.position,Quaternion.identity);
            collision.GetComponent<Condition>().Hurt(ATK);
            bulletPool.Put(gameObject);
        }
    }
}
