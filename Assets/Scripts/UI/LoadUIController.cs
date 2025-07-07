using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadUIController : MonoBehaviour
{
    float time;
    bool isOK,isLoad;

    public Transform load_,load_Now, head,cover;

    private void OnEnable()
    {
        time = 0;
    }
    void FixedUpdate()
    {
        if(isLoad)
        {
            Load();
        }
    }

    public void Load()
    {
        time += Time.fixedDeltaTime * 0.8f;
        if (!isOK)
        {
            if(time <= 0.5f)
            {
                cover.localScale = new Vector3(time * 110, time * 110, 1);
            }
            else if (time <= 1.5f)
            {
                head.gameObject.SetActive(true);
                load_.gameObject.SetActive(true);
                load_Now.gameObject.SetActive(true);
                load_Now.transform.localScale = new Vector3(time - 0.5f, 1, 1);
            }
            else
            {
                head.GetComponent<Animator>().Play("OK");
                isOK = true;
            }
        }
        if (isOK)
        {
            if (time > 2.5f)
            {
                SceneManager.LoadScene("MainScene");
            }
        }
    }

    public void ClickStart()
    {
        isLoad = true;
    }
}
