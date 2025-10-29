using UnityEngine;

public class JudgeBabyAnnounce : MonoBehaviour
{

    [SerializeField] GameObject[] CrimeTexts;
    [SerializeField] GameObject CurrentCrimeText;
    public int CrimeChoice;
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

        CurrentCrimeText = CrimeTexts[CrimeChoice];

        CurrentCrimeText.SetActive(true);

    }

    public void Dennounce()
    {
        this.gameObject.transform.GetChild(0).gameObject.SetActive(false);

        CurrentCrimeText.SetActive(false);

    }

}
