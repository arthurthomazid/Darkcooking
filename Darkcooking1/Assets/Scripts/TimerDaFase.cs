using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FaseTimer : MonoBehaviour
{
    [Header("Tempo da Fase")]
    public float tempoDaFase = 60f;
    private float tempoRestante;
    public TMP_Text textoTempo;

    void Start()
    {
        tempoRestante = tempoDaFase;
    }

    void Update()
    {
        //diminui o tempo da fase
        tempoRestante -= Time.deltaTime;
        //atualiza o timer na tela
        //mathf.ceil arredonda o timer pra cima, no caso, 59.5 vai mostrar 60 segundos ao invéz do numero quebrado
        textoTempo.text = Mathf.Ceil(tempoRestante).ToString();
        if (tempoRestante <= 0)
        {
            FinalizarFase();
        }
    }
    void FinalizarFase()
    {
        SceneManager.LoadScene("Area inicial");
    }
}