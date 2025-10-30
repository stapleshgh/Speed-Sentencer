using UnityEngine;
using UnityEngine.SceneManagement; 

public class GameOverCondition : MonoBehaviour
{

    public Counter verdictScript;
    public float badVerdictMaximum = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
       gameOver();

    }

    private void gameOver()
    {

        int badV = verdictScript.badVCount; 
        int goodV = verdictScript.goodVCount; 

        if (badV >= badVerdictMaximum)
        {

            SceneManager.LoadScene("GameOver");

        }

    }
}
