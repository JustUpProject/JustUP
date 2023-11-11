using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class object_breaking_board : MonoBehaviour
{
    BasicControler player;

    SpriteRenderer spriteRenderer;

    BoxCollider2D boxCollider2D;


    // 발판이 무너지는지 여부를 나타내는 bool 변수를 선언합니다.
    bool isBroken = false;

    // 발판이 무너지는 타이머를 선언합니다.
    float timer = 0f;

    private void Start()
    {
        player = FindObjectOfType<BasicControler>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }
    // 발판이 생성될 때 호출되는 함수입니다.
    void OnEnable()
    {
        // 발판이 무너지지 않도록 설정합니다.
        isBroken = false;
        spriteRenderer.enabled = true;
        boxCollider2D.enabled = true;
        // 발판이 무너지는 타이머를 시작합니다.
        timer = 0f;
    }

    // 플레이어가 발판을 밟을 때 호출되는 함수입니다.
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player")) 
        {
            isBroken = true;

            timer = 1f;
        }
    }
    // Update 함수입니다.
    void Update()
    {
        // 발판이 무너지도록 설정되어 있다면
        if (isBroken)
        {
            // 타이머를 증가시킵니다.
            timer += Time.deltaTime;

            // 타이머가 1초가 지나면
            if (timer >= 2f)
            {
                // 발판을 제거합니다.
                spriteRenderer.enabled = false;
                boxCollider2D.enabled = false;                              
                
            }

            if (timer >= 7f)
            {
                // 발판을 재생성합니다.
                spriteRenderer.enabled = true;
                boxCollider2D.enabled = true;
                // 발판이 무너지지 않도록 설정합니다.
                isBroken = false;
                // 발판이 재생성될 때까지 5초 동안 대기합니다.
                timer = 0f;

            }
        }
    }
}
