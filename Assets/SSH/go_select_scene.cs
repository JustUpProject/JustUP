using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class go_select_scene : MonoBehaviour
{
    public void SceneChange()
    {
        Time.timeScale = 1.0f;
        
        SceneManager.LoadScene("Tutorial");
    }
}
