using UnityEngine;
using TMPro; 

public class Timer : MonoBehaviour
{

    public TMP_Text timerText;
    
    public float timer;
    public float InitialTime;
    bool DoOnce;

    public Counter counterScript;

    public DebugOptions DebugScript;

    public bool buttonPressed;

    //public GameObject baby;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InitialTime = 10;
        timer = 10; 


        buttonPressed = false;

        Debug.Log("Hi");
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
        else
        {
            


            GameObject foundObject = GameObject.Find("AccusedBabyOne(Clone)");
            AccusedBabyAlternative Script = foundObject.GetComponent<AccusedBabyAlternative>();

            if (!DoOnce)
            {
                if (!buttonPressed)
                {
                    DebugScript.JudgedLevel0();
                }

                Script.BeGone();
                DoOnce = true;

            }
            
        }


    }
}
