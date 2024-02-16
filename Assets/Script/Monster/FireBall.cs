using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class FireBall : MonoBehaviour
{
    BasicControler player;
    chapter_monster5 monster;
    Rigidbody2D fireBallRig;
    [SerializeField] private float speed;
    private bool direction; // right == 1, left == 0

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<BasicControler>();
        monster = FindObjectOfType<chapter_monster5>();
        fireBallRig = FindObjectOfType<Rigidbody2D>();
        fireBallRig.gravityScale = 0f;
        direction = monster.DirectionRight;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            player.PlayerHit();
            Destroy(gameObject);
        }
        if (collision.collider.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }

    private void Move()
    {
        if (direction)
        {
            transform.position += new Vector3(Time.deltaTime * speed * -1, 0, 0);

        }
        else
        {
            transform.rotation = new Quaternion(0, 180, 0, 0);
            transform.position += new Vector3(Time.deltaTime * speed, 0, 0);
        }
    }
}