using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float jumpPower = 10f; // 점프 힘 조절
    BasicControler player;

    private void Start()
    {
        player = FindObjectOfType<BasicControler>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("충돌");
        if (other.CompareTag("Player")) // 캐릭터와의 충돌 감지
        {
            player.GetComponent<Rigidbody2D>().velocity = new Vector3(0, jumpPower, 0);
        }
    }
}