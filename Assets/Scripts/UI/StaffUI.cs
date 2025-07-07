using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffUI : MonoBehaviour
{
    public GameObject staffUI;

    public void ClickOpen()
    {
        staffUI.SetActive(true);
    }

    public void ClickExit()
    {
        staffUI.SetActive(false);
    }
}
