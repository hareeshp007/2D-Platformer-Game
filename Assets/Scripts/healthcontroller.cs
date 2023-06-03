using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class healthcontroller : MonoBehaviour
{
    private TextMeshProUGUI healthtext;
    private int currHealth;
    private void Awake()
    {
        healthtext = GetComponent<TextMeshProUGUI>();
    }
    private void Start()
    {
        RefreshGUI();
    }
    public void Health(int health)
    {
        Debug.Log("healthcontroller");
        currHealth = health;
        RefreshGUI();
    }
    private void RefreshGUI()
    {
        healthtext.text = "HEALTH : " + currHealth;
    }
}
