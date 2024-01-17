using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class itemShield : Basic_Item
{
    private SpriteRenderer spriteRenderer;
    private GameObject shieldEffect;
    private float timer = 0f;
    private int numOfUses;

    public bool isShield = false;
    public bool onShield = false;

    private void Awake()
    {
        shieldEffect = GameObject.FindWithTag("shieldEffect");
        spriteRenderer = shieldEffect.GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        spriteRenderer.enabled = false;
        numOfUses = 3;  
    }

    private void Update()
    {

        if(Input.GetKeyDown(KeyCode.O)) //basic코드 바뀌면 변경예정부분
        {
            if(isShield && numOfUses>0)
            {
                useShield();
                numOfUses -= 1;
            }
        }

        if (onShield)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spriteRenderer.enabled = false;
        }

        if(timer > 3f && timer < 5f) 
        {
            spriteRenderer.enabled  = !spriteRenderer.enabled;
        }
        if (timer > 5f)
        {
            onShield = false;
        }
    }

    private void useShield()
    {
        timer = 0f;
        onShield = true;
        spriteRenderer.enabled = true;
    }
}