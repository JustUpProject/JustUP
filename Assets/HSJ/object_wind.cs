using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class object_wind : MonoBehaviour
{
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private int objectSize;
    BasicControler player;

    private float   objectMove;
    private float   theta;
    private float   lowJumpPower;
    private float    originJumpPower;

    public float rayLength;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<BasicControler>();

        objectMove =    player.moveSpeed;

        lowJumpPower = player.jumpPower*0.6f;
        originJumpPower = player.jumpPower;

        //theta = transform.rotation.eulerAngles.z;
        theta = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCheck() == true) 
        {
            Debug.Log("TTT");
            player.GetComponent<Rigidbody2D>().velocity = new Vector3(Mathf.Cos(theta)*player.transform.position.x, Mathf.Sin(theta)*player.transform.position.y, 0);
        }

        else 
        {
            Debug.Log("FFFFFF");
        }
    }

    private bool playerCheck() 
    {
        Vector2 origin = this.transform.position + new Vector3(0, objectSize/2, 0);
        Vector2 direction = Vector2.down;
        Vector2 size = new Vector2 (0.5f, 1.5f);
        

        RaycastHit2D[] hits = Physics2D.BoxCastAll(origin,size,theta,direction,playerMask);
        //RaycastHit2D[] hits = Physics2D.RaycastAll(origin,direction, 3.0f ,playerMask);

        foreach (RaycastHit2D hit in hits)
            if (hit.collider.CompareTag("Player"))
            {
               
                player.jumpPower = lowJumpPower;
                return true;
            }
        player.jumpPower = originJumpPower;
        return false;



    }

    //private void OnDrawGizmos()
    //{
    //    Vector2 origin = this.transform.position + new Vector3(0, objectSize / 2, 0);
    //    Vector2 direction = Vector2.down;
    //    Vector2 size = new Vector2(origin.x, origin.y);
    //    Gizmos.color = Color.red;

    //    RaycastHit2D[] hits = Physics2D.BoxCastAll(origin, size, theta, direction, playerMask);

    //    foreach (RaycastHit2D hit in hits)
    //    {

    //        Gizmos.DrawRay(hit.point, hit.normal);
    //    }
    //}

}
