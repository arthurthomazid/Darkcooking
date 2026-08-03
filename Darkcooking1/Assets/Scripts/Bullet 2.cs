using UnityEngine;

public class Bullet2: MonoBehaviour
{
    public float speed = 8f;
    public float velocidadeRotacao = 720f;
    private Rigidbody2D rb;
    
    [Header("Dano")]
    public float dano = 1;
    void Update()
    {
        transform.Rotate(0f, 0f, -velocidadeRotacao * Time.deltaTime);
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.up * speed; //faz a bala ir na direção em que está apontando.
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.ReceberDano((int)dano);

            Destroy(gameObject);
        }
    }
}