using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    
    public Button singlePlayerButton;
    public Button multiPlayerButton;

    
    public string singlePlayerSceneName = "SinglePlayer"; 
    public string multiPlayerSceneName = "MultiPlayer"; 

    void Start()
    {
        
        if (singlePlayerButton != null)
        {
            singlePlayerButton.onClick.AddListener(LoadSinglePlayerScene);
        }
        else
        {
            Debug.LogError("Single Player Button is not assigned!");
        }

        if (multiPlayerButton != null)
        {
            multiPlayerButton.onClick.AddListener(LoadMultiPlayerScene);
        }
        else
        {
            Debug.LogError("Multi Player Button is not assigned!");
        }
    }

    public void LoadSinglePlayerScene()
    {
        if (!string.IsNullOrEmpty(singlePlayerSceneName))
        {
            SceneManager.LoadScene(singlePlayerSceneName);
        }
        else
        {
            Debug.LogError("Single Player Scene name is empty!");
        }

    }

    public void LoadMultiPlayerScene()
    {
        if (!string.IsNullOrEmpty(multiPlayerSceneName))
        {
            SceneManager.LoadScene(multiPlayerSceneName);
        }
        else
        {
            Debug.LogError("Multi Player Scene name is empty!");
        }

    }
}