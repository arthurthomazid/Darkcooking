using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string fase;
    public void changeScene()
    {
        SceneManager.LoadScene(fase);
    }
}
