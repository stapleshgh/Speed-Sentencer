using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement; 
using TMPro; 

public class StartButton : MonoBehaviour
{

    public Button startButton; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        startButton.onClick.AddListener(startGame);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame()
    {

        SceneManager.LoadScene("SplashScreen");

    }

}
