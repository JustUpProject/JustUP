using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using stateSheild;

namespace stateSheild
{
    public enum StatShield
    {
        ready,// 아이템 사용전
        broken,// 아이템 사용중
        unable // 아이템 사용끝
    }
}

public class itemShield : MonoBehaviour
{
    public StatShield shield;

    private SpriteRenderer effectPrefab;
    public bool UseItem = true;
    public float time;


    private void Update()
    {
        
        
    }

    void initShield()
    {
        shield = StatShield.ready;
        effectPrefab = BasicControler.Instance.transform.Find("Circle").gameObject.GetComponent<SpriteRenderer>();
        if (effectPrefab == null)
            Debug.Log("못찾음");
    }
    
    public void UseSkill()
    {
        initShield();
        Debug.Log("쉴드1");

        StartCoroutine(Useing());
        
    }

    IEnumerator Useing()
    {
        effectPrefab.enabled = true;
        shield = StatShield.broken;
        yield return new WaitForSeconds(3.0f);
        
        if(UseItem == false)
        {
            yield return null;
        }

        effectPrefab.enabled = !(effectPrefab.enabled);
        shield = StatShield.unable;

        effectPrefab.enabled = false;
        shield = StatShield.ready;
        
        yield return null;
    }

    //switch (shield)
    //{

    //    case StatShield.ready:  //아이템 사용전 초기화된 변수를 사용시간등에 맞춰 설정

    //        init();

    //        timer = 3.0f;
    //        effectPrefab.enabled = true;
    //        Debug.Log(shield);
    //        shield = StatShield.broken;

    //        break;

    //    case StatShield.broken:  //아이템 사용중 : 사용중 변화에 맞게 변수를 설정

    //        if (timer < 3.0f && timer >= 1.0f)
    //        {
    //            timer -= Time.deltaTime;
    //        }
    //        else if (timer < 1.0f && timer > 0f)
    //        {
    //            effectPrefab.enabled = !(effectPrefab.enabled);
    //            timer -= Time.deltaTime;
    //        }
    //        else
    //            shield = StatShield.unable;
    //        break;

    //    case StatShield.unable:  //아이템 사용끝 : 사용전 필요한 변수들을 초기화 및 사이클로 돌아감

    //        effectPrefab.enabled = false;
    //        shield = StatShield.ready;

    //        break;

    //    default:
    //        Debug.LogError("Unexpected value for smite enum: " + shield);
    //        break;
    //}
}