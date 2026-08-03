using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.Runtime.CompilerServices;
public class Player : MonoBehaviour
{
    public float _speed = 6f;
    private Vector2 _movement;
    private Rigidbody2D _rb;
    public GameObject bullet;
    public float life = 5f;
    private float _lifeMax;

    [Header("HUD")]
    public TMP_Text vida;

    void Start()
    {
        _lifeMax = life;
        _rb = GetComponent<Rigidbody2D>();

        AtualizarHud();

        if (SaveManager.Instance.UpgradeDesbloqueado("Velocidade"))
        {
            _speed += 2f;
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
                    Quaternion.Euler(0, 0, 20) //Quaternion representa rotação (x,y,z)
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
        vida.text = $"Vida:{life}/5";
    }
}