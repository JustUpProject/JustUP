using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using stateSheild;

namespace stateSheild
{
    public enum StatShield
    {
        ready,
        broken,
        unable
    }
}

public class itemShield : Basic_Item
{
    public StatShield shield;

    private SpriteRenderer spriteRenderer;
    private GameObject shieldEffect;

    public float timer;

    private void Awake()
    {
        shieldEffect = GameObject.FindWithTag("shieldEffect");
        spriteRenderer = shieldEffect.GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }

    protected override void Start()
    {
        itemCode = 0;
        gameData = Resources.Load<GameData>("ScriptableObject/Datas");
    }

    private void Update()
    {
        UseSkill();
    }

    public override void UseSkill()
    {
        switch(shield)
        {
            case StatShield.ready:

                if (Input.GetKeyUp(KeyCode.I))
                {
                    timer = 3.0f;
                    spriteRenderer.enabled = true;
                    Debug.Log(shield);
                    shield = StatShield.broken;
                }
                break;

            case StatShield.broken:

                if( timer <3.0f && timer >= 1.0f)
                {
                    timer -= Time.deltaTime;
                }
                else if (timer<1.0f &&timer>0f)
                {
                    spriteRenderer.enabled = !(spriteRenderer.enabled);
                    timer -= Time.deltaTime;
                }
                else
                    shield = StatShield.unable;
                break;

            case StatShield.unable:

                spriteRenderer.enabled = false;
                shield = StatShield.ready;

                break;

            default:
                Debug.LogError("Unexpected value for smite enum: " + shield);
                break;
        }
    }
}