using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateButton : MonoBehaviour
{
    public void Skip()
    {

        BasicControler.Instance.PlayerHealth = 3;
        if (BasicControler.Instance.transform.localScale.x < 0)
            BasicControler.Instance.transform.localScale = new Vector3(BasicControler.Instance.transform.localScale.x * -1, BasicControler.Instance.transform.localScale.y, BasicControler.Instance.transform.localScale.z);

        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Main_Map");
    }
}