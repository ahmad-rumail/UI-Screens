using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AutoScroll : MonoBehaviour
{
    private float speed = 100.0f;
    private float textPosBegin = -1392.0f;
    private float boundaryTextEnd = 1392.0f;
    
    RectTransform myGorectTransform;
    [SerializeField] 
    private TextMeshProUGUI mainText;

    [SerializeField] 
    private bool isLooping = false;
    
    // Start is called before the first frame update
    void Start()
    {
        myGorectTransform = gameObject.GetComponent<RectTransform>();
        StartCoroutine(AutoScrollText());
    }

    IEnumerator AutoScrollText()
    {
        while (myGorectTransform.localPosition.y < boundaryTextEnd)
        {
            myGorectTransform.Translate(Vector3.up*speed*Time.deltaTime);

            if (myGorectTransform.localPosition.y > boundaryTextEnd)
            {
                if (isLooping)
                {
                    myGorectTransform.localPosition = Vector3.up * textPosBegin;
                }

                else
                {
                    break;
                }
            }
            
            yield return null;
        }    
    }
    
}
