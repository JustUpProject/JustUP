using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_clock: Basic_Item
{
    private float originalTime;
    private bool Slowed = false;

    protected override void Start()
    {
        itemCode = 6;
        gameData = Resources.Load<GameData>("ScriptableObject/Datas");

        originalTime = Time.timeScale;
    }
    private void Update()
    {
        UseSkill();
    }

    public override void UseSkill()
    {
        if (Input.GetKeyUp(KeyCode.I)) 
        { 
            if(!Slowed)
            {
                Time.timeScale = 0.2f;
                Slowed=false;
                StartCoroutine(ReturnToOriginalTimeScale());
            }
        }
    }

    private IEnumerator ReturnToOriginalTimeScale()
    {
        yield return new WaitForSeconds(1.5f);
        Time.timeScale = originalTime;
        Slowed = false;
    }
}
