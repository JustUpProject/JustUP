using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_blinking_board : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;
    private float timeInterval = 5f; //5초 간격으로 나타남과 사라짐
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); 
        boxCollider = GetComponent<BoxCollider2D>(); 
        StartCoroutine(BoardObjectBlink());
    }

    // Update is called once per frame
    void Update()
    {

    }
    private IEnumerator BoardObjectBlink()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeInterval);

            // 오브젝트의 활성화 상태를 반전시킵니다.
            spriteRenderer.enabled = !(spriteRenderer.enabled); // 오브젝트 껐다 킴
            boxCollider.enabled = !(boxCollider.enabled); //콜라이더 껐다 킴
        }
    }
}
