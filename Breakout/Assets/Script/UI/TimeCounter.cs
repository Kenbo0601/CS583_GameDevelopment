using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeCounter : MonoBehaviour
{
    [Header("Dynamic")] 
    public float elapsedTime = 0f;
    private bool isCounting = false;
    private TextMeshProUGUI gt;
    
    void Start()
    {
        gt = GetComponent<TextMeshProUGUI>();
        isCounting = true;
    }

    void Update()
    {
        if (isCounting)
        {
            elapsedTime += Time.deltaTime; // add the time since the last frame to the elapsed time 
            gt.text = "TIME: " + TimeConversionUtils.ConvertTime(elapsedTime); // invoke utility function for time conversion 
        }
    } 
}
