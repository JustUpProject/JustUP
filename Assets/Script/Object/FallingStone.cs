using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingStone : MonoBehaviour
{
    BasicControler player;

    private bool falling = false;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<BasicControler>();
    }

    // Update is called once per frame
    void Update()
    {
        FallingCheck();
        if (falling)
        {
            Falling();
        }
    }

    private void FallingCheck()
    {
        Vector2 origin = transform.position + new Vector3(0, -0.3f, 0);
        Vector2 direction = Vector2.down;

        RaycastHit2D hit = Physics2D.Raycast(origin, direction);


        if (hit.collider.CompareTag("Player"))
        {
            falling = true;
        }
    }

    private void Falling()
    {
        Rigidbody2D drop = GetComponent<Rigidbody2D>();
        drop.gravityScale = 1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            player.PlayerHit();
        }
        Destroy(gameObject);

    }
}
