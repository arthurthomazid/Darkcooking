using Unity.Mathematics;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Velocidade")]
    public float velocidade = 0f;

    private Rigidbody2D rb;

    public float tempoTroca = 1.5f;

    public float velocidadeHorizontal = 0f;

    private float contador = 0f;

    private bool indoDireita = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(0f, -velocidade);
    }
    private void Update()
    {
        float direçãoX;
        //aumenta o contador usando o tempo real do jogo
        contador += Time.deltaTime;
        if (contador >= tempoTroca)
        {
            //zera o contador
            contador = 0f;
            //inverte a direção
            indoDireita = !indoDireita;
        }
        if (indoDireita)
        {
            direçãoX = velocidadeHorizontal;
        }
        else
        {
            direçãoX = -velocidadeHorizontal;
        }
        rb.linearVelocity = new Vector2(
           direçãoX,
           -velocidade);
    }
}
