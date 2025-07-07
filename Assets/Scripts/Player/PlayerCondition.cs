using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCondition : Condition
{
    public Vector3 save;
    float _HP,_DEF;
    bool isDead;
    [Header("Power")]
    public float maxPower,nowPower,powerSpeed;
    [Header("UI")]
    public GameObject emotion1,emotion2, cover;
    public GameObject powerSign;
    public Animator animator;

    private void Start()
    {
        nowPower = maxPower;
    }

    private void FixedUpdate()
    {
        if (nowHP == 0 && !isDead)
        {
            OVER();
        }
        if(_HP < nowHP || _DEF < nowDEF)
        {
            _HP = nowHP;_DEF = nowDEF;
        }
        if(_HP > nowHP || _DEF > nowDEF)
        {
            animator.Play("Hurted");
            _HP = nowHP;
            _DEF = nowDEF;
        }
        DEF();
        Power();
        Emotion();
    }

    void Emotion()
    {
        if (!canDEF)
        {
            if (nowDEF > 0)
            {
                emotion1.SetActive(true);
                emotion2.SetActive(false);
            }
            else
            {
                emotion1.SetActive(false);
                emotion2.SetActive(true);
            }
        }
        else
        {
            emotion1.SetActive(false);
            emotion2.SetActive(false);
        }
    }
    
    public void Power(float _cost)
    {
        nowPower -= _cost;
        if(nowPower < 0)
        {
            nowPower = 0;
        }
        ui.PowerChange(nowPower / maxPower);
    }

    void Power()
    {
        nowPower += powerSpeed * Time.fixedDeltaTime;
        if(nowPower > maxPower)
        {
            nowPower = maxPower;
        }
        ui.PowerChange(nowPower / maxPower); 
        powerSign.SetActive(nowPower <= maxPower * 0.3f);

    }
    public void OVER()
    {
        cover.GetComponent<Animator>().Play("Over");
        isDead = true;
        Invoke("ReLife", 1f);
    }

    void ReLife()
    {
        transform.position = save;
        nowDEF = maxDEF;
        nowHP = maxHP;
        nowPower = maxPower;
        Hurt(0);
        Heal(0);
        Power(0);
        isDead = false;
    }    
}
