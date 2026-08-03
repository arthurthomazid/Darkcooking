using UnityEngine;
using UnityEngine.SceneManagement;

public class ReiniciarJogo : MonoBehaviour
{
    public void NovoJogo()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();

        SceneManager.LoadScene("Area inicial");
    }
}
