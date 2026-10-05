using UnityEngine;
using System.Collections;

public class CebolaFlash : MonoBehaviour
{
    public CanvasGroup canvasGroup;

    [Header("Configuração")]
    public float tempoAparecer = 0.05f;
    public float tempoDesaparecer = 0.2f;

    private void Start()
    {
        // Começa invisível
        canvasGroup.alpha = 0f;
    }

    public void Mostrar()
    {
        // Começa a animação
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        // FADE IN
        float tempo = 0f;

        while (tempo < tempoAparecer)
        {
            tempo += Time.deltaTime;

            canvasGroup.alpha = Mathf.Lerp(
                0f,
                1f,
                tempo / tempoAparecer
            );

            yield return null;
        }

        canvasGroup.alpha = 1f;

        // FADE OUT
        tempo = 0f;

        while (tempo < tempoDesaparecer)
        {
            tempo += Time.deltaTime;

            canvasGroup.alpha = Mathf.Lerp(
                1f,
                0f,
                tempo / tempoDesaparecer
            );

            yield return null;
        }

        canvasGroup.alpha = 0f;
    }
}