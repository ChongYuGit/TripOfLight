using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUIContorller : MonoBehaviour
{
    public GameObject loadUI;

    public void ClickExit()
    {
        Application.Quit();
    }

    public void NEW()
    {
        SceneManager.LoadScene("MapEditorScene");
    }
}
