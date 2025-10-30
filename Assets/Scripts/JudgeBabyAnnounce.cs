using UnityEngine;
using TMPro;


public class JudgeBabyAnnounce : MonoBehaviour
{

    [SerializeField] GameObject[] JudgeCrimeTexts;
    [SerializeField] GameObject JudgeCurrentCrimeText;
    public int CrimeChoice;

    [SerializeField] GameObject[] BabyCrimeTexts;
    [SerializeField] GameObject BabyCurrentCrimeText;

    TMP_Text JudgeTalk;

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

        if (CrimeChoice > JudgeCrimeTexts.Length)
        {
            
            CrimeChoice = JudgeCrimeTexts.Length - 1;
        }

        JudgeCurrentCrimeText = JudgeCrimeTexts[CrimeChoice];

        JudgeCurrentCrimeText.SetActive(true);




    }

    public void Babyannounce()
    {
        this.gameObject.transform.GetChild(0).gameObject.SetActive(true);

        CrimeChoice *= 2;
        float randomChoice = Random.Range(0,2);

        if (randomChoice == 0)
        {
            BabyCurrentCrimeText = BabyCrimeTexts[CrimeChoice];
            
        }
        if (randomChoice == 1)
        {
            BabyCurrentCrimeText = BabyCrimeTexts[CrimeChoice + 1];
        }

        BabyCurrentCrimeText.SetActive(true);




    }

    public void Dennounce()
    {
        this.gameObject.transform.GetChild(0).gameObject.SetActive(false);

        BabyCurrentCrimeText.SetActive(false);

        JudgeCurrentCrimeText.SetActive(false);

    }

}
