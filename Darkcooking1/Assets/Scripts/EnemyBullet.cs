using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [Header("Velocidade")]
    public float velocidade = 0f;

    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(0f, -velocidade);
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

    [Header("Configurações do tiro")]
    public GameObject projetil;
    public float intervalo = 2f;
    private float contador = 0f;

    void Update()
    {
        contador += Time.deltaTime;
        if (contador >= intervalo)
        {
            Atirar();
            contador = 0f;
        }
    }

    void Atirar()
    {
        GameObject novoProjetil = Instantiate(
            projetil,
            transform.position,
            transform.rotation
        );
        Rigidbody2D rb = novoProjetil.GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.up * velocidade;
    }

}