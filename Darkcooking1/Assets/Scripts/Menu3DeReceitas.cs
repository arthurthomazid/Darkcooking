using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Recipe3Menu : MonoBehaviour
{
    [Header("Botões")]
    public Button tiroTriploButton;

    [Header("Textos da Receita da sopa")]
    public TMP_Text textoTomate;
    public TMP_Text textoPimenta;

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
        int tomate = SaveManager.Instance.GetQuantidade(TipoComida.Tomate);
        int pimenta = SaveManager.Instance.GetQuantidade(TipoComida.Pimenta);

        textoTomate.text = $"Tomates:{tomate}/8";
        textoPimenta.text = $"Pimentas:{pimenta}/8";

        tiroTriploButton.interactable =
            tomate >= 8 &&
            pimenta >= 8 &&
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
        bool tiroTriplo = SaveManager.Instance.UpgradeDesbloqueado("TiroTriplo");

        if (tiroTriplo)
        {
            Debug.Log("tem o upgrade");
            painel.SetActive(true);
        }
    }
}