using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chapter1_monster7 : MonoBehaviour
{
    public float moveSpeed = 2.0f;

    private void Update()
    {
        float movement = Mathf.PingPong(Time.time * moveSpeed, 4f) - 2f;
        Vector3 currentPosition = transform.position;
        float newPositionY = currentPosition.y + movement * Time.deltaTime;
        transform.position = new Vector3(currentPosition.x, newPositionY, currentPosition.z);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player collided with the chapter1_monster7!");
        }
    }
}
