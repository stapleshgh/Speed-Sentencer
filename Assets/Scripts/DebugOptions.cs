using UnityEngine;
using UnityEngine.Events; 
using UnityEngine.UI; 
using TMPro;
using System.Collections;

public class DebugOptions : MonoBehaviour
{

    public TMP_Dropdown dropList;

    public Counter counterScript;

    public BabyProperties propertyScript; 

    public Timer timerScript; 

    public Button button;

    private bool debounce;

    public GameObject BabyPrefab;

    public string crime; 

    public bool guilty; 

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


        }
        else if (dropList.value == 1)
        {

            button.onClick.AddListener(AddOneBadVerdict);


        }
        else if (dropList.value == 2)
        {
            button.onClick.AddListener(BabySpawnVerdict);


        }
        else if (dropList.value == 3)
        {
            button.onClick.AddListener(JudgedLevel0);


        }
        else if (dropList.value == 4)
        {
            button.onClick.AddListener(JudgedLevell);


        }
        else if (dropList.value == 5)
        {
            button.onClick.AddListener(JudgedLevel2);


        }
        else if (dropList.value == 6)
        {
            button.onClick.AddListener(JudgedLevel3);


        }
        else if (dropList.value == 7)
        {
            button.onClick.AddListener(JudgedLevel4);


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
    public void BabySpawnVerdict()
    {

        StartCoroutine(DelayBaby(1));

    }

    public void JudgedLevel0()
    {
        guilty = propertyScript.guilty; 
        timerScript.timer = 0f; 

        if (guilty == false)
        {

            counterScript.goodVCount = counterScript.goodVCount + 1;

        }
        else 
        {

            counterScript.badVCount = counterScript.badVCount + 1;

        }

    }

    public void JudgedLevell()
    {
        crime = propertyScript.Crime; 
        timerScript.timer = 0f; 

        if (crime == "Troublemaking")
        {

            counterScript.goodVCount = counterScript.goodVCount + 1;

        }
        else 
        {

            counterScript.badVCount = counterScript.badVCount + 1;

        }

    }

    public void JudgedLevel2()
    {
        crime = propertyScript.Crime; 
        timerScript.timer = 0f; 

        if (crime == "CookieTheft")
        {

            counterScript.goodVCount = counterScript.goodVCount + 1;

        }
        else 
        {

            counterScript.badVCount = counterScript.badVCount + 1;

        }

    }

    public void JudgedLevel3()
    {
        crime = propertyScript.Crime; 
        timerScript.timer = 0f; 

        if (crime == "Bullying")
        {

            counterScript.goodVCount = counterScript.goodVCount + 1;

        }
        else 
        {

            counterScript.badVCount = counterScript.badVCount + 1;

        }

    }

    public void JudgedLevel4()
    {
        crime = propertyScript.Crime; 
        timerScript.timer = 0f; 

        if (crime == "MakingMess" || crime == "DrawingOnWall")
        {

            counterScript.goodVCount = counterScript.goodVCount + 1;

        }
        else 
        {

            counterScript.badVCount = counterScript.badVCount + 1;

        }

    }

    IEnumerator DelayBaby(float waittime)
    {
        yield return new WaitForSeconds(waittime);

        Instantiate(BabyPrefab);
    }

}
