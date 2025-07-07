using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOut : MonoBehaviour
{
    bool used;
    public EnemyPool enemyPool;
    public Transform[] Bat_1;
    public Transform[] Bat_2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!used)
        {
            if (collision.CompareTag("Player"))
            {
                for (int i = 0; i < Bat_1.Length; i++)
                {
                    enemyPool.Get("Bat_1", Bat_1[i]);
                }
                for (int i = 0; i < Bat_2.Length; i++)
                {
                    enemyPool.Get("Bat_2", Bat_2[i]);
                }
                used = true;
            }
        }
    }
}
