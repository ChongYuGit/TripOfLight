using UnityEngine;

public class Condition : MonoBehaviour
{
    public float maxHP, nowHP, maxDEF, nowDEF, ATK, DEFSpeed;
    public bool canDEF;
    public float upDEF;
    public float time;

    public UIController ui;

    private void OnEnable()
    {
        time = 4;
        nowHP = maxHP;
        nowDEF = maxDEF;
        upDEF = 1;
    }

    public void Hurt(float atks)
    {
        canDEF = false;
        time = 0;
        if (nowDEF > 0)
        {
            nowDEF -= atks * upDEF;
            if (nowDEF < 0)
            {
                nowDEF = 0;
            }
            ui.DEFChange(nowDEF / maxDEF);
        }
        else
        {
            nowHP -= atks * upDEF;
            if (nowHP <= 0)
            {
                nowHP = 0;
            }
            ui.HPChange(nowHP / maxHP);
        }
    }

    public void Heal(float heals)
    {
        nowHP += heals;
        if(nowHP > maxHP)
        {
            nowHP = maxHP;
        }
        ui.HPChange(nowHP / maxHP);

    }

    public void DEF()
    {
        time += Time.fixedDeltaTime;
        canDEF = (time >= 3);
        if (nowDEF < maxDEF && canDEF)
        {
            nowDEF += Time.fixedDeltaTime * DEFSpeed;
            ui.DEFChange(nowDEF / maxDEF);
        }
    }
}
