using UnityEngine;
using System.IO.Ports;
using System.IO; 
using UnityEngine.UI;
using NUnit.Framework;
using System.Collections;
using static UnityEngine.Rendering.DebugUI;
using UnityEngine.InputSystem;

public class ArduinoReader : MonoBehaviour
{
    public Image activeMeter;

    public Image pollingMeter;

    public AnimationCurve ac;

    public DebugOptions debugOptions;

    float lastValue;
    float value;
    public float valueMax;

    bool startedRecording;
    bool hasNotSentenced = true;


    SerialPort serial = new SerialPort("COM12", 9600);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        serial.Open();
        serial.ReadTimeout = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
        string data = serial.ReadLine();
        value = float.Parse(data); value *= -0.5f;
        
        if (value < 0)
        {
            value = 0;
        }

        
        processData();

        


        activeMeter.transform.localScale = new Vector2(activeMeter.transform.localScale.x, value);
        poll(valueMax);

        Debug.Log(hasNotSentenced);
        if (hasNotSentenced && Input.GetKey(KeyCode.Space))
        {
            if (valueMax < 0.01f)
            {
                debugOptions.JudgedLevel0();
            }

            else if (valueMax > 0.01 && valueMax < 0.25f)
            {
                debugOptions.JudgedLevell();

            }
            else if (valueMax > 0.25f && valueMax < 0.5f)
            {
                debugOptions.JudgedLevel2();
            }
            else if (valueMax > 0.5f && valueMax < 0.75f)
            {
                debugOptions.JudgedLevel3();
            }
            else if (valueMax > 0.75f)
            {
                debugOptions.JudgedLevel4();
            }

            
        }

        
    }

    void poll(float value)
    {
        if (value > 0)
        {
            pollingMeter.transform.localScale = Vector2.Lerp(new Vector2(pollingMeter.transform.localScale.x, 0f), new Vector2(pollingMeter.transform.localScale.x, value), 10);

        } 
    }


    void processData()
    {
        if (value < 0.1)
        {
            value = 0;
            hasNotSentenced = true;
        }

        if (value > lastValue)
        {
            valueMax = value;
            hasNotSentenced = false;
        } 

        lastValue = value;
    }

    public void resetProgram()
    {
        Debug.Log("babyLeft");
        startedRecording = false;
        value = 0f;
        valueMax = 0f;
        lastValue = 0f;
        hasNotSentenced = true;
        pollingMeter.transform.localScale = Vector2.Lerp(new Vector2(pollingMeter.transform.localScale.x, 0f), new Vector2(pollingMeter.transform.localScale.x, value), 10);

    }


}
