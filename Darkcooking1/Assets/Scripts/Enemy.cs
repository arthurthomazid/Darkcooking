using UnityEngine;
using UnityEngine.Audio;
using TMPro;
using System.Collections;
public enum TipoComida
{
    Maca,
    Cenoura,
    Alface,
    Abobora,
    Batata,
    Tomate,
    Pimenta,
    Cebola,
    Boss
}

public class Enemy : MonoBehaviour
{

    [Header("Efeito de Dano")]
    public SpriteRenderer spriteRenderer;
    public Color corDano = Color.red;
    public float piscadaDuração = 0.1f;

    private Color corOriginal;

    [Header("Som")]
    public AudioClip somDano;

    private AudioSource audioSource;

    [Header("Efeito na Tela")]
    public bool CebolaTela = false;

    [Header("Tipo do Inimigo")]
    public TipoComida tipo;

    [Header("Atributos")]
    public int vidaMaxima = 3;
    public int dano;

    private int vidaAtual;
    public CebolaFlash efeitoTela;
    public GameObject efeitomorteprefab;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        vidaAtual = vidaMaxima;
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        if (spriteRenderer != null)
        {
            corOriginal = spriteRenderer.color;
        }
    }

    public void ReceberDano(int dano)
    {
        if (somDano != null)
        {
            audioSource.PlayOneShot(somDano);
        }

        if (spriteRenderer != null)
        {
            StartCoroutine(Piscar());
        }

        vidaAtual -= dano;

        if (vidaAtual <= 0)
        {
            audioSource.PlayOneShot(somDano);
            Morrer();
        }
    }
    IEnumerator Piscar()
    {
        spriteRenderer.color = corDano;

        yield return new WaitForSeconds(piscadaDuração);

        spriteRenderer.color = corOriginal;
    }

    void Morrer()
    {
        audioSource.PlayOneShot(somDano);

        if (SaveManager.Instance != null)
        {
            SaveManager.Instance.RegistrarMorte(tipo);
        }
        if (CebolaTela)
        {
            CebolaFlash efeitoTela = FindAnyObjectByType<CebolaFlash>();

            if (efeitoTela != null)
            {
                efeitoTela.Mostrar();
            }
        }

        Instantiate(efeitomorteprefab, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Muro"))
        {
            Player player = FindFirstObjectByType<Player>();

            if (player != null)
            {

                //Boss causa dano igual à vida máxima do jogador
                if (tipo == TipoComida.Boss)
                {
                    player.ReceberDano((int)player.life);
                }
                else
                {
                    // Inimigos normais causam apenas 1 de dano
                    player.ReceberDano(1);
                }
            }

            Destroy(gameObject);
        }
    }
}