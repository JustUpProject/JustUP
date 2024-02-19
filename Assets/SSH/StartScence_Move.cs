using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScence_Move : MonoBehaviour
{
    public void SceneChange()
    {
        Time.timeScale = 1.0f;

        SceneManager.LoadScene("Title_Scenes_test");
    }
}
