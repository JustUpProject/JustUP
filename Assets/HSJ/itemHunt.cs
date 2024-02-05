using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemHunt : Basic_Item
{
    private BasicControler player;

    private float huntTime = 5.0f;
    private float originMoveSpeed;

    [SerializeField] private float changedMoveSpeed = 2.5f;

    public bool usedHunt = false;

    private void Awake()
    {
        player = FindObjectOfType<BasicControler>();
        originMoveSpeed = player.moveSpeed;
    }

    private void Update()
    {
        useHunt();

        if (usedHunt)
        {
            huntTime -= Time.deltaTime;
        }

        if(huntTime < 0)
        {
            usedHunt = false;
            player.moveSpeed = originMoveSpeed;
        }
    }

    public void useHunt()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            usedHunt = true;
            huntTime = 5.0f;
            player.moveSpeed = changedMoveSpeed;
        }
    }
}
