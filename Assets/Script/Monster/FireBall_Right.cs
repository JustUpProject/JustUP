
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class FireBall_Right : MonoBehaviour
{
    BasicControler player;
    chapter_monster5_Right monster_right;
    Rigidbody2D fireBallRig;
    [SerializeField] private float speed;
    private bool direction; // right == 1, left == 0

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<BasicControler>();
        monster_right = FindObjectOfType<chapter_monster5_Right>();
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

        transform.rotation = new Quaternion(0, 180, 0, 0);
        transform.position += new Vector3(Time.deltaTime * speed, 0, 0);

    }
}