using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AccusedBabyMove : MonoBehaviour
{
    public Transform targetPosition;
    public float WaitTime = 4f; // Time to wait before starting lerping
    public float lerpTime = 2f; // Time taken to reach the target position
    public float Speechdelay = 1f;
    bool Sentenced = false;

    public GameObject child1;
    public GameObject child2;


    private Vector3 startPosition;
    public Transform startpositionTransformd;

    public GameObject greenbaby;
    public GameObject bluebaby;
    public GameObject pinkbaby;

    void Start()
    {
        Sentenced = false;
        startPosition = transform.position;
        //startpositionTransform = transform;
        StartCoroutine(StartLerping(WaitTime));
        //Debug.Log(startpositionTransform.position);
        child1.transform.SetParent(null);
        child2.transform.SetParent(null);


        float RanNum = Random.Range(0, 4);

        if (RanNum == 0)
        {
            greenbaby.SetActive(true);
        }
        else if (RanNum == 1)
        {
            bluebaby.SetActive(true);
        }
        else
        {
            pinkbaby.SetActive(true);
        }
    }

    IEnumerator StartLerping(float waittime)
    {
        
        yield return new WaitForSeconds(WaitTime); // Wait for 4 seconds

        float elapsedTime = 0f;
        //Debug.Log(elapsedTime.ToString());

        while (elapsedTime < lerpTime)
        {
            float t = elapsedTime / lerpTime;
            transform.position = Vector3.Lerp(startPosition, targetPosition.position, t);
            elapsedTime += Time.deltaTime;


            yield return null;
        }

        transform.position = targetPosition.position; // Ensure object reaches exactly at target position

        yield return new WaitForSeconds(Speechdelay); 
        if (!Sentenced)
        {
            plea();
        }
        else
        {
            

            GameObject tempObject = GameObject.Find("Canvas");

            tempObject.GetComponent<Timer>().enabled = false;

            tempObject.GetComponent<Timer>().timer = 5;

            DebugOptions DebugOptionsScript = tempObject.GetComponent<DebugOptions>();

            DebugOptionsScript.BabySpawnVerdict();

            Destroy(child1);
            Destroy(child2);
            Destroy(gameObject);
        }
        
    }


    

    void plea()
    {
        GameObject tempObject = GameObject.Find("Canvas");

        tempObject.GetComponent<Timer>().enabled = true;


        GameObject Speechbubble = this.gameObject.transform.GetChild(0).gameObject;
        Speechbubble.SetActive(true);
        
    }


    public void BeGone()
    {
        Sentenced = true;

        Debug.Log("oof");
        //Speechbubble.SetActive(false);
        startPosition = transform.position;
        targetPosition = startpositionTransformd;
        //Debug.Log(startpositionTransformd.transform);
        StartCoroutine(StartLerping(WaitTime));

    }


    

}
