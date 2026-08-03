using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;

    private void Awake()
    {
        //verifica se ainda não existe um saveManager
        if (Instance == null)
        {
            //se não existir, esta instância se torna a instância principal
            Instance = this;

            //faz com que este gameObject não seja destruído ao trocar de cena
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            //se já existir outro saveManager, destrói este para evitar erro
            Destroy(gameObject);
        }
    }

    public void RegistrarMorte(TipoComida tipo)
    {
        //converte o enum para texto
        string chave = tipo.ToString();

        int quantidade = PlayerPrefs.GetInt(chave, 0);

        quantidade++;
        
        //salva o novo valor no PlayerPrefs
        PlayerPrefs.SetInt(chave, quantidade);

        PlayerPrefs.Save();
    }

    //retorna quantas vezes uma comida foi derrotada
    //se não existir, retorna 0
    public int GetQuantidade(TipoComida tipo)
    {
        return PlayerPrefs.GetInt(tipo.ToString(), 0);
    }

    //verifica se um upgrade já foi desbloqueado
    public bool UpgradeDesbloqueado(string nome)
    {
        return PlayerPrefs.GetInt(nome, 0) == 1;
    }

    //desbloqueia um upgrade
    public void DesbloquearUpgrade(string nome)
    {
        PlayerPrefs.SetInt(nome, 1);
        PlayerPrefs.Save();
    }
}