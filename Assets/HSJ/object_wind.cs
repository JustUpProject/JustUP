using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class object_wind : MonoBehaviour
{
    [SerializeField] private LayerMask playerMask;
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

        theta = transform.rotation.eulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCheck() == true) 
        {
            player.GetComponent<Rigidbody>().velocity += new Vector3(Mathf.Cos(theta)*player.transform.position.x,Mathf.Sin(theta)*player.transform.position.y,0);
        }
        else 
        {
            Debug.Log("FFFFFF");
        }
    }

    private bool playerCheck() 
    {
        Vector2 origin = this.transform.position;
        Vector2 direction = Vector2.right;
        Vector2 size = new Vector2 (origin.x, origin.y);
        
        RaycastHit2D[] hits = Physics2D.BoxCastAll(origin,size,theta,direction,playerMask);

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
