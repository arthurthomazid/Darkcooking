using UnityEngine;
using UnityEngine.SceneManagement;
public class andar : MonoBehaviour
{

    public float _speed = 5f;

    private Vector2 _movement;

    private Rigidbody2D _rb;

    public GameObject bullet;

    public int life = 10;

    private int _lifeMax;

    void Start()

    {

        _lifeMax = life;

        _rb = GetComponent<Rigidbody2D>();

    }

    void Update()

    {

        _movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        _rb.linearVelocity = _movement * _speed;


        if (Input.GetButtonDown("Fire1")) //aciona o tiro

        {

            Instantiate(bullet, transform.position, transform.rotation);

        }

    }

    public void TakeDamage(int damage)

    {

        life -= damage;

        if (life <= 0)

        {

            print("betinha");

            SceneManager.LoadScene("GameOver");

        }

    }

}
 

