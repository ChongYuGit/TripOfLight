using UnityEngine;

public class Finally : MonoBehaviour
{
    float time;
    bool isend;
    public GameObject camera,UI;
    public InputSign inputSign;

    void Update()
    {
        if (inputSign.isShow && Input.GetKeyDown(KeyCode.F))//按键输入
        {
            isend = true;
        }
    }

    private void FixedUpdate()
    {
        if(isend)
        {
            time += Time.fixedDeltaTime;
        }
        if (time >= 7 && time < 8)
        {
            time = 9;
        }
        if(time == 9)
        {
            camera.GetComponent<Chooser>().isTrack = false;
            camera.GetComponent<Chooser>().vertiRange = 100;
            camera.GetComponent<Chooser>().horiRange = 100;
        }
        if(time > 12)
        {
            Debug.Log(1);
            camera.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0.5f);
        }
        if (time > 25)
        {
            camera.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            UI.SetActive(true);
        }
    }
}
