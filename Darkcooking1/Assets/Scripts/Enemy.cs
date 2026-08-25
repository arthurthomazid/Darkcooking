using UnityEngine;
using UnityEngine.Audio;
using TMPro;
public enum TipoComida
{
    Maca,
    Cenoura,
    Alface,
    Abobora,
    Batata,
    Boss
}

public class Enemy : MonoBehaviour
{
    [Header("Som")]
    public AudioClip somDano;

    private AudioSource audioSource;

    [Header("Tipo do Inimigo")]
    public TipoComida tipo;

    public int vidaMaxima = 3;

    private int vidaAtual;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        vidaAtual = vidaMaxima;
    }

    public void ReceberDano(int dano)
    {
        if (somDano != null)
        {
            audioSource.PlayOneShot(somDano);
        }

        vidaAtual -= dano;

        if (vidaAtual <= 0)
        {
            audioSource.PlayOneShot(somDano);
            Morrer();
        }
    }

    void Morrer()
    {
        audioSource.PlayOneShot(somDano);

        if (SaveManager.Instance != null)
        {
            SaveManager.Instance.RegistrarMorte(tipo);
        }

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //verifica se o objeto possui a tag de muro
        if (other.CompareTag("Muro"))
        {
            //procura o jogador na cena.
            Player player = FindFirstObjectByType<Player>();

            if (player == null)
            {
                Debug.Log("player não encontrado");
            }
            else
            {
                player.ReceberDano();
                Debug.Log("Player encontrado");
            }
            Destroy(gameObject);
        }
    }
}