using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class object_wind : MonoBehaviour
{
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private int objectSize;
    BasicControler player;
    Rigidbody2D playerRig;

    private float   theta;
    private float   basicTheta;
    private float   lowJumpPower;
    private float   originJumpPower;
    private Vector2 targetPos;
    private Vector3 objectForce;
    private bool checker;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<BasicControler>();
        playerRig = FindObjectOfType<Rigidbody2D>();
        
        lowJumpPower = player.jumpPower * 0.6f;
        originJumpPower = player.jumpPower;
        basicTheta = (1f*Mathf.PI) * Mathf.Rad2Deg;
        theta = (basicTheta - transform.rotation.eulerAngles.z)*Mathf.Deg2Rad;

        objectForce = new Vector3(Mathf.Cos(theta), Mathf.Sin(theta),0);
        targetPos = new Vector2(transform.position.x, transform.position.y + transform.localScale.y / 2);
       
        Debug.Log(basicTheta);
        Debug.Log(theta);
        Debug.Log(Mathf.Sin(theta));
    }

    // Update is called once per frame
    void Update()
    {
        checker = playerCheck();
        if (checker) 
        {
            playerRig.MovePosition(player.transform.position + objectForce * Time.deltaTime*5);
        }
    }

    public bool playerCheck()
    {
        Vector2 origin = this.transform.position + new Vector3(0, objectSize / 2, 0);
        Vector2 direction = Vector2.down;
        Vector2 size = transform.localScale;

        RaycastHit2D[] hits = Physics2D.BoxCastAll(origin, size, theta, direction, playerMask);

        foreach (RaycastHit2D hit in hits)
            if (hit.collider.CompareTag("Player"))
            {
                player.jumpPower = lowJumpPower;
                return true;
            }

        player.jumpPower = originJumpPower;
        return false;
    }
}
