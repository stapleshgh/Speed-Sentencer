using UnityEngine;
using UnityEngine.SceneManagement;

public class friggenthing : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public ArduinoReader ar;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ar.valueMax > 0.25f)
        {
            SceneManager.LoadScene("SplashScreen");
        }
    }
}
