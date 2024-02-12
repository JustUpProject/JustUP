using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_fog : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private bool IsFade = true;
    [SerializeField] private float time;
    void Start()
    {
        //오브젝트 처음에 비활성화
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(FadeIn());
        
    }

    IEnumerator FadeIn()
    {
        while (true)
        {
            yield return new WaitForSeconds(time);

            if (IsFade == true)
            {
                Debug.Log("ffffffff");
                Debug.Log(spriteRenderer.color);
                spriteRenderer.color -= new Color(0, 0, 0, 0.01f);
            }

            else
            {
                Debug.Log("ddddd");
                Debug.Log(spriteRenderer.color);
                spriteRenderer.color += new Color(0, 0, 0, 0.01f);
            }
            if (spriteRenderer.color.a <= 0)
            {
                IsFade = !IsFade;
                yield return new WaitForSeconds(3);
            }

            else if(spriteRenderer.color.a >= 1)
            {
                IsFade = !IsFade;
                StartCoroutine(FadeOut());
                break;
            }
        }

        yield return null;
    }

    IEnumerator FadeOut() 
    {
        
        yield return new WaitForSeconds(3);
        StartCoroutine(FadeIn());
    }
}
