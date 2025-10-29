using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI; 
using TMPro; 

public class GameOverButtons : MonoBehaviour
{

    public Button restart; 
    public Button quit;
    public string SceneToLoad;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SceneToLoad = "SetUpScene";
        restart.onClick.AddListener(restartGame);

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


    }

}
