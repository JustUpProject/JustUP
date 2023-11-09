using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_fog : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    private float timeInterval = 3f; //3초 간격으로 나타남과 사라짐
    // Start is called before the first frame update
    void Start()
    {
        //오브젝트 처음에 비활성화
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(FogObjectBlink());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator FogObjectBlink()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeInterval);

            // 오브젝트의 활성화 상태를 반전시킵니다.
            spriteRenderer.enabled = !(spriteRenderer.enabled);
            
        }
    }
}
