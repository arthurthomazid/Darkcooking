using System;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [Header("Velocidade")]
    public float velocidade = 0f;

    [Header("Disparo")]
    public Transform pontoDeDisparo;

    public GameObject tiroPrefabs;

    [Header("Configurações")]
    public float spawnInterval = 2f;
    public float timer = 0f;

    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(0f, -velocidade);
    }

    void Update()
    {
        timer += Time.deltaTime; //soma o tempo entre os frames.

        if (timer >= spawnInterval)
        {
            Tiro();
            Atirar();

            timer = 0f;
        }
    }

    private void Tiro()
    {
        if(pontoDeDisparo == null || tiroPrefabs == null)
        {
            Instantiate(tiroPrefabs, pontoDeDisparo.position, Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();

        if (player != null)
        {
            player.ReceberDano();

            Destroy(gameObject);
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    void Atirar()
    {
        GameObject novoTiro = Instantiate(
            tiroPrefabs,
            transform.position,
            transform.rotation
        );
        Rigidbody2D rb = novoTiro.GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.up * velocidade;
    }

}