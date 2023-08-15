using TMPro;
using UnityEngine;

public class healthcontroller : MonoBehaviour
{
    private TextMeshProUGUI healthtext;
    private int currHealth;
    private void Awake()
    {
        healthtext = GetComponent<TextMeshProUGUI>();
        currHealth = PlayerPrefs.GetInt("Health");
    }
    private void Start()
    {
        RefreshGUI();
    }
    public void Health(int health)
    {
        currHealth = PlayerPrefs.GetInt("Health");
        currHealth = health;
        PlayerPrefs.SetInt("Health",currHealth);
        RefreshGUI();
    }
    private void RefreshGUI()
    {
        healthtext.text = "HEALTH : " + currHealth;
    }
}
