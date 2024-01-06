using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemSmite : MonoBehaviour
{
    BasicControler player;
    [SerializeField] private float jumpPower = 5f; // Á¡ÇÁ Èû Á¶Àý
    private void Awake()
    {
        player = FindObjectOfType<BasicControler>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.GetComponent<Rigidbody2D>().velocity = new Vector3(0, jumpPower, 0);
        }
        Destroy(this.gameObject);
    }
}
