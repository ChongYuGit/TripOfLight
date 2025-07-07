using UnityEngine;

public class Thorns : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
            collision.GetComponent<PlayerCondition>().nowHP = 0;
    }
}
