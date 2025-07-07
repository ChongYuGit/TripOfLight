using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    void Finally()//玩家转移
    {
        SceneManager.LoadScene("FinalScene");
    }
}
