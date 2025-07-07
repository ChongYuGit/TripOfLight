using System.Collections.Generic;
using UnityEngine;


public class BulletPool : MonoBehaviour
{
    float time;
    public float cost;
    public float r, speed, frequency, maxTime;//中间点半径、子弹速度、发射频率、子弹运动时间
    public int maxBullets;

    FairyController fairyController;
    public AudioSource audioSource;
    public Transform parent;
    public List<GameObject> useList, disList;
    public GameObject bullet;
    private PlayerCondition playerCondition;
    private BulletController bulletController;

    private void Start()
    {
        fairyController = GetComponent<FairyController>();
        playerCondition = GameObject.Find("Player").GetComponent<PlayerCondition>();
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0) && time > frequency && fairyController.isPlayer && playerCondition.nowPower>cost)//输入、发射频率、是否获取精灵、法力值
        {
            time = 0;
            playerCondition.Power(cost);
            Get();
            audioSource.Play();
        }
    }

    private void FixedUpdate()
    {
        time += Time.fixedDeltaTime;
    }

    public void Get()//出池
    {
        if(disList.Count > 0)//正常出池
        {
            //取出
            disList[disList.Count - 1].SetActive(true);
            bulletController = disList[disList.Count - 1].GetComponent<BulletController>();
            //赋值
            bulletController.ATK = playerCondition.ATK;
            bulletController.startV3 = transform.position;
            bulletController.toV3 = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y, 0).normalized * speed + transform.position;
            bulletController.betweenV3 = transform.position + new Vector3(Random.Range(-1, 2), Random.Range(-1, 2), 0).normalized * r;
            //数组操作
            useList.Add(disList[disList.Count - 1]);
            disList.RemoveAt(disList.Count - 1);
        }
        else if(useList.Count + disList.Count < maxBullets)//补充
        {
            //新建实例
            var _bullet = Instantiate(bullet, parent);
            //赋值
            bulletController = _bullet.GetComponent<BulletController>();
            bulletController.bulletPool = this;
            bulletController.speed = speed;
            bulletController.startV3 = transform.position;
            bulletController.toV3 = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y, 0).normalized * speed + transform.position;
            bulletController.betweenV3 = transform.position + new Vector3(Random.Range(-1,2),Random.Range(-1,2), 0).normalized * r;
            //数组操作
            useList.Add(_bullet);
        }
    }

    public void Put(GameObject _gameObject)//入池
    {
        _gameObject.SetActive(false);
        useList.Remove(_gameObject);
        disList.Add(_gameObject);
    }
}
