using UnityEngine;
using UnityEngine.UI;

public class HeytaController : MonoBehaviour
{
    float time;
    bool canHeal;
    public AudioSource audioSource;
    private PlayerCondition playerCondition;
    private FairyController fairyController;
    public GameObject UI;
    public Image image;
    void Start()
    {
        image.fillAmount = 0;
        playerCondition = GameObject.Find("Player").GetComponent<PlayerCondition>();
        fairyController = GetComponent<FairyController>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Q) && canHeal && fairyController.isPlayer)
        {
            audioSource.Play();
            canHeal = false;
            playerCondition.Heal(5);
            image.fillAmount = 1;
        }
        if (fairyController.isPlayer)
        {
            UI.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        if(canHeal)
        {
            image.fillAmount = 0;
        }
        if (!canHeal)
        {
            time += Time.fixedDeltaTime;
        }
        if (time >= 0)
        {
            image.fillAmount = (15 - time) * 1 / 15f;
        }
        if (time >= 15)
        {
            canHeal = true;
            time = 0;
        }
    }
}
