using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Skip_Button : MonoBehaviour
{
    public void Skip()
    {
        Item_Controller.Instance.gameData.Inventory[0] = 63;
        Item_Controller.Instance.gameData.Inventory[1] = 63;
        Item_Controller.Instance.gameData.Inventory[2] = 63;
        Item_Controller.Instance.gameData.SavePoint = new Vector3(0, -3, 0);
        BasicControler.Instance.ResetPos();
        BasicControler.Instance.PlayerHealth = 3;
        if (BasicControler.Instance.transform.localScale.x < 0)
            BasicControler.Instance.transform.localScale = new Vector3(BasicControler.Instance.transform.localScale.x * -1, BasicControler.Instance.transform.localScale.y, BasicControler.Instance.transform.localScale.z);

        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Main_Map");
    }
}