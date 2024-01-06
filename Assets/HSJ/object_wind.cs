using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class object_wind : MonoBehaviour
{
    private BasicControler player;
    private Rigidbody2D playerRb;
    private float moveSpeed;
    private Vector3 targetedPos;
    private Vector3 playerPos;
    private float scale;

    public bool canMoved = false;

    // Start is called before the first frame update
    private void Awake()
    {
        player = FindObjectOfType<BasicControler>();
        playerRb = player.GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        canMoved = false;
        moveSpeed = player.moveSpeed;
        scale = transform.localScale.y / 2f;
        targetedPos = new Vector3(transform.position.x, transform.position.y + (scale), transform.position.z);
    }
    private void Update()
    {
        playerPos = transform.position;
    }

    private void FixedUpdate()
    {
        if (canMoved)
        {
            MoveToPosition(targetedPos);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canMoved = true;
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canMoved = false;
        }
    }

    public void MoveToPosition(Vector3 targetPosition)
    {
        StartCoroutine(MoveToPositionCoroutine(targetPosition));
    }

    IEnumerator MoveToPositionCoroutine(Vector3 targetPosition)
    {
        float elapsedTime = 0f;
        Vector3 startingPosition = player.transform.position;

        while (elapsedTime < 1f)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                yield break; // 코루틴 종료
            }

            player.transform.position = Vector3.Lerp(startingPosition, targetPosition, elapsedTime);
            elapsedTime += Time.deltaTime * moveSpeed / 2;
            yield return null; // 한 프레임 기다림
        }

        playerRb.AddForceAtPosition(new Vector2(0, 130), targetPosition);
    }
}