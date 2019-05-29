using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    public static float points;
    public static float bestScore;
    public static float health;
    public Canvas canv;
    
    void Start()
    {
        points = 0.0f;
        health = 100.0f;
        //cargamos el puntaje mas alto almacenado
        bestScore = PlayerPrefs.GetFloat("High",0);

    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(points);
        if (canv)
        {

            canv.transform.Find("Points").GetComponent<TextMeshProUGUI>().SetText(points.ToString());

            canv.transform.Find("Health").GetComponent<TextMeshProUGUI>().SetText(health.ToString());

            canv.transform.Find("BestScore").GetComponent<TextMeshProUGUI>().SetText(bestScore.ToString());


        }



    }


    public static void BestScoreCalculator()
    {
        if(points > bestScore)
        {
            PlayerPrefs.SetFloat("High", points);
        }
    }

}
