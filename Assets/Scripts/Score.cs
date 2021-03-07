using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    TMP_Text scoretext;
   int score = 0;
    
    void Start()
    {
        scoretext = GetComponent<TMP_Text>();
        scoretext.text = "START";
    }

    public void updateScore(int amount)
    {
       score += amount; 
       scoretext.text = score.ToString(); 
    }
}
