using UnityEngine;
using System.Collections; 
using TMPro; 

public class Counter : MonoBehaviour
{

    public TMP_Text badVText; 
    public TMP_Text goodVText;
    
    public int badVCount; 
    public int goodVCount;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        
        
    } 

    // Update is called once per frame
    void Update()
    {

        badVText.text = badVCount.ToString();
        goodVText.text = goodVCount.ToString();

    }
}
