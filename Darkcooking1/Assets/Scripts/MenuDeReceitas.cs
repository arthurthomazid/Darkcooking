using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RecipeMenu : MonoBehaviour
{
    [Header("Botões")]
    public Button velocidadeButton;
    public Button tiroTriploButton;

    [Header("Textos da Receita do Bolo")]
    public TMP_Text textoMaca;
    public TMP_Text textoCenoura;

    [Header("Textos da Receita da Salada")]
    public TMP_Text textoCenoura2;
    public TMP_Text textoAlface;
    public TMP_Text textoMaca2;

    void OnEnable()
    {
        AtualizarReceitas();
    }

    public void AtualizarReceitas()
    {
        //Quantidade que o jogador possui
        int macas = SaveManager.Instance.GetQuantidade(TipoComida.Maca);
        int cenouras = SaveManager.Instance.GetQuantidade(TipoComida.Cenoura);
        int alfaces = SaveManager.Instance.GetQuantidade(TipoComida.Alface);

        //Atualiza os textos

        textoMaca.text = $"Maçãs:{macas}/10";
        textoCenoura.text = $"Cenouras:{cenouras}/5";

        textoCenoura2.text = $"Cenouras:{cenouras}/8";
        textoAlface.text = $"Alfaces:{alfaces}/6";
        textoMaca2.text = $"Maçãs:{macas}/3";

        //Receita 1
        velocidadeButton.interactable =
            macas >= 10 &&
            cenouras >= 5 &&
            !SaveManager.Instance.UpgradeDesbloqueado("Velocidade");

        //Receita 2
        tiroTriploButton.interactable =
            cenouras >= 8 &&
            alfaces >= 6 &&
            macas >= 3 &&
            !SaveManager.Instance.UpgradeDesbloqueado("TiroTriplo");
    }

    public void ComprarVelocidade()
    {
        SaveManager.Instance.DesbloquearUpgrade("Velocidade");

        AtualizarReceitas();
    }

    public void ComprarTiroTriplo()
    {
        SaveManager.Instance.DesbloquearUpgrade("TiroTriplo");

        AtualizarReceitas();
    }
}