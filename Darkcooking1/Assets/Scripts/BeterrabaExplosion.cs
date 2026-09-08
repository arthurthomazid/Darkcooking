using TMPro;
using UnityEngine;

public class BeterrabaExplosion : MonoBehaviour
{
    [Header("Configuração da explosão")]
    public float tempoParaExplodir = 5f;
    public float raioExplosao = 2f;
   
    public int dano = 1;

    [Header("Efeito visual")]
    public GameObject efeitoExplosao;

    private float contador = 0f;

    void Update()
    {
        contador += Time.deltaTime;
        if (contador >= tempoParaExplodir)
        {
            Explodir();
        }
    }

    void Explodir()
    {
        //Cria o efeito visual da explosão
        if (efeitoExplosao != null)
        {
            Instantiate(
                efeitoExplosao,
                transform.position,
                Quaternion.identity
            );
        }
        //Procura todos os Colliders dentro do raio da explosão
        Collider2D[] objetosAtingidos = Physics2D.OverlapCircleAll(
            transform.position,
            raioExplosao
        );
        
        //Verifica cada objeto atingido
        foreach (Collider2D objeto in objetosAtingidos)
        {
            //Procura o Player
            Player player = objeto.GetComponentInParent<Player>();
            if (player != null)
            {
                player.ReceberDano(dano);
            }
        }
        Destroy(gameObject);
    }

    //Mostra o raio da explosão no editor
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(
            transform.position,
            raioExplosao
        );
    }
}