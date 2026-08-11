using UnityEngine;
using UnityEngine.SceneManagement;

public class PassarDeFase : MonoBehaviour
{
    public string Fase2;
    public void changeScene()
    {
        SceneManager.LoadScene(Fase2);
    }
}