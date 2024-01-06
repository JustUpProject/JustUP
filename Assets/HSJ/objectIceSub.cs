using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class objectIceSub : MonoBehaviour
{
    [SerializeField] private LayerMask playerMask;
    private BasicControler player;
    private BoxCollider2D colliderUp;
    private BoxCollider2D colliderLeft;
    private BoxCollider2D colliderRight;
    private Transform childrenScale;

    private float originSlide;
    private float changedSlide;
    private float moveSpeedPlayer;
    private float changedMoveSpeed;
    private float childrenXscale;
    private float childrenYscale;

    public bool rChecker;
    public bool lChecker;
    public bool upChecker;

    private void Awake()
    {
        player = FindObjectOfType<BasicControler>();
        if(player == null )
            player = GetComponent<BasicControler>();

        colliderLeft = gameObject.AddComponent<BoxCollider2D>();
        colliderRight = gameObject.AddComponent<BoxCollider2D>();
        colliderUp = gameObject.AddComponent<BoxCollider2D>();

        childrenScale = this.gameObject.transform.GetChild(0).GetComponent<Transform>();
    }

    void Start()
    {
        
        childrenXscale = childrenScale.transform.localScale.x;
        childrenYscale = childrenScale.transform.localScale.y;

        colliderUp.size = new Vector2(childrenXscale, childrenYscale);
        colliderUp.offset = new Vector2(0,0.02f);
        colliderUp.isTrigger = true;

        colliderLeft.size = new Vector2(childrenXscale*0.3f,childrenYscale);
        colliderLeft.offset = new Vector2(-0.5f,0f);
        colliderLeft.isTrigger = true;

        colliderRight.size = new Vector2(childrenXscale*0.3f, childrenYscale);
        colliderRight.offset = new Vector2(0.5f,0f);
        colliderRight.isTrigger = true;

        colliderLeft.enabled = false;
        colliderRight.enabled = false;
        colliderUp.enabled = false;

        if (rChecker)
            colliderRight.enabled = true;
        if(lChecker) 
            colliderLeft.enabled = true;
        if(upChecker) 
            colliderUp.enabled = true;

        originSlide = player.slidingSpeed;
        changedSlide = 1.0f;
        moveSpeedPlayer = player.moveSpeed;
        changedMoveSpeed = player.moveSpeed + 1f;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            if(collision.transform.position.x < this.gameObject.transform.position.x || 
                collision.transform.position.x > this.gameObject.transform.position.x)
            {
                player.WallCheck();
                player.slidingSpeed = changedSlide;
            }
            if(collision.transform.position.y > this.gameObject.transform.position.y) 
            {
                player.moveSpeed = changedMoveSpeed;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.slidingSpeed = originSlide;
            player.moveSpeed = moveSpeedPlayer;
        }
    }
}