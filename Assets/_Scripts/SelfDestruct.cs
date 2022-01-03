using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    void Start()
    {
        Invoke("Destruct", 5.5f);
    }

    private void Destruct()
    {
        this.transform.parent = null; 
        Destroy(this.gameObject);
    }

}
