using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ESC : MonoBehaviour
{
    public bool isEnd;
    public GameObject UI;
    public Animator animator;
    TextMeshProUGUI proUGUI;

    private void Start()
    {
        proUGUI = animator.gameObject.GetComponentInChildren<TextMeshProUGUI>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            UI.SetActive(!UI.activeSelf);
        }    
    }

    public void Back()
    {
        UI.SetActive(false);
        if(isEnd)
        {
            animator.Play("Over");
        }
        else
        {
            proUGUI.text = "谢谢你";
            animator.Play("End");
        }
        Invoke("BaCK", 2f);
    }

    public void BaCK()
    {
            SceneManager.LoadScene("StartScene");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
