using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scorecounter : MonoBehaviour
{
    private TextMeshProUGUI scoretext;
    private int score;
    private void Awake()
    {
        scoretext = GetComponent<TextMeshProUGUI>();
    }
    private void Start()
    {
        RefreshGUI();
    }
    public void Increasescore(int increment)
    {
        score += increment;
        RefreshGUI();
    }
    private void RefreshGUI() {
        scoretext.text = "SCORE : " + score;
    }


}
