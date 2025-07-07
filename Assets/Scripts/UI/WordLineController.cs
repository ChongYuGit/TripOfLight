using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WordLineController : MonoBehaviour
{
    float time;
    public List<string> words;
    public TextMeshProUGUI text;
    private Animator animator;

    private void Start()
    {
        time = 0;
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Show();
    }

    void Show()
    {
        if (words.Count > 0)
        {
            text.text = words[0];

            if(time == 0)
            {
                animator.Play("Show");
            }
            time += Time.fixedDeltaTime;
            if(time >= 3)
            {
                animator.Play("Over");
            }
            if(time >= 4)
            {
                words.RemoveAt(0);
                time = 0;
            }
        }
    }

    public void  Show(List<string> _words)
    {
        words = _words;
        time = 0;
    }
}

