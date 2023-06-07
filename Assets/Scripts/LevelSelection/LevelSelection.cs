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
    public int Levelnum;
    // Start is called before the first frame update
    void Start()
    {
        LevelButton = GetComponent<Button>();
        LevelButton.onClick.AddListener(LevelSelect);
    }

    private void LevelSelect()
    {
        LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(LevelName);
        switch (levelStatus)
        {
            case LevelStatus.locked:
                Debug.Log(Levelnum + " This Level is Locked:");
                break;
            case LevelStatus.unlocked:
                SoundManager.Instance.Play(Sounds.ButtonClick);
                Debug.Log(Levelnum + " This Level is Unlocked:");
                LevelManager.Instance.LoadAnyLevel(Levelnum);
                //SceneManager.LoadScene(LevelName);
                break;
            case LevelStatus.completed:
                SoundManager.Instance.Play(Sounds.ButtonClick);
                Debug.Log(Levelnum + " This Level is Completed:");
                LevelManager.Instance.LoadAnyLevel(Levelnum);
                //SceneManager.LoadScene(LevelName);
                break;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
