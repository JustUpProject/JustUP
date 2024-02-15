using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] private float jumpPower = 10f; // Á¡ÇÁ Èû Á¶Àý
    BasicControler player;
    Rigidbody2D playerRig;

    private void Start()
    {
        player = FindObjectOfType<BasicControler>();
        playerRig = player.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            BasicControler.Instance.GetComponent<Rigidbody2D>().velocity = new Vector2(playerRig.velocity.x, jumpPower);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
           
                BasicControler.Instance.SetDir();
                if (BasicControler.Instance.getPrivateDir() == true)
                {
                    player.transform.rotation = new Quaternion(0, 180, 0, 0);
                }
                else
                {
                    player.transform.rotation = new Quaternion(0, 0, 0, 0);
                }
        }
    }

}