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
    public string correctSentence;

    public SpriteRenderer Facesr;
    public SpriteRenderer Hairsr;
    public GameObject speechBubble;

    

    [SerializeField] Sprite[] babySprites;
    [SerializeField] Sprite newSprite;


    [SerializeField] Sprite[] faceSprites;
    [SerializeField] Sprite newFaceSprite;

    [SerializeField] Sprite[] hairSprites;
    [SerializeField] Sprite newHairSprite;


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

        float rng2 = Random.Range(0, 4);

        switch (rng2)
        {
            case 0:
                correctSentence = "innocent";
                break;
            case 1:
                correctSentence = "scolding";
                break;
            case 2:
                correctSentence = "cocolemon";
                break;
            case 3:
                correctSentence = "clean";
                break;
            case 4:
                correctSentence = "bedtime";
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
            plea();
        }
        else
        {

            Debug.Log("why");
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
        //
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
