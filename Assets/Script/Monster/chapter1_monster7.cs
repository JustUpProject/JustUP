using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chapter1_monster7 : MonoBehaviour
{
    public float upwardSpeed = 2.0f;
    public float downwardSpeed = 4.0f;

    private bool movingUp = true;
    private BasicControler player;

    void Start()
    {
        player = FindObjectOfType<BasicControler>();
    }

    private void Update()
    {
        float movement = (movingUp) ? upwardSpeed : -downwardSpeed;
        Vector3 currentPosition = transform.position;
        float newPositionY = currentPosition.y + movement * Time.deltaTime;

        newPositionY = Mathf.Clamp(newPositionY, -2.0f, 2.0f);

        transform.position = new Vector3(currentPosition.x, newPositionY, currentPosition.z);

        if (newPositionY >= 2.0f || newPositionY <= -2.0f)
        {
            movingUp = !movingUp;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            player.PlayerHit();
        }
    }
}