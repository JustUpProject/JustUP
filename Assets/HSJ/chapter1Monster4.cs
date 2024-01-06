using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class chapter1Monster4 : BasicMonster
{
    private BoxCollider2D colliderUP;
    private BoxCollider2D colliderDOWN;
    private BoxCollider2D colliderMonster;

    private Rigidbody2D rb;

    private Vector2 targetPosition;

    private int num = 0; // 1 = Up 0 = down
    private bool moveHorizontal = false;

    private void Awake()
    {
        colliderMonster = GetComponent<BoxCollider2D>();

        colliderUP = gameObject.AddComponent<BoxCollider2D>();
        colliderDOWN = gameObject.AddComponent<BoxCollider2D>();
        rb = FindObjectOfType<Rigidbody2D>();
    }

    private void Start()
    {
        colliderUP.size = new Vector2(0.2f, 3f);
        colliderUP.offset = new Vector2(0f, 1.5f);
        colliderUP.isTrigger = true;

        colliderDOWN.size = new Vector2(0.2f, 3f);
        colliderDOWN.offset = new Vector2(0f, -3.5f);
        colliderDOWN.isTrigger = true;

        colliderUP.enabled = false;
        colliderDOWN.enabled = false;
        targetPosition = Vector2.zero;
    }

    protected override void Update()
    { 
        if (moveHorizontal == false)
        {
            base.Update(); // Call the Update method of the base class
        }
    }
    private void FixedUpdate()
    {
        if(moveHorizontal==true)
        {
            moveToPosition(targetPosition);
        }
    }
    protected override void OnDirectionChanged()
    {
        base.OnDirectionChanged(); // Call the base class method
        setFloorChecker(); // Call MoveAlongFloor when direction changes
    }

    private void setFloorChecker()
    {
        num = Random.Range(0, 100);
        num = num % 2;

        if(num == 0)
        {
            colliderDOWN.enabled = true;
        } 
        else
        {
            colliderUP.enabled = true;
        }
    }

    private void moveToPosition(Vector2 targetPosition)
    {
        StartCoroutine(MoveToPositionCoroutine(targetPosition));
    }

    IEnumerator MoveToPositionCoroutine(Vector2 targetPosition)
    {
        float elapsedTime = 0f;
        rb.interpolation = RigidbodyInterpolation2D.Interpolate;
        colliderMonster.enabled = false;  //기존에 올라갈때 버벅이던 움직임을 고치기 위해 추가

        while (elapsedTime < 1f)
        {
            if(transform.position.y == targetPosition.y)
            {
                yield break;
            }
            rb.position = Vector2.MoveTowards(rb.position, targetPosition, Time.deltaTime/3);
            elapsedTime += Time.deltaTime;
            yield return null; // 한 프레임 기다림
        }

        rb.interpolation = RigidbodyInterpolation2D.None;
        colliderMonster.enabled = true;
        moveHorizontal = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Floor"))
        {
            targetPosition = new Vector2(rb.position.x, other.transform.position.y + (other.transform.localScale.y / 2) + (this.transform.localScale.y / 2));
            moveHorizontal = true;
            colliderUP.enabled = false;
            colliderDOWN.enabled = false;
        }
        
    }
}