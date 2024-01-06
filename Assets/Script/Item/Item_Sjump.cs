using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Sjump : MonoBehaviour
{
    [SerializeField] private float jumpPower = 10f;
    BasicControler player;
    
    private void Start()
    {
        player = FindObjectOfType<BasicControler>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player.GetComponent<Rigidbody2D>().velocity = new Vector3(0, jumpPower, 0);
        }
    }
}
