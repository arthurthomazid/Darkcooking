using UnityEngine;
 

using UnityEngine.UI;
 
public class ClickerManager : MonoBehaviour

{

    public double score = 0;

    public double clickPower = 1;

    public Text scoreText;



    public void OnClickSymbol()

    {

        score += clickPower;

        UpdateUI();

    }

    void UpdateUI()

    {

        scoreText.text = "Pontos: " + score.ToString("F0");

    }

}
