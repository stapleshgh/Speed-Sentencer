using UnityEngine;
using System.IO.Ports;
using UnityEngine.UI;
using NUnit.Framework;
using System.Collections;
using static UnityEngine.Rendering.DebugUI;
using UnityEngine.InputSystem;

public class ArduinoReader : MonoBehaviour
{
    public Image activeMeter;

    public Image pollingMeter;


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
        float value = int.Parse(data);


        value *= 0.001f;

        float mappedValue;

        if (value > 0.5f)
        {
            mappedValue = value - 0.5f;
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



}
