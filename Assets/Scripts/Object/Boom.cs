using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    void Start()
    {
        Invoke("Destroy", 0.3f);
    }

    private void Destroy()
    {
        DestroyImmediate(gameObject);
    }
}
