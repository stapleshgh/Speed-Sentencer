using UnityEngine;
using UnityEngine.Events; 
using UnityEngine.UI; 
using TMPro;
using System.Collections;

public class DebugOptions : MonoBehaviour
{

    public TMP_Dropdown dropList;

    public Counter counterScript;

    public Button button;

    private bool debounce;

    public GameObject BabyPrefab;


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

    IEnumerator DelayBaby(float waittime)
    {
        yield return new WaitForSeconds(waittime);

        Instantiate(BabyPrefab);
    }

}
