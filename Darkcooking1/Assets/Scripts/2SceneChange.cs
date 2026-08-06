using UnityEngine;
using UnityEngine.SceneManagement;

public class JogoAFaseSceneChanger2 : MonoBehaviour
{
    public string game;
    public void changeScene()
    {
        SceneManager.LoadScene("Area inicial");
    }
}
