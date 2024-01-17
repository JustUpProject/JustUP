using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class go_main_screen : MonoBehaviour
{
    public void SceneChange()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Title_Scenes_test");
    }
}
