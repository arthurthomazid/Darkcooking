using UnityEngine;
public class Enemy : MonoBehaviour
{
    [Header("Configurações de Movimento")]
    public float velocidade = 5f;

    private Rigidbody2D rb;

    void Start()
    {
        //pega a referência do Rigidbody2D do objeto
        rb = GetComponent<Rigidbody2D>();

        //define a velocidade
        rb.linearVelocity = new Vector2(0f, -velocidade);
    }
    
    private bool entrouNaTela = false; 

    //chamado quando o objeto é visto por qualquer câmera
    void OnBecameVisible()
    {
        entrouNaTela = true;
    }

    //chamado quando o objeto deixa de ser visto
    void OnBecameInvisible()
    {
        //só destrói se ele já entrou na tela antes
        if (entrouNaTela)
        {
            Destroy(gameObject);
        }
    }
}