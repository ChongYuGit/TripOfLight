using UnityEngine;

public class Control : MonoBehaviour
{
    private Chooser chooser;
    private FairyController fairyController;
    void Start()
    {
        fairyController = GetComponent<FairyController>();
        chooser = Camera.main.GetComponent<Chooser>();
        chooser.canChoose = false;
    }

    void Update()
    {
        if(fairyController.isPlayer)//是否获取精灵
        {
            if (chooser.chooseeScale == null)//选空
            {
                chooser.canChoose = true;
                fairyController.track = GameObject.Find("Player").transform;
            }
            else
            {
                chooser.canChoose = false;
                fairyController.track = chooser.chooseeScale.transform;
            }
        }

    }
}
