using TMPro;
using UnityEngine;

public class BeterrabaExplosion : MonoBehaviour
{
    [Header("Timer")]
    public float tempoDaExplosão = 60f;
    private float tempoRestante;
    public TMP_Text textoTempo;

    void Start()
    {
        tempoRestante = tempoDaExplosão;
    }

    void Update()
    {
        tempoRestante -= Time.deltaTime;
        textoTempo.text = Mathf.Ceil(tempoRestante).ToString();
        if(tempoRestante <= 0 )
        {
            Explosão();
        }
    }
    void Explosão()
    {

    }
}
