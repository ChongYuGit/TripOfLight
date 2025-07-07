using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Scale : MonoBehaviour
{
    public float maxScale;//最大规格
    public float minScale;//最小规格
    public float nowScale;//当前规格
    public bool canScale;//能否放缩
    [HideInInspector] public bool isChoosen;//是否被选择

    [HideInInspector]public Transform chooserTrans;//选择者的transform组件
    [HideInInspector]public Chooser chooserChoos;//选择者的Chooser组件
    Rigidbody2D rigidbody2D;

    void Start()
    {
        nowScale = transform.localScale.x;
        canScale = true;
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isChoosen && canScale)//缩放判断
        {
            ScaleChange();
            //放下判断
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                Cancel();
            }
        }
    }
    private void FixedUpdate()
    {
        if (isChoosen)
        {
            Attract();
        }
    }

    public void ScaleChange()
    {
        //滚轮改变大小值
        nowScale += Input.GetAxis("Mouse ScrollWheel") * chooserChoos.scaleSpeed;
        //大小约束
        if (nowScale > maxScale)
            nowScale = maxScale;
        if (nowScale < minScale)
            nowScale = minScale;
        //大小变化
        transform.localScale = Vector3.one * nowScale;
        //重力变化
        rigidbody2D.gravityScale = nowScale * 3f;
    }

    public void Attract()
    {
        //吸引受力
        rigidbody2D.AddForce(new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.localPosition.x,
                             Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.localPosition.y).normalized * chooserChoos.force);
    }

    void Cancel()
    {
        //解除选择
        isChoosen = false;
        chooserChoos.canChoose = true;
        chooserTrans = null;
        chooserChoos.chooseeScale = null;
        chooserChoos = null;
        rigidbody2D.gravityScale = 2f;
    }
}
