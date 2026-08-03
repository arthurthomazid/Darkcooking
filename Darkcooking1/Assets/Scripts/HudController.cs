using UnityEngine;

public class HUDController : MonoBehaviour
{
    public GameObject hud;

    public void AbrirHUD()
    {
        hud.SetActive(true); // Mostra a HUD.
    }
}