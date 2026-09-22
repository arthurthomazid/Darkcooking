 using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Recipe2Menu : MonoBehaviour
{
    [Header("Botões")]
    public Button vidaExtraButton;

    [Header("Textos da Receita da sopa")]
    public TMP_Text textoBatata;
    public TMP_Text textoAbobora;

    public bool comprarVidaExtra;
    public GameObject painel;

    void OnEnable()
    {
        AtualizarReceitas();
    }

    public void AtualizarReceitas()
    {
        int batatas = SaveManager.Instance.GetQuantidade(TipoComida.Batata);
        int abobora = SaveManager.Instance.GetQuantidade(TipoComida.Abobora);

        textoBatata.text = $"Batatas:{batatas}/8";
        textoAbobora.text = $"Aboboras:{abobora}/8";

        vidaExtraButton.interactable =
            batatas >= 8 &&
            abobora >= 8 &&
            !SaveManager.Instance.UpgradeDesbloqueado("VidaExtra");

        ProximaFase();
    }

    public void ComprarVidaExtra()
    {
        SaveManager.Instance.DesbloquearUpgrade("VidaExtra");
        comprarVidaExtra = true;

        AtualizarReceitas();
    }
    public void ProximaFase()
    {
        bool vidaExtra = SaveManager.Instance.UpgradeDesbloqueado("VidaExtra");

        if (vidaExtra)
        {
            Debug.Log("tem o upgrade");
            painel.SetActive(true);
        }
    }
}