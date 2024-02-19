using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.UI.Image;

public class objectIce : MonoBehaviour
{
    [SerializeField] LayerMask Player;
    private Mesh IceMesh;
    Vector2 objectPos;
    Vector2 size;
    Vector2 dir;
    LayerMask playerMask;

    private float distance;
    private float originSlide;
    private float originMoveSpeed;
    private float changeMoveSpeed;

    private void Start()
    {
        objectPos = transform.position;
        size = transform.localScale*1.3f;
        distance = 1f;
        playerMask = LayerMask.GetMask("Player");

        originSlide = BasicControler.Instance.slidingSpeed;
        originMoveSpeed = BasicControler.Instance.moveSpeed;
        changeMoveSpeed = BasicControler.Instance.moveSpeed*1.3f;
    }

    private void Update()
    {
        if (BasicControler.Instance.transform.position.x < this.gameObject.transform.position.x)
        {
            dir = Vector2.left;
        }
        else if (BasicControler.Instance.transform.position.x > this.gameObject.transform.position.x)
        {
            dir = Vector2.right;
        }

        RaycastHit2D[] hits = Physics2D.BoxCastAll(objectPos, size, 0f, dir, distance, playerMask);

        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider.CompareTag("Player"))
            {
                if (BasicControler.Instance.isSlidingOnWall==true)
                    BasicControler.Instance.slidingSpeed = 10f;
                else
                    BasicControler.Instance.slidingSpeed = originSlide;
            }
        }
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
           if (BasicControler.Instance.ObjectCheck() == 2)
            {
                BasicControler.Instance.moveSpeed = changeMoveSpeed;
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            BasicControler.Instance.moveSpeed = originMoveSpeed;
        }
    }
}
