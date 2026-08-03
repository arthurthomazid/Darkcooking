using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;
    public float velocidadeRotacao = 720f;
    private Rigidbody2D rb;
    void Update()
    {
        transform.Rotate(0f, 0f, -velocidadeRotacao * Time.deltaTime);
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //faz a bala ir na direção em que está apontando.
        rb.linearVelocity = transform.up * speed;
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
            enemy.ReceberDano(1);

            Destroy(gameObject);
        }
    }
}