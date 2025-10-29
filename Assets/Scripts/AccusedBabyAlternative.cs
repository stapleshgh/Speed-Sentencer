using System.Collections;
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

    public SpriteRenderer Facesr;
    public SpriteRenderer Hairsr;
    public SpriteRenderer Evidencesr;
    public GameObject speechBubble;

    

    [SerializeField] Sprite[] babySprites;
    [SerializeField] Sprite newSprite;


    [SerializeField] Sprite[] faceSprites;
    [SerializeField] Sprite newFaceSprite;

    [SerializeField] Sprite[] hairSprites;
    [SerializeField] Sprite newHairSprite;

    [SerializeField] Sprite[] evidenceSprites;
    [SerializeField] Sprite newEvidenceSprite;


    


    void Start()
    {

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

        int rng2 = Random.Range(0, 2);

        GameObject judgeBaby = GameObject.Find("JudgeBaby");

        JudgeBabyAnnounce JudgeScript = judgeBaby.GetComponent<JudgeBabyAnnounce>();

        JudgeScript.CrimeChoice = rng2;

        switch (rng2)
        {
            case 0:
                Crime = "CookieTheft";
                
                break;
            case 1:
                Crime = "MakingMess";
                break;
            case 2:
                Crime = "DrawingOnWall";
                break;
        }


        

        float GuiltDecide = Random.Range(0, 2);

        switch (GuiltDecide)
        {
            case 0:
                guilty = true;
                newEvidenceSprite = evidenceSprites[(Random.Range(0, evidenceSprites.Length))];
                Evidencesr.sprite = newEvidenceSprite;
                break;
            case 1: 
                guilty = false;
                break;
        }
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

            tempObject.GetComponent<Timer>().timer = 5;

            DebugOptions DebugOptionsScript = tempObject.GetComponent<DebugOptions>();

            DebugOptionsScript.BabySpawnVerdict();

            
            Destroy(gameObject);
        }
        
    }

    


    void plea()
    {
        GameObject tempObject = GameObject.Find("Canvas");

        tempObject.GetComponent<Timer>().enabled = true;


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
        startPosition = transform.position;
        targetPosition = (Vector2)transform.position + Vector2.right * TargetModifyer;
        //Debug.Log(startpositionTransformd.transform);
        StartCoroutine(StartLerping(0));

    }


    

}
