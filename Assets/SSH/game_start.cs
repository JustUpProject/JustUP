using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class game_start : MonoBehaviour
{
    public void StartBtn()
    {
        SceneManager.LoadScene("Main_Map");
    }
}
