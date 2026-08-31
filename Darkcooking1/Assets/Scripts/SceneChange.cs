using UnityEngine;
using UnityEngine.SceneManagement;

public class JogoAFaseSceneChanger : MonoBehaviour
{
    public string game;
    public void changeScene()
    {
        if (SaveManager.Instance.TodosUpgradesDesbloqueados())
        {
            SceneManager.LoadScene("FaseBoss");
        }
        else
        {
            SceneManager.LoadScene("game");
        }
    }
}
