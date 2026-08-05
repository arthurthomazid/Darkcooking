using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string Fase1;
    public void changeScene()
    {
        SceneManager.LoadScene(Fase1);
    }
}
