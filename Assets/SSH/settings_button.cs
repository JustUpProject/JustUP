using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class settings_button : MonoBehaviour
{
    public GameObject settingbutton;
    public GameObject setting;
    private bool resetting;

    // Start is called before the first frame update
    void Start()
    {
        resetting = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void buttonOn()
    {
        if (resetting == false)
        {
            resetting = true;
            setting.SetActive(true);
            Time.timeScale = 0f;
        }

        else
        {
            resetting = false;
            setting.SetActive(false);
            Time.timeScale = 1.0f;
        }
 
    }

}
