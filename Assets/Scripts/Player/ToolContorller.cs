using UnityEngine;

public class ToolContorller : MonoBehaviour
{
    FairyController fairyController;
    public GameObject light;

    private void Start()
    {
        light.SetActive(false);
        fairyController = this.GetComponentInParent<FairyController>();
    }

    private void FixedUpdate()
    {
        if(!light.activeSelf && fairyController.isPlayer)
        {
            light.SetActive(true);
        }
        if(light.activeSelf)
        {
            Rotate();
        }
    }

    void Rotate()
    {
        //手持道具旋转
        transform.localEulerAngles = new Vector3(0, 0, Mathf.Atan2(Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y, Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x) * Mathf.Rad2Deg);
    }
}
