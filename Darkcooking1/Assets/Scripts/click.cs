using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class click : MonoBehaviour
{
    [Header("Configurações do Jogo")]
    public double moedas;
    public int poderDoClique = 1;
    public double pontosPorSegundo = 0; // Ganho automático

    private int contadorDeCliquesTotais = 0;
    private int multiplicadorEvento = 1;

    [Header("Componentes de Interface")]
    public TextMeshProUGUI textoMoedas;
    public Button botaoCSharps;

    [Header("Preços da Loja")]
    public double precoTeclado = 10;
    public double precoProgramador = 50;

    void Start()
    {
        AtualizarInterface();
    }

    void Update()
    {
        if (pontosPorSegundo > 0)
        {
            moedas += pontosPorSegundo * Time.deltaTime;
            AtualizarInterface();
        }
    }

    public void RegistrarClique()
    {
        contadorDeCliquesTotais++;
        moedas += poderDoClique * multiplicadorEvento;

        if (contadorDeCliquesTotais == 50)
        {
            StartCoroutine(AtivarMiniEvento());
        }

        AtualizarInterface();
    }

    // FUNÇÕES DA LOJA
    public void ComprarTeclado()
    {
        if (moedas >= precoTeclado)
        {
            moedas -= precoTeclado;
            poderDoClique += 1; // Aumenta força do clique
            precoTeclado *= 1.5; // Fica mais caro
            AtualizarInterface();
        }
    }

    public void ComprarProgramador()
    {
        if (moedas >= precoProgramador)
        {
            moedas -= precoProgramador;
            pontosPorSegundo += 2; // Agora ganha 2 pontos por segundo sozinho
            precoProgramador *= 1.8;
            AtualizarInterface();
        }
    }

    IEnumerator AtivarMiniEvento()
    {
        multiplicadorEvento = 2;
        botaoCSharps.image.color = Color.yellow;
        yield return new WaitForSeconds(10f);
        multiplicadorEvento = 1;
        botaoCSharps.image.color = Color.white;
        contadorDeCliquesTotais = 0;
    }

    void AtualizarInterface()
    {
        textoMoedas.text = "C# Points: " + moedas.ToString("N0") + "\n<size=20>Ganho Passivo: " + pontosPorSegundo.ToString("F1") + "/s</size>";
    }
}
