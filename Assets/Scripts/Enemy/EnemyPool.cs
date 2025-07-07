using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    //父物体
    Transform parent;
    //预制体
    public GameObject Bat_1, Bat_2;
    //使用中
    public List<GameObject> useBat_1;
    public List<GameObject> useBat_2;
    //待机
    public List<GameObject> disBat_1;
    public List<GameObject> disBat_2;

    private void Start()
    {
        parent = GameObject.Find("Enemy").transform;
    }

    public void Get(string _kind,Transform _positon)
    {
        if (_kind == "Bat_1")
        {
            if(disBat_1.Count < 1)
            {
                var Enemy =  Instantiate(Bat_1, _positon.position, Quaternion.identity, parent);
                Enemy.GetComponent<EnemyCondition>().enemyPool = this;
                useBat_1.Add(Enemy);
            }
            else
            {
                useBat_1.Add(disBat_1[0]);
                disBat_1[0].SetActive(true);
                disBat_1[0].transform.position = _positon.position;
                disBat_1.RemoveAt(0);
            }
        }
        if (_kind == "Bat_2")
        {
            if (disBat_2.Count < 1)
            {
                var Enemy = Instantiate(Bat_2, _positon.position, Quaternion.identity, parent);
                useBat_2.Add(Enemy); 
                Enemy.GetComponent<EnemyCondition>().enemyPool = this;

            }
            else
            {
                useBat_2.Add(disBat_2[0]);
                disBat_2[0].SetActive(true);
                disBat_2[0].transform.position = _positon.position;
                disBat_2.RemoveAt(0);
            }
        }
    }

    public void Put(string _kind,GameObject _enemy)
    {
        _enemy.SetActive(false);
        if(_kind == "Bat_1")
        {
            useBat_1.Remove(_enemy);
            disBat_1.Add(_enemy);
        }
        if(_kind == "Bat_2")
        {
            useBat_2.Remove(_enemy);
            disBat_2.Add(_enemy);
        }
    }
}
