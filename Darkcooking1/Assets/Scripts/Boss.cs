using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    [Header("Vida")]
    public TMP_Text vida;

    public int vidaMaxima = 80;

    private int vidaAtual;

    void Start()
    {
        vidaAtual = vidaMaxima;
    }
    public void ReceberDano(int dano)
    {
        vidaAtual -= dano;

        AtualizarHud();

        if (vidaAtual <= 0)
        {
            Morrer();
        }
    }

    void Morrer()
    {
        SceneManager.LoadScene("Victory");
    }
    void AtualizarHud()
    {
        vida.text = $"Vida:{vidaAtual}/{vidaMaxima}";
    }
}