using UnityEngine;

public class Flod : MonoBehaviour
{
    public GameObject ui;


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            DisShow();
        }
    }

    public void DisShow()
    {
        ui.SetActive(!ui.activeSelf);
    }
}
