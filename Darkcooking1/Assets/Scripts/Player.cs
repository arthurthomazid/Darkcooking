using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Player : MonoBehaviour
{
    public float _speed = 5f;
    private Vector2 _movement;
    private Rigidbody2D _rb;
    public GameObject bullet;
    public int life = 3;
    private int _lifeMax;

    [Header("HUD")]
    public TMP_Text vida;

    void Start()
    {
        _lifeMax = life;
        _rb = GetComponent<Rigidbody2D>();

        AtualizarHud();

        Debug.Log("Velocidade: " + SaveManager.Instance.UpgradeDesbloqueado("Velocidade"));
        Debug.Log("TiroTriplo: " + SaveManager.Instance.UpgradeDesbloqueado("TiroTriplo"));

        if (SaveManager.Instance.UpgradeDesbloqueado("Velocidade"))
        {
            _speed += 3f;
        }
    }

    void Update()
    {
        _movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        _rb.linearVelocity = _movement * _speed;


        if (Input.GetButtonDown("Fire1")) //aciona o tiro
        {
            Instantiate(bullet, transform.position, transform.rotation);
            if (SaveManager.Instance.UpgradeDesbloqueado("TiroTriplo"))
            {
                Instantiate(
                    bullet,
                    transform.position,
                    Quaternion.Euler(0, 0, 20)
                );

                Instantiate(
                    bullet,
                    transform.position,
                    Quaternion.Euler(0, 0, -20)
                 );
            }
        }
    }

    public void ReceberDano(int dano)
    {
        life -= dano;
        AtualizarHud();
        if (life <= 0)
        {
            SceneManager.LoadScene("Game Over");
        }
    }
    void AtualizarHud()
    {
        vida.text = $"Vida:{life}/3";
    }
}