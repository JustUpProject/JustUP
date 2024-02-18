using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class go_select_scene : MonoBehaviour
{
    public void SceneChange()
    {
        Time.timeScale = 1.0f;
        Item_Controller.Instance.gameData.Inventory[0] = 63;
        Item_Controller.Instance.gameData.Inventory[1] = 63;
        Item_Controller.Instance.gameData.Inventory[2] = 63;
        Item_Controller.Instance.gameData.SavePoint = new Vector3(0, -3.0f, 0);
        SceneManager.LoadScene("Main_Map");
    }
}
