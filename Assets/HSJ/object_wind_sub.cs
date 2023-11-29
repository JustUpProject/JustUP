using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class object_wind_sub : MonoBehaviour
{
    BasicControler player;
    float moveSpeed;
    Vector3 targetedPos;
    Vector3 playerPos;
    public bool canMoved = false;
    float scale;

    // Start is called before the first frame update
    void Start()
    {
        canMoved = false;
        player = FindObjectOfType<BasicControler>();
        moveSpeed = player.moveSpeed;
        scale = transform.localScale.y/2+0.3f;
        targetedPos = new Vector3(transform.position.x,transform.position.y+(scale),transform.position.z);
    }
    private void Update()
    {
        playerPos = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
            canMoved = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            MoveToPosition(targetedPos);
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

            if(targetPosition.y - playerPos.y < 0.5f) 
            {
                // 보간이 완료되면 최종 목표 위치로 설정 (최종 위치에 정확하게 맞추기 위해)
                player.transform.position = targetPosition;
                player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1);
                yield break;
            }

            player.transform.position = Vector3.Lerp(startingPosition, targetPosition, elapsedTime);
            elapsedTime += Time.deltaTime * moveSpeed;
            yield return null; // 한 프레임 기다림
        }
    }
}
