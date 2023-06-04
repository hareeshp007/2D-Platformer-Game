using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelSelection : MonoBehaviour
{
    private Button LevelButton;
    public string LevelName;
    // Start is called before the first frame update
    void Start()
    {
        LevelButton = GetComponent<Button>();
        LevelButton.onClick.AddListener(LevelSelect);
    }

    private void LevelSelect()
    {
        SceneManager.LoadScene(LevelName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
