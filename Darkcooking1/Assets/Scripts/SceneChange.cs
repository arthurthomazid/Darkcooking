using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string game;
    public void changeScene()
    {
        SceneManager.LoadScene(game);
    }
}
