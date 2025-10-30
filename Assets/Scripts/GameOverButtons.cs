using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI; 
using TMPro; 

public class GameOverButtons : MonoBehaviour
{

    public Button restart; 
    public Button quit;
    public string SceneToLoad;
    public string SceneToLoadTitle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        restart.onClick.AddListener(restartGame);
        quit.onClick.AddListener(quitGame);
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    private void restartGame()
    {

        SceneManager.LoadScene(SceneToLoad); 

    }

    private void quitGame()
    {

        SceneManager.LoadScene(SceneToLoadTitle);

    }

}
