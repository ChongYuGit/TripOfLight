using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootContorller : MonoBehaviour
{
    public Vector3 V3;
    public float ATK;
    public float speed;

    private void Start()
    {
        V3 = (GameObject.Find("Player").transform.position - transform.position).normalized;
    }

    private void FixedUpdate()
    {
        transform.position += V3 * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.GetComponent<Condition>().Hurt(ATK);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
