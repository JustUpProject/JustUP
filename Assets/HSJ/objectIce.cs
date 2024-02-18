using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class objectIce : MonoBehaviour
{
    [SerializeField] LayerMask Player;

    private float originSlide;
    private float originMoveSpeed;
    private float changeMoveSpeed;

    private void Start()
    {
        originSlide = BasicControler.Instance.slidingSpeed;
        originMoveSpeed = BasicControler.Instance.moveSpeed;
        changeMoveSpeed = BasicControler.Instance.moveSpeed*1.3f;
    }

    private void Update()
    {
        Vector2 vecL = this.transform.position;
        Vector2 directionL = Vector2.left;

        //RaycastHit2D[] hirs = Physics2D.BoxCastAll(vecL, directionL);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
           if (BasicControler.Instance.ObjectCheck() == 2)
            {
                BasicControler.Instance.moveSpeed =changeMoveSpeed;
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
