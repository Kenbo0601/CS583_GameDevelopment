using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // This enables use of uGUI classes like Text
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    [Header("Dynamic")] 
    public int score = 0; 
    //private Text uiText;
    private TextMeshProUGUI gt;
    
    // Start is called before the first frame update
    void Start()
    {
        //uiText = GetComponent<Text>();
        gt = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (score < 0)
        {
            score = 0;
        }
        //uiText.text = score.ToString("#,0");
        gt.text = score.ToString("#,0");
    }
}
