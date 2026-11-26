using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Recipe3Menu : MonoBehaviour
{
    [Header("Botões")]
    public Button tiroTriploButton;
    public Button fireRateExtraButton;

    [Header("Textos da Receita do Tomate + Pimenta")]
    public TMP_Text textoTomate;
    public TMP_Text textoPimenta;

    [Header("Textos da Receita Tomate + Cebola")]
    public TMP_Text textoCebola;
    public TMP_Text textoTomate2;


    public bool comprarTiroTriplo;
    public bool comprarFireRate;

    public GameObject painel;

    void OnEnable()
    {
        AtualizarReceitas();
    }

    public void AtualizarReceitas()
    {
        int tomate = SaveManager.Instance.GetQuantidade(TipoComida.Tomate);
        int pimenta = SaveManager.Instance.GetQuantidade(TipoComida.Pimenta);
        int cebola = SaveManager.Instance.GetQuantidade(TipoComida.Cebola);

        textoTomate.text = $"Tomates:{tomate}/8";
        textoPimenta.text = $"Pimentas:{pimenta}/5";

        textoCebola.text = $"Cebolas:{cebola}/6";
        textoTomate2.text = $"Tomates:{tomate}/8";


        tiroTriploButton.interactable =
            tomate >= 8 &&
            pimenta >= 5 &&
            !SaveManager.Instance.UpgradeDesbloqueado("TiroTriplo");

        fireRateExtraButton.interactable =
            tomate >= 8 &&
            cebola >= 6 &&
            !SaveManager.Instance.UpgradeDesbloqueado("FireRateExtra");


        ProximaFase();
    }

    public void ComprarTiroTriplo()
    {
        SaveManager.Instance.DesbloquearUpgrade("TiroTriplo");
        comprarTiroTriplo = true;

        AtualizarReceitas();
    }

    public void ComprarFireRate()
    {
        SaveManager.Instance.DesbloquearUpgrade("FireRateExtra");
        comprarFireRate = true;

        AtualizarReceitas();
    }

    public void ProximaFase()
    {
        bool tiroTriplo = SaveManager.Instance.UpgradeDesbloqueado("TiroTriplo");
        bool fireRateExtra = SaveManager.Instance.UpgradeDesbloqueado("FireRateExtra");

        if (tiroTriplo && fireRateExtra == true)
        {
            Debug.Log("tem o upgrade");
            painel.SetActive(true);
        }
    }
}