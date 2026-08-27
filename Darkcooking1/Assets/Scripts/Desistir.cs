using UnityEngine;

public class Desistir : MonoBehaviour
{
    public void desistir()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();

        Application.Quit();
        Debug.Log("saindo");
    }
}
