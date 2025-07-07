using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject HP_now, HP_Ing, DEF_now;
    public Image Power_now;

    public void HPChange(float _much)
    {
        HP_now.transform.localScale = new Vector3(_much, 1, 1);
    }

    public void DEFChange(float _much)
    {
        DEF_now.transform.localScale = new Vector3(_much, 1, 1);
    }

    public void PowerChange(float _much)
    {
        Power_now.fillAmount = _much;
    }
}
