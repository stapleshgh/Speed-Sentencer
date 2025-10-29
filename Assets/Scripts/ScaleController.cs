using UnityEngine;

public class ScaleController : MonoBehaviour
{

    public Transform pivot1; 
    public Transform pivot2; 

    public Transform hang1; 
    public Transform hang2; 

    public Transform basePart; 

    public Counter verdictScript; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     

    }

    // Update is called once per frame
    void Update()
    {
        
        followPivot();
        rotateScale();
    }

    private void followPivot()
    {

        hang1.position = pivot1.position; 
        hang2.position = pivot2.position; 

    }

    private void rotateScale()
    {

        int badV = verdictScript.badVCount; 
        int goodV = verdictScript.goodVCount; 

        float maxBadV = 7; 
        float maxRotateValue = -45; 

        float rotateValue = (badV - goodV) * (maxRotateValue/maxBadV); 


        if (badV - goodV > 7)
        {

            basePart.rotation = Quaternion.Euler(0, 0, maxRotateValue);

        }
        else if (badV > goodV)
        {

            basePart.rotation = Quaternion.Euler(0, 0, rotateValue); 

        }
        else 
        {

            basePart.rotation = Quaternion.Euler(0, 0, 0); 

        }

    }

}
