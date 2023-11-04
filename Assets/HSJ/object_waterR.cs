using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class object_waterR : MonoBehaviour
{
    BasicControler basicControler;
    private bool playerDir;
    private float variableSpeed;
    private float originSpeed;

    public GameObject player;
    public bool thisDir = false; //false = R -> L true = L -> R
    
    // Start is called before the first frame update
    void Start()
    {
        basicControler = player.GetComponent<BasicControler>();
        variableSpeed = basicControler.moveSpeed*0.5f;
        originSpeed = basicControler.moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        playerDir = basicControler.getPrivateDir();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (playerDir == thisDir)
            {
                basicControler.moveSpeed = basicControler.moveSpeed+variableSpeed;
                Debug.Log("fff");
            }
            else 
            {
                basicControler.moveSpeed -= variableSpeed;
                Debug.Log("slow");
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            basicControler.moveSpeed = originSpeed;
            Debug.Log(originSpeed);
        }
            
    }
}
