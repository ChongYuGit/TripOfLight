using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSign : MonoBehaviour
{
    public GameObject sign;
    public bool isShow;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && isShow)
        {
            GameObject.Find("Player").GetComponent<PlayerCondition>().save = transform.position;//存档地图
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            sign.SetActive(true);
            isShow = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            sign.SetActive(false);
            isShow = false;
        }
    }
}
