using UnityEngine;
using System.IO.Ports;
using System.IO; 
using UnityEngine.UI;
using NUnit.Framework;
using System.Collections;

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
        int value = int.Parse(data);
        Debug.Log(value * 0.001f);


        activeMeter.transform.localScale = new Vector2(activeMeter.transform.localScale.x, value * 0.001f);

        poll(value);
    }

    void poll(int value)
    {
        if (value > 100)
        {
            pollingMeter.transform.localScale = Vector2.Lerp(new Vector2(pollingMeter.transform.localScale.x, 0f), new Vector2(pollingMeter.transform.localScale.x, value * 0.001f), 10);

        } 
    }
}
