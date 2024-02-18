using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverSceneManager : MonoBehaviour
{

    // Update is called once per frame
    public void StartMainBtn()
    {
        SceneManager.LoadScene("Title_Scenes_test");
    }
}
