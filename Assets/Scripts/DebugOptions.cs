using UnityEngine;
using UnityEngine.Events; 
using UnityEngine.UI; 
using TMPro;
using System.Collections;

public class DebugOptions : MonoBehaviour
{
    public ArduinoReader arduinoReader;


    public TMP_Dropdown dropList;

    public Counter counterScript;

    public BabyProperties propertyScript; 

    public Timer timerScript; 

    public Button button;

    private bool debounce;

    public GameObject BabyPrefab;

    public string crime; 

    public bool guilty; 

    public AudioSource cryingBabyAudio; 
    
    public AudioSource happyBabyAudio;

    [SerializeField] AudioClip[] happyAudioList;

    [SerializeField] AudioClip[] SadAudioList;


    [SerializeField] string[] JudgePunishmentList;

    public TMP_Text PunishmentTalkGuilty;
    public TMP_Text PunishmentTalkInnocent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BabySpawnVerdict();



    }

    IEnumerator InnocentSpawn(float waitTime)
    {
        PunishmentTalkInnocent.gameObject.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        PunishmentTalkInnocent.gameObject.SetActive(false);

    }

    IEnumerator guiltySpawn(float waitTime)
    {
        PunishmentTalkGuilty.text = JudgePunishmentList[Random.Range(0, JudgePunishmentList.Length)];

        PunishmentTalkGuilty.gameObject.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        PunishmentTalkGuilty.gameObject.SetActive(false);

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

        


        happyBabyAudio.clip = happyAudioList[Random.Range(0, happyAudioList.Length)];
        happyBabyAudio.Play();

    }

    private void AddOneBadVerdict()
    {

        

        counterScript.badVCount = counterScript.badVCount + 1;

        cryingBabyAudio.clip = SadAudioList[Random.Range(0,SadAudioList.Length)];

        cryingBabyAudio.Play();

    }
    public void BabySpawnVerdict()
    {

        StartCoroutine(DelayBaby(1));

    }

    public void JudgedLevel0()
    {

        StartCoroutine(InnocentSpawn(1.5f));


        guilty = propertyScript.guilty; 
        timerScript.timer = 0f; 

        if (guilty == false)
        {

            AddOneGoodVerdict();

        }
        else 
        {

            AddOneBadVerdict();

        }
        timerScript.buttonPressed = true;
    }

    public void JudgedLevell()
    {
        crime = propertyScript.CrimeTypeProperty; 
        timerScript.timer = 1f; 

        if (crime == "Troublemaking")
        {

            AddOneGoodVerdict();

        }
        else 
        {

            AddOneBadVerdict();

        }
        timerScript.buttonPressed = true;

        StartCoroutine(guiltySpawn(1.5f));
    }

    public void JudgedLevel2()
    {
        crime = propertyScript.CrimeTypeProperty; 
        timerScript.timer = 1f; 

        if (crime == "Theft")
        {

            AddOneGoodVerdict();

        }
        else 
        {

            AddOneBadVerdict();

        }
        timerScript.buttonPressed = true;

        StartCoroutine(guiltySpawn(1f));
    }

    public void JudgedLevel3()
    {
        crime = propertyScript.CrimeTypeProperty; 
        timerScript.timer = 1f; 

        if (crime == "Bullying")
        {

            AddOneGoodVerdict();

        }
        else 
        {

            AddOneBadVerdict();

        }
        timerScript.buttonPressed = true;

        StartCoroutine(guiltySpawn(1f));
    }

    public void JudgedLevel4()
    {
        crime = propertyScript.CrimeTypeProperty; 
        timerScript.timer = 1f; 

        if (crime == "MakingMess")
        {

            AddOneGoodVerdict();

        }
        else 
        {

            AddOneBadVerdict();

        }
        timerScript.buttonPressed = true;

        StartCoroutine(guiltySpawn(1f));
    }

    IEnumerator DelayBaby(float waittime)
    {
        yield return new WaitForSeconds(waittime);

        Instantiate(BabyPrefab);

        arduinoReader.resetProgram();
    }

}
