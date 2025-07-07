using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightSign : MonoBehaviour
{
    float time;
    public List<string> words;//字幕
    public GameObject light;//光
    private Light2D light_;
    private InputSign inputSign;
    private WordLineController word;//字幕UI
    private void Start()
    {
        light_ = light.GetComponent<Light2D>();
        light.SetActive(false);
        inputSign = GetComponent<InputSign>();
        word = GameObject.Find("WordLine").GetComponent<WordLineController>();
    }

    private void Update()
    {
        if(inputSign.isShow && Input.GetKeyDown(KeyCode.F))
        {
            light.SetActive(true);
            word.Show(words);
        }
    }
    private void FixedUpdate()
    {
        if (light.activeSelf && time <= 1)
        {
            light_.intensity = time * 0.5f;
            time += Time.fixedDeltaTime * 0.6f;
        }
        if(time>0.4)
        {
            Destroy(gameObject);
        }
    }
}
