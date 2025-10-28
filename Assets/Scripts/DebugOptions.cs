using UnityEngine;
using UnityEngine.Events; 
using UnityEngine.UI; 
using TMPro; 

public class DebugOptions : MonoBehaviour
{
    
    public TMP_Dropdown dropList; 

    public Counter counterScript; 

    public Button button; 

    private bool debounce; 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {

        button.onClick.RemoveAllListeners();

        if (dropList.value == 0)
        {

            button.onClick.AddListener(AddOneGoodVerdict);
            button.onClick.RemoveListener(AddOneBadVerdict);

        }
        else if (dropList.value == 1)
        {

            button.onClick.AddListener(AddOneBadVerdict);
            button.onClick.RemoveListener(AddOneGoodVerdict);

        }
        else if (dropList.value == 2)
        {


        }
       
    }

    private void AddOneGoodVerdict()
    {

        counterScript.goodVCount = counterScript.goodVCount + 1; 

    }

    private void AddOneBadVerdict()
    {

        counterScript.badVCount = counterScript.badVCount + 1; 

    }

}
