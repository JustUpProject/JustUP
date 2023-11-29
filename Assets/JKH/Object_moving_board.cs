using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_moving_board : MonoBehaviour
{
    public float moveSpeed = 2f;

    // Update is called once per frame
    void Update()
    {
        float movement = Mathf.PingPong(Time.time * moveSpeed, 4f) - 2f;

        Vector3 currentPosition = transform.position;

        float newPositionX = currentPosition.x + movement * Time.deltaTime;

        transform.position = new Vector3(newPositionX, currentPosition.y, currentPosition.z);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // 발판과 충돌한 객체가 플레이어인 경우에 수행할 작업 추가
            Debug.Log("Player collided with the moving board!");
        }
    }
}
