using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class FireBall_Left : MonoBehaviour
{
    BasicControler player;
    chapter_monster5_Left monster_left;
    Rigidbody2D fireBallRig;
    [SerializeField] private float speed;
    private bool direction; // right == 1, left == 0

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<BasicControler>();
        monster_left = FindObjectOfType<chapter_monster5_Left>();
        fireBallRig = FindObjectOfType<Rigidbody2D>();
        fireBallRig.gravityScale = 0f;
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
            player.PlayerHit(gameObject.tag);
            Destroy(gameObject);
        }
        if (collision.collider.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }

    private void Move()
    {

        transform.position += new Vector3(Time.deltaTime * speed * -1, 0, 0);


    }
}
