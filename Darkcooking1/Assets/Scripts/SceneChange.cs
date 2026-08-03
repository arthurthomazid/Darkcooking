using UnityEngine;
using UnityEngine.SceneManagement;

public class JogoAFaseSceneChanger : MonoBehaviour
{
    public string game;
    public void changeScene()
    {
        SceneManager.LoadScene("Fase 1");
    }
}
