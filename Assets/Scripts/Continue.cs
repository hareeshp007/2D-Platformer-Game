using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Continue : MonoBehaviour
{
    private Button ContButton;
    // Start is called before the first frame update
    void Awake()
    {
        ContButton = GetComponent<Button>();
        ContButton.onClick.AddListener(continueLevel);
    }

    private void continueLevel()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("LastLevel"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
