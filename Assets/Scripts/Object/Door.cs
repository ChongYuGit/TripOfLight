using UnityEngine;

public class Door : MonoBehaviour
{
    bool isOpen;
    public float speed;//升降速度

    public Transform door;
    private void FixedUpdate()
    {
        if(isOpen && door.localPosition.y < 0.55)//升
        {
            door.localPosition += new Vector3(0,Time.fixedDeltaTime * speed,0);
        }
        else if(!isOpen && door.localPosition.y > 0)//降
        {
            door.localPosition -= new Vector3(0, Time.fixedDeltaTime * speed, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isOpen = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isOpen = false;
        }
    }
}
