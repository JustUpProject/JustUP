using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chapter1_monster7 : MonoBehaviour
{
    private Vector3 startPos;
    public float upwardSpeed = 2.0f;
    public float downwardSpeed = 4.0f;
    [SerializeField] private float arrange = 3.0f;

    private bool movingUp = true;
    private BasicControler player;

    void Start()
    {
        player = FindObjectOfType<BasicControler>();
        startPos = transform.position;
    }

    private void Update()
    {
        float movement = (movingUp) ? upwardSpeed : -downwardSpeed;
        Vector3 currentPosition = transform.position;
        float newPositionY = currentPosition.y + movement * Time.deltaTime;

        newPositionY = Mathf.Clamp(newPositionY, startPos.y -arrange, startPos.y +arrange);

        transform.position = new Vector3(currentPosition.x, newPositionY, currentPosition.z);

        if (newPositionY >= startPos.y + arrange || newPositionY <= startPos.y - arrange)
        {
            movingUp = !movingUp;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            player.PlayerHit(gameObject.tag);
        }
    }
}