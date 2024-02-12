using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class object_wind_sub : MonoBehaviour
{
    public bool windDir; //WindDir : true is up windDir : false is down

    private BoxCollider2D windCollider;
    private BasicControler player;
    private Rigidbody2D playerRb;

    private Vector3 targetPos;

    private float moveSpeed;

    private void Awake()
    {
        windCollider = gameObject.AddComponent<BoxCollider2D>();
        windCollider.enabled = true;
        windCollider.size = new Vector2(0.2f, 0.9f);
        windCollider.isTrigger = true;

        if (windDir)
        {
            windCollider.offset = new Vector2(0, -0.05f);
            targetPos = new Vector3(transform.position.x, transform.position.y + transform.localScale.y / 2, transform.position.z);
        }
        else
        {
            windCollider.offset = new Vector2(0, 0.05f);
            targetPos = new Vector3(transform.position.x, transform.position.y - transform.localScale.y / 2, transform.position.z);
        }
    }

    private void Update()
    {
        Debug.Log(targetPos.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = BasicControler.Instance;
            StartCoroutine(MoveToPositionCoroutine(targetPos, player));
        }
    }

    IEnumerator MoveToPositionCoroutine(Vector3 targetPosition, BasicControler player)
    {
        float elapsedTime = 0f;
        Vector3 startingPosition = player.transform.position;
        moveSpeed = player.moveSpeed;

        while (elapsedTime < 2f)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Mathf.Abs(player.transform.position.y - targetPos.y) < 0.3f)
            {
                player.GetComponent<Rigidbody2D>().velocity = Vector3.up;
                yield break; // 코루틴 종료
            }

            player.transform.position = Vector2.MoveTowards(startingPosition, targetPosition, elapsedTime * moveSpeed);
            elapsedTime += Time.deltaTime;
            yield return null; // 한 프레임 기다림
        }
    }
}
