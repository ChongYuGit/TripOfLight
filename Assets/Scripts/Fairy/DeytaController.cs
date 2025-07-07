using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeytaController : MonoBehaviour
{
    float DEFs;
    float time;
    bool isDEF;
    private FairyController fairyController;
    public GameObject UI;
    public Image image;
    public GameObject DEF;
    private PlayerCondition playerCondition;
    void Start()
    {
        playerCondition = GameObject.Find("Player").GetComponent<PlayerCondition>();
        fairyController = GetComponent<FairyController>();
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.E) && !isDEF && fairyController.isPlayer)
        {
            DEF.SetActive(true);
            isDEF = true;
            time = 0;
            image.fillAmount = 1;
            playerCondition.upDEF = 0;
        }
        if (fairyController.isPlayer)
        {
            UI.SetActive(true);
        }

    }

    private void FixedUpdate()
    {
        if(isDEF)
        {
            time += Time.fixedDeltaTime;
        }
        if (time >= 3)
        {
            DEF.SetActive(false);
            image.fillAmount = (8 - time) * 0.2f;
        }
        if (time>=8)
        {
            isDEF = false;
            playerCondition.upDEF = 1;
        }
    }
}
