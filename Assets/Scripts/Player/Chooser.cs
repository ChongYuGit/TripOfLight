using UnityEngine;

public class Chooser : MonoBehaviour
{
    [Header("Choose")]
    public bool canChoose;//能否选取
    public float force;//吸引力
    public float scaleSpeed;//缩放速度
    public Scale chooseeScale;//被选取物体
    [Header("Track")]
    public float trackSpeed;//追踪速度
    public float horiRange,vertiRange,height;//四方跟踪边缘与高度
    public bool isTrack;//是否追踪
    Transform track;//追踪目标
    //组件
    Rigidbody2D rigidbody2D;
    RaycastHit2D hit;

    private void Start()
    {
        track = GameObject.Find("Player").GetComponent<Transform>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    { 
        if (Input.GetKeyDown(KeyCode.Mouse0) && canChoose)//选取
        {
            MouseChoose();
        }
        Track();
    }

    void MouseChoose()
    {
        if(Physics2D.Raycast(new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y),Vector2.zero))
        {
            hit = Physics2D.Raycast(new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y), Vector2.zero);
            if(hit.transform.CompareTag("ObjectF"))
            {
                chooseeScale = hit.transform.GetComponent<Scale>();
                canChoose = false;
                chooseeScale.isChoosen = true;
                chooseeScale.chooserTrans = transform;
                chooseeScale.chooserChoos = this;
            }
        }
    }

    void Track()
    {
        //距离判断是否追踪
        if(Mathf.Abs(track.localPosition.x - transform.localPosition.x) > horiRange || Mathf.Abs(track.localPosition.y - transform.localPosition.y + height) > vertiRange)
            isTrack = true;
        else
            isTrack = false;
        //追踪
        if(isTrack)
        {
            rigidbody2D.AddForce((new Vector3(track.localPosition.x, track.localPosition.y, 0) - new Vector3(transform.localPosition.x, transform.localPosition.y - height, 0)) * trackSpeed);
        }
    }
}