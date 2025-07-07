using UnityEngine;

public class Final : MonoBehaviour
{
    public Animator animator;
    private InputSign inputSign;
    private void Start()
    {
        inputSign = GetComponent<InputSign>();
    }

    private void Update()
    {
        if(inputSign.isShow)//结束按键
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                animator.Play("Final");
            }
        }
    }
}
