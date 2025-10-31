using System.Collections;
using System.Security.Policy;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AccusedBabyAlternative : MonoBehaviour
{
    private Vector3 startPosition;
    public Vector3 targetPosition;
    public float TargetModifyer = 15;

    public float waitTime = 4f; // Time to wait before starting lerping
    public float lerpTime = 2f; // Time taken to reach the target position
    public float speechDelay = 1f;
    bool sentenced = false;
    public string Crime;
    public bool guilty;

    public bool pleaStarted = false;

    public string CrimeType;

    public SpriteRenderer Facesr;
    public SpriteRenderer Hairsr;
    public SpriteRenderer EvidencesrFace;
    public SpriteRenderer EvidencesrHand;
    public SpriteRenderer EvidencesrEar;
    public GameObject speechBubble;

    public BabyProperties propertyScript; 

    [SerializeField] Sprite[] babySprites;
    [SerializeField] Sprite newSprite;


    [SerializeField] Sprite[] faceSprites;
    [SerializeField] Sprite newFaceSprite;

    [SerializeField] Sprite[] hairSprites;
    [SerializeField] Sprite newHairSprite;

    [SerializeField] Sprite[] evidenceSprites;
    [SerializeField] Sprite newEvidenceSprite;

    [SerializeField] string[] CrimeList;

    public GameObject propertyController;

    public float GuiltChance = 6f;
    public float evidenceChance = 3f;

    void Start()
    {

        propertyController = GameObject.Find("CurrentBabyProperties");
        propertyScript = propertyController.GetComponent<BabyProperties>();

        newSprite = babySprites[(Random.Range(0, babySprites.Length))];
        gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;

        newFaceSprite = faceSprites[(Random.Range(0, faceSprites.Length))];
        Facesr.sprite = newFaceSprite;

        newHairSprite = hairSprites[(Random.Range(0, hairSprites.Length))];
        Hairsr.sprite = newHairSprite;

        sentenced = false;
        startPosition = transform.position;
        
        StartCoroutine(StartLerping(waitTime));




        targetPosition = (Vector2)transform.position + Vector2.left * TargetModifyer;
        


        /*float RanNum = Random.Range(0, 4);

        switch (RanNum)
        {
            case 0:
                Facesr.color = Color.blue; break;
            case 1:
                Facesr.color = Color.magenta; break;
            case 2:
                Facesr.color = Color.green; break;

        }*/

        int rng2 = Random.Range(0, CrimeList.Length);

        GameObject judgeBaby = GameObject.Find("JudgeBaby");

        JudgeBabyAnnounce JudgeScript = judgeBaby.GetComponent<JudgeBabyAnnounce>();

        JudgeScript.CrimeChoice = rng2;

        JudgeScript.babyGuilt = guilty;

        Crime = CrimeList[rng2];

        /*switch (rng2)
        {
            case 0:
                Crime = CrimeList[rng2];
                
                break;
            case 1:
                Crime = "MakingMess";
                break;
            case 2:
                Crime = "DrawingOnWall";
                break;
        }*/

        

        float GuiltDecide = Random.Range(0, GuiltChance);
        //Debug.Log("GuiltChance[" + GuiltChance.ToString() + "] GuiltDecide[" + GuiltDecide.ToString() + "]");

        if ((GuiltDecide < 1))
        {
            guilty = false;

            float evidenceDecide = Random.Range(0, evidenceChance);

            if ((evidenceDecide < 1))
            {
                int evidencechoice = Random.Range(0, CrimeList.Length);

                /*if ((evidencechoice == rng2))
                {

                }
                else
                {

                }*/

                while (evidencechoice == rng2)
                {
                    evidencechoice = Random.Range(0, CrimeList.Length);
                }

                newEvidenceSprite = evidenceSprites[(evidencechoice)];
                if ((evidencechoice == 0) || (evidencechoice == 4) || (evidencechoice == 5) || (    evidencechoice == 7) || (evidencechoice == 12) || (evidencechoice == 13) || (evidencechoice == 14))
                {
                    EvidencesrFace.sprite = newEvidenceSprite;
                }
                else if ((evidencechoice == 1) || (evidencechoice == 2) || (evidencechoice == 3) || (evidencechoice == 6) || (evidencechoice     == 9) || (evidencechoice == 10) || (evidencechoice == 15) || (evidencechoice == 16) || (evidencechoice == 17) || (evidencechoice == 18 || (evidencechoice == 20)))
                {
                    EvidencesrHand.sprite = newEvidenceSprite;
                }
                else
                {
                    EvidencesrEar.sprite = newEvidenceSprite;
                }
            }


        }
        else
        {
            guilty = true;
            newEvidenceSprite = evidenceSprites[(rng2)];
            if ((rng2 == 0) || (rng2 == 4) || (rng2 == 5) || (rng2 == 7) || (rng2 == 12) || (rng2 == 13) || (rng2 == 14))
            {
                EvidencesrFace.sprite = newEvidenceSprite;
            }
            else if ((rng2 == 1) || (rng2 == 2) || (rng2 == 3) || (rng2 == 6) || (rng2 == 9) || (rng2 == 10) || (rng2 == 15) || (rng2 == 16) || (rng2 == 17) || (rng2 == 18 || (rng2 == 20)))
            {
                EvidencesrHand.sprite = newEvidenceSprite;
            }
            else
            {
                EvidencesrEar.sprite = newEvidenceSprite;
            }
            

            if (rng2 < 6)
            {
                CrimeType = "MakingMess";
            }
            else if ((rng2 >= 6) && (rng2 < 11))
            {
                CrimeType = "Bullying";
            }
            else if ((rng2 >= 11) && (rng2 < 16))
            {
                CrimeType = "Theft";
            }
            else
            {
                CrimeType = "Troublemaking";
            }

        }


        propertyScript.CrimeTypeProperty = CrimeType;
        propertyScript.guilty = guilty; 

    }


    private void Update()
    {
        
    }



    IEnumerator StartLerping(float waitTime)
    {
        
        float elapsedTime = 0f;

        while (elapsedTime < lerpTime)
        {
            float t = elapsedTime / lerpTime;
            transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            elapsedTime += Time.deltaTime;
            

            yield return null;
        }

        transform.position = targetPosition; 


        if (!sentenced)
        {

            GameObject judgeBaby = GameObject.Find("JudgeBaby");
            //GameObject judgeBabySpeech = judgeBaby.transform.GetChild(0).gameObject;
            //judgeBabySpeech.SetActive(true);
            JudgeBabyAnnounce JudgeScript = judgeBaby.GetComponent<JudgeBabyAnnounce>();
            JudgeScript.announce();


            yield return new WaitForSeconds(1.5f);

            plea();
        }
        else
        {

            
            GameObject tempObject = GameObject.Find("Canvas");

            tempObject.GetComponent<Timer>().enabled = false;

            tempObject.GetComponent<Timer>().timer = tempObject.GetComponent<Timer>().InitialTime;

            DebugOptions DebugOptionsScript = tempObject.GetComponent<DebugOptions>();

            DebugOptionsScript.BabySpawnVerdict();

            
            Destroy(gameObject);
        }
        
    }

    


    void plea()
    {
        pleaStarted = true;
        propertyScript.pleaStarted = true;
        GameObject tempObject = GameObject.Find("Canvas");

        tempObject.GetComponent<Timer>().enabled = true;
        tempObject.GetComponent<Timer>().buttonPressed = false;

        GameObject judgeBaby = GameObject.Find("JudgeBaby");
        JudgeBabyAnnounce JudgeScript = judgeBaby.GetComponent<JudgeBabyAnnounce>();
        JudgeScript.Babyannounce();

        speechBubble.SetActive(true);
        
    }


    public void BeGone()
    {

        GameObject judgeBaby = GameObject.Find("JudgeBaby");
        JudgeBabyAnnounce JudgeScript = judgeBaby.GetComponent<JudgeBabyAnnounce>();

        JudgeScript.Dennounce();

        //judgeBaby.SetActive(false);
        sentenced = true;

        gameObject.GetComponent<SpriteRenderer>().flipX = true;
        Hairsr.flipX = true;
        Facesr.flipX = true;

        speechBubble.SetActive(false);
        pleaStarted = false;
        propertyScript.pleaStarted = false;
        startPosition = transform.position;
        targetPosition = (Vector2)transform.position + Vector2.right * TargetModifyer;
        //Debug.Log(startpositionTransformd.transform);
        StartCoroutine(StartLerping(0));

    }


    

}
