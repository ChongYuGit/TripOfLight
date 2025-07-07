using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyController : MonoBehaviour
{
    float time;
    public Vector3 trackV3;//追踪位置偏移
    public bool isFollow,isPlayer;//是否跟随、是否跟随玩家
    public float trackSpeed;//跟踪目标
    public float maxDistence;//范围

    private  Rigidbody2D rig2D;
    public Transform track;//精灵跟踪目标
    void Start()
    {
        rig2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if(isFollow)
        {
            TrackChange();
        }
    }

    void TrackChange()
    {
        //V3随机改变
        time += Time.fixedDeltaTime;
        if (time > 2 && isPlayer)
        {
            trackV3 = new Vector3(Random.Range(-0.3f, 0.3f), Random.Range(0.25f, 0.55f), 0);
            time = 0;
        }
        if (time > 2 && !isPlayer)
        {
            trackV3 = new Vector3(Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, -0.2f), 0);
            time = 0;
        }
        //跟随判断
        if ((transform.localPosition - trackV3 - track.localPosition).magnitude <= maxDistence)
        {
            //Idle
        }
        else
        {
            Track();
        }
    }

    void Track()
    {
        rig2D.velocity = new Vector2(track.localPosition.x + trackV3.x - transform.localPosition.x , track.localPosition.y + trackV3.y - transform.localPosition.y) * trackSpeed;
    }
}
