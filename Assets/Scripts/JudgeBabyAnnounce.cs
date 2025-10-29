using UnityEngine;

public class JudgeBabyAnnounce : MonoBehaviour
{

    [SerializeField] GameObject[] JudgeCrimeTexts;
    [SerializeField] GameObject JudgeCurrentCrimeText;
    public int CrimeChoice;

    [SerializeField] GameObject[] BabyCrimeTexts;
    [SerializeField] GameObject BabyCurrentCrimeText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void announce()
    {
        this.gameObject.transform.GetChild(0).gameObject.SetActive(true);

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
            Debug.Log("cry");
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
