using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class object_breaking_board : MonoBehaviour
{
    BasicControler player;

    SpriteRenderer spriteRenderer;

    BoxCollider2D boxCollider2D;


    // ������ ���������� ���θ� ��Ÿ���� bool ������ �����մϴ�.
    bool isBroken = false;

    // ������ �������� Ÿ�̸Ӹ� �����մϴ�.
    float timer = 0f;

    private void Start()
    {
        player = FindObjectOfType<BasicControler>();
        spriteRenderer = FindObjectOfType<SpriteRenderer>();
        boxCollider2D = FindObjectOfType<BoxCollider2D>();
    }
    // ������ ������ �� ȣ��Ǵ� �Լ��Դϴ�.
    void OnEnable()
    {
        // ������ �������� �ʵ��� �����մϴ�.
        isBroken = false;
        spriteRenderer.enabled = true;
        boxCollider2D.enabled = true;
        // ������ �������� Ÿ�̸Ӹ� �����մϴ�.
        timer = 0f;
    }

    // �÷��̾ ������ ���� �� ȣ��Ǵ� �Լ��Դϴ�.
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player")) 
        {
            isBroken = true;

            timer = 1f;
        }
    }
    // Update �Լ��Դϴ�.
    void Update()
    {
        // ������ ���������� �����Ǿ� �ִٸ�
        if (isBroken)
        {
            // Ÿ�̸Ӹ� ������ŵ�ϴ�.
            timer += Time.deltaTime;

            // Ÿ�̸Ӱ� 1�ʰ� ������
            if (timer >= 2f)
            {
                // ������ �����մϴ�.
                spriteRenderer.enabled = false;
                boxCollider2D.enabled = false;                              
                
            }

            if (timer >= 7f)
            {
                // ������ ������մϴ�.
                spriteRenderer.enabled = true;
                boxCollider2D.enabled = true;
                // ������ �������� �ʵ��� �����մϴ�.
                isBroken = false;
                // ������ ������� ������ 5�� ���� ����մϴ�.
                timer = 0f;

            }
        }
    }
}
