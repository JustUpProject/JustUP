using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Ice_Fin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("¾óÀ½ 2");
        BasicControler.Instance.IceAttach = true;
    }
    
}
