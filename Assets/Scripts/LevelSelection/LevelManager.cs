using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance { get { return instance; } }
    public string[] Levels;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        if (GetLevelStatus(Levels[0]) == LevelStatus.locked)
        {
            SetLevelStatus(Levels[0], LevelStatus.unlocked);
        }
    }
    public void LoadAnyLevel(int LevelNumber)
    {
        SceneManager.LoadScene(LevelNumber);
        Debug.Log("Loading Level :" + LevelNumber);
    }
    public void MarkCurrentLevelCompleted()
    {
        Scene currentscene = SceneManager.GetActiveScene();  
        SetLevelStatus(currentscene.name, LevelStatus.completed);
        int currentsceneIndex=Array.FindIndex(Levels, level => level == currentscene.name);
        int nextsceneindex = currentsceneIndex + 1;
        if (nextsceneindex < Levels.Length)
        {
            SetLevelStatus(Levels[nextsceneindex],LevelStatus.unlocked);
            Debug.Log(Levels[nextsceneindex] + "next scene name");
        }else if(nextsceneindex >= Levels.Length)
        {
            Debug.Log("All Levels Are completed");
        } 
    }
    public void SetLevelStatus(string Level,LevelStatus levelStatus)
    {
        PlayerPrefs.SetInt(Level, (int)levelStatus);
        Debug.Log("level name :"+ Level +" and its status is :" +levelStatus);
    }
    public LevelStatus GetLevelStatus(string level)
    {
        LevelStatus levelStatus=(LevelStatus)PlayerPrefs.GetInt(level,0);
        Debug.Log("level name :" + level + " and its status is :" + levelStatus);
        return levelStatus;
    }
}
