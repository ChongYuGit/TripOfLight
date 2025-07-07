using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyOrigin : MonoBehaviour
{
    public FairyController fairyController;
    private InputSign inputSign;
    
    private void Start()
    {
        fairyController.track = transform;
        fairyController.isFollow = true;
        fairyController.isPlayer = false;
        inputSign = GetComponent<InputSign>();
    }

    void Update()
    {
        if (inputSign.isShow && Input.GetKeyDown(KeyCode.F))//按键输入
        {
            fairyController.track = GameObject.Find("Player").transform;
            fairyController.isPlayer = true;
            fairyController.GetComponent<AudioSource>().Play();
        }
    }
}
