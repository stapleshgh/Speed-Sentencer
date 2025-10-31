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

    float lastValue;
    float value;
    float valueMax;

    bool startedRecording;


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

        Debug.Log(data + " " + value);
        processData();

        

        float mappedValue;

        if (valueMax > 0.5f)
        {
            mappedValue = valueMax - 0.5f;
            mappedValue *= 2;
        } else
        {
            mappedValue = 0;
        }

        activeMeter.transform.localScale = new Vector2(activeMeter.transform.localScale.x, value);
        poll(mappedValue);

        
        

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
        if (value > lastValue)
        {
            startedRecording = true;
            if (value > valueMax)
            {
                valueMax = value;
            }
        } else
        {
            if (startedRecording)
            {
                //this is where the animation plays
                StartCoroutine(resetProgram());
            }
        }

        lastValue = value;
    }

    IEnumerator resetProgram()
    {
        yield return new WaitForSeconds(0);
        startedRecording = false;
        value = 0f;
        valueMax = 0f;
        lastValue = 0f;
    }



}
