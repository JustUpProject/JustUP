using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject left;
    public GameObject right;
    BasicControler player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<BasicControler>();
    }

    // Update is called once per frame
    void Update()
    {
        player.transform.position = left.transform.position;
    }
}
