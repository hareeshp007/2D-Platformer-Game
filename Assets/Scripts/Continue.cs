using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Continue : MonoBehaviour
{
    private Button ContButton;
    void Awake()
    {
        ContButton = GetComponent<Button>();
        ContButton.onClick.AddListener(ContinueLevel);
    }

    private void ContinueLevel()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("LastLevel"));
    }
}
