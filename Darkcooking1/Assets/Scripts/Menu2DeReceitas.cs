 using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Recipe2Menu : MonoBehaviour
{
    [Header("Botões")]
    public Button tiroTriploButton;

    [Header("Textos da Receita da sopa")]
    public TMP_Text textoBatata;
    public TMP_Text textoAbobora;

    public bool comprarTiroTriplo;
    public GameObject painel;

    void OnEnable()
    {
        AtualizarReceitas();
    }

    public void AtualizarReceitas()
    {
        int macas = SaveManager.Instance.GetQuantidade(TipoComida.Maca);
        int cenouras = SaveManager.Instance.GetQuantidade(TipoComida.Cenoura);
        int alfaces = SaveManager.Instance.GetQuantidade(TipoComida.Alface);
        int batatas = SaveManager.Instance.GetQuantidade(TipoComida.Batata);
        int abobora = SaveManager.Instance.GetQuantidade(TipoComida.Abobora);

        textoBatata.text = $"Batatas:{batatas}/8";
        textoAbobora.text = $"Aboboras:{abobora}/8";

        tiroTriploButton.interactable =
            batatas >= 8 &&
            abobora >= 8 &&
            !SaveManager.Instance.UpgradeDesbloqueado("TiroTriplo");

        ProximaFase();
    }

    public void ComprarTiroTriplo()
    {
        SaveManager.Instance.DesbloquearUpgrade("TiroTriplo");
        comprarTiroTriplo = true;

        AtualizarReceitas();
    }
    public void ProximaFase()
    {
        if (comprarTiroTriplo == true)
        {
            Debug.Log("tem o upgrade");
            painel.SetActive(true);
        }
    }
}