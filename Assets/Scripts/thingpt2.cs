using UnityEngine;
using UnityEngine.SceneManagement;

public class thingpt2 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public ArduinoReader ar;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ar.valueMax > 0.75f)
        {
            SceneManager.LoadScene("AltCurrentBuild");
        }
    }
}
