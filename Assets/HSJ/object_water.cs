using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class object_water : MonoBehaviour
{
    BasicControler player;
    private bool playerDir;
    private float variableSpeed;
    private float variableSpeedN; // 위 플로트와 반대값
    private float originSpeed;

    public bool thisDir = false; //false = R -> L true = L -> R
    
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<BasicControler>();
        variableSpeed = player.moveSpeed*1.5f;
        variableSpeedN = player.moveSpeed * 0.5f;
        originSpeed = player.moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        playerDir = player.getPrivateDir();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (playerDir == thisDir)
            {
                player.moveSpeed = variableSpeed;
            }
            else 
            {
                player.moveSpeed = variableSpeedN;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player.moveSpeed = originSpeed;
            Debug.Log(originSpeed);
        }
            
    }
}
