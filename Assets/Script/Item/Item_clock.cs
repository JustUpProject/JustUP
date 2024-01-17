using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeControl : MonoBehaviour
{
    private float originalTime;
    private bool Slowed = false;

    private void Start()
    {
        originalTime = Time.timeScale;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            if (Slowed == false)
            {
                Time.timeScale = 0.2f;
                Slowed = true;
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
