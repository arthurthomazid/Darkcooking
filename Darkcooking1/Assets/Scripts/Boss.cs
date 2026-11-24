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

    [Header("Dano")]
    public int dano;

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

    private void OnTriggerEnter2D(Collider2D other)
    {
        //verifica se o objeto possui a tag de muro
        if (other.CompareTag("Muro"))
        {
            //procura o jogador na cena.
            Player player = FindFirstObjectByType<Player>();

            player.ReceberDano();

            Destroy(gameObject);
        }
    }
}