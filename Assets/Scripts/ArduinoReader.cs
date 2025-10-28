using UnityEngine;
using System.IO.Ports;

public class ArduinoReader : MonoBehaviour
{
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
        Debug.Log(value);
    }
}
