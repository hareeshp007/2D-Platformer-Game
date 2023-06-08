using UnityEngine;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{
    public Button Playbutton;
    public Button Exitbutton;
    public GameObject LevelSelectionPopup;
    private void Awake()
    {
        Playbutton.onClick.AddListener(Play);
        Exitbutton.onClick.AddListener(Exit);
    }
    public void Play()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        LevelSelectionPopup.SetActive(true);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
