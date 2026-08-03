using UnityEngine;

public class FecharPainel : MonoBehaviour
{
    public void Fechar()
    {
        //desativa o parent
        transform.parent.gameObject.SetActive(false);
    }
}