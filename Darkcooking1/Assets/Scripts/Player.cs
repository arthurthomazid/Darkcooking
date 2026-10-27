using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.Runtime.CompilerServices;
using System;
public class Player : MonoBehaviour
{
    public float _speed = 6f;
    private Vector2 _movement;
    private Rigidbody2D _rb;
    public GameObject bullet;

    public float life = 5f;
    private float _lifeMax;

    public float timerdisparo = 0.2f;
    private float contador;

    [Header("HUD")]
    public TMP_Text vida;

    void Start()
    {
        _lifeMax = life;
        if(SaveManager.Instance.UpgradeDesbloqueado("FireRateExtra"))
        {
            timerdisparo = 0.1f;
            contador = timerdisparo;
        }
        else
        {
            contador = timerdisparo;
        }

            AtualizarHud();

        _rb = GetComponent<Rigidbody2D>();
        if (SaveManager.Instance.UpgradeDesbloqueado("Velocidade"))
        {
            _speed += 2f;
        }
        _lifeMax = life;
        AtualizarHud();
        if (SaveManager.Instance.UpgradeDesbloqueado("VidaExtra"))
        {
            life = 8f;
            _lifeMax = 8f;
        }

        _lifeMax = life;
        AtualizarHud();
    }

    void Update()
    {
        _movement = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        _rb.linearVelocity = _movement * _speed;
        contador -= Time.deltaTime;

        if (contador <= 0f) //aciona o tiro
        {
            contador = timerdisparo;
            Disparo();
        }
    }

    public void Disparo()
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

    public void ReceberDano(int dano)
    {
        dano = 1;
        life -= 1;
        AtualizarHud();
        if (life <= 0)
        {
            SceneManager.LoadScene("Game Over");
        }
    }
    void AtualizarHud()
    {
            vida.text = $"Vida:{life}/{_lifeMax}";
    }
    public void ReceberDano()
    {
        life -= 1;
        if (life <= 0)  
        {
            SceneManager.LoadScene("Game Over");
        }
        AtualizarHud();
    }
}