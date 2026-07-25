using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] string mainMenuScreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void loadMainMenu()
    {
        SceneManager.LoadScene(mainMenuScreen);
    }
    public void exitGame() {
        Application.Quit();
        Debug.Log("Game is exiting");
    }
}
