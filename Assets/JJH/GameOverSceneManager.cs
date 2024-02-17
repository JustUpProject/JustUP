using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverSceneManager : MonoBehaviour
{

    // Update is called once per frame
    public void StartMainBtn()
    {
        SceneManager.LoadScene("Sangjin_Scene");
    }
}
