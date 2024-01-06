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
            Debug.Log(resetting);
            resetting = true;
            Time.timeScale = 0f;
            setting.SetActive(true);
            
        }

        else if(resetting == true)
        {
            Debug.Log("1");
            resetting = false;
            Time.timeScale = 1.0f;
            setting.SetActive(false);         
        }
 
    }

}
