using UnityEngine;
using TMPro; 

public class Timer : MonoBehaviour
{

    public TMP_Text timerText;
    
    public float timer;
    bool DoOnce;

    //public GameObject baby;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    
        timer = 5; 

    }

    // Update is called once per frame
    void Update()
    {

        countDown();
        
    }

    public void countDown()
    {
        
        if (timer > 0)
        {

            timer -= Time.deltaTime;
            timerText.text = "Time: " + timer.ToString("0");
            DoOnce = false;
        }
        


    }
}
