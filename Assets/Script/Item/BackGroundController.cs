using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundController : MonoBehaviour
{
    [SerializeField] private GameObject Background;
    
    private void Update()
    {
        transform.position = new Vector3(0, (BasicControler.Instance.gameObject.transform.position.y / 5) + 3.0f, 0);
    }
}
