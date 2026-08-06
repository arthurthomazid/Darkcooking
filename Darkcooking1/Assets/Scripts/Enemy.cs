using UnityEngine;
using UnityEngine.Audio;

public enum TipoComida
{
    Maca,
    Cenoura,
    Alface
}

public class Enemy : MonoBehaviour
{
    [Header("Som")]
    public AudioClip somDano;

    private AudioSource audioSource;

    [Header("Tipo do Inimigo")]
    public TipoComida tipo;

    [Header("Velocidade")]
    public float velocidade = 5f;

    [Header("Vida")]
    public int vidaMaxima = 3;

    private int vidaAtual;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.linearVelocity = new Vector2(0f, -velocidade);

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
            Morrer();
        }
    }

    void Morrer()
    {
        if (SaveManager.Instance != null)
        {
            SaveManager.Instance.RegistrarMorte(tipo);
        }

        audioSource.PlayOneShot(somDano);

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Colidiu");
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