using UnityEngine;
using TMPro;

public class scorecounter : MonoBehaviour
{
    private TextMeshProUGUI scoretext;
    private int score;
    private void Awake()
    {
        scoretext = GetComponent<TextMeshProUGUI>();
        score = PlayerPrefs.GetInt("Collectables");
    }
    private void Start()
    {
        RefreshGUI();
    }
    public void IncreaseScore(int increment)
    {
        score = PlayerPrefs.GetInt("Collectables");
        score += increment;
        PlayerPrefs.SetInt("Collectables", score);
        RefreshGUI();
    }
    private void RefreshGUI() {
        scoretext.text = "SCORE : " + score;
    }


}
