using UnityEngine;
using TMPro;


public class JudgeBabyAnnounce : MonoBehaviour
{

    [SerializeField] GameObject[] JudgeCrimeTexts;
    [SerializeField] GameObject JudgeCurrentCrimeText;
    public int CrimeChoice;

    [SerializeField] GameObject[] BabyCrimeTexts;
    [SerializeField] GameObject BabyCurrentCrimeText;

    public TMP_Text JudgeTalk;
    public TMP_Text AccusedTalk;

    public bool babyGuilt;

    [SerializeField] string[] JudgeTextList;

    [SerializeField] string[] AccusedTextListGuilty; //80%

    [SerializeField] string[] AccusedTextListInnocent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //JudgeTalk.text = AccusedTextListInnocent[1];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void announce()
    {
        this.gameObject.transform.GetChild(0).gameObject.SetActive(true);

        /*if (CrimeChoice > JudgeCrimeTexts.Length)
        {
            
            CrimeChoice = JudgeCrimeTexts.Length - 1;
        }

        JudgeCurrentCrimeText = JudgeCrimeTexts[CrimeChoice];

        JudgeCurrentCrimeText.SetActive(true);
        */
        JudgeTalk.gameObject.SetActive(true);
        JudgeTalk.text = JudgeTextList[CrimeChoice];

    }

    public void Babyannounce()
    {
        this.gameObject.transform.GetChild(0).gameObject.SetActive(true);

        AccusedTalk.gameObject.SetActive(true);

        if (!babyGuilt)
        {
            AccusedTalk.text = AccusedTextListInnocent[CrimeChoice];
        }
        else
        {
            float ranAgain = Random.Range(0, 1);
            if (ranAgain > 0.8f)
            {
                AccusedTalk.text = AccusedTextListGuilty[CrimeChoice];
            }
            else
            {
                AccusedTalk.text = AccusedTextListInnocent[CrimeChoice];
                
            }



        }



        /*CrimeChoice *= 2;
        float randomChoice = Random.Range(0,2);

        if (randomChoice == 0)
        {
            BabyCurrentCrimeText = BabyCrimeTexts[CrimeChoice];
            
        }
        if (randomChoice == 1)
        {
            BabyCurrentCrimeText = BabyCrimeTexts[CrimeChoice + 1];
        }

        BabyCurrentCrimeText.SetActive(true);*/




    }

    public void Dennounce()
    {
        this.gameObject.transform.GetChild(0).gameObject.SetActive(false);

        AccusedTalk.gameObject.SetActive(false);

        JudgeTalk.gameObject.SetActive(false);

    }

}
