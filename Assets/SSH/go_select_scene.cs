using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class go_select_scene : MonoBehaviour
{

    public void SceneChange()
    {
        if (BasicControler.Instance != null)
        {
            BasicControler.Instance.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            Resources.Load<GameData>("ScriptableObject/Datas").SavePoint = new Vector3(0, -3, 0);
        }

        Time.timeScale = 1.0f;
        
        SceneManager.LoadScene("Tutorial");
    }
}
