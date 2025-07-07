using UnityEngine;
using Mirror;
using TMPro;
using UnityEngine.SceneManagement;

public class netButton : MonoBehaviour
{
    public TMP_InputField inputField;
    public NetworkManager networkManager;


    private void Update()
    {
        if (!NetworkClient.active)
        {
            networkManager.networkAddress = inputField.text;
        }
    }

    public void Host()
    {
        if(!NetworkClient.active)
        {
            networkManager.StartHost();
        }
    }

    public void Join()
    {
        if(!NetworkClient.active)
        {
            networkManager.StartClient();
        }
    }

    public void Exit()
    {
        Debug.Log(1);       
        networkManager.StopHost();
        networkManager.StopClient();
        SceneManager.LoadScene("StartScene");
    }
}
