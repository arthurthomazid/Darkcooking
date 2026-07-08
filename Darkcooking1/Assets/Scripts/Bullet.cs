using UnityEngine;
public class Bullet : MonoBehaviour
{
    public float speed = 8;
    void Start()
    {
        GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0, speed);
    }

    void Update()
    {

    }
    private void OnBecameInvisible() //aciona quando o objeto com arte sai da câmera
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision) //acionado quando este objeto bate em outro //collision é o objeto que bateu neste
                                                        //deve ser IsTrigger
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }

}
