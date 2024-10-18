using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BestTime : MonoBehaviour
{
    // Start is called before the first frame update
    static private TextMeshProUGUI gt;
    static private float _TIME = 10f;
    
    
    // Awake is a built-in function, gets called before Start()
    private void Awake()
    {
        gt = GetComponent<TextMeshProUGUI>();
        
        // If the PlayerPrefs HighScore already exists, read
        if (PlayerPrefs.HasKey("BestTime"))
        {
            TIME = PlayerPrefs.GetFloat("BestTime");
        }
        
        // Assign the best time to bestTime
        PlayerPrefs.SetFloat("BestTime", TIME);
    }

    // property field
    static public float TIME
    {
        get { return _TIME; }
        private set
        {
            _TIME = value;
            PlayerPrefs.SetFloat("BestTime",value);
            int min = Mathf.FloorToInt(value / 60F);
            int sec = Mathf.FloorToInt(value % 60F);
            int milliSec = Mathf.FloorToInt((value * 100F) % 100F);
            
            if (gt != null)
            {
                gt.text = "Best Time: " +  $"{min:D2}:{sec:D2}:{milliSec:D2}";
            }
        }
    }

    static public void TRY_SET_BEST_TIME(float timeToTry)
    {
        if(timeToTry <= TIME) return;
        TIME = timeToTry;
    }

    [Tooltip("Check this box to reset the BestTime in PlayerPrefs")]
    public bool resetBestTimeNow = false;

    private void OnDrawGizmos()
    {
        if (resetBestTimeNow)
        {
            resetBestTimeNow = false;
            PlayerPrefs.SetFloat("BestTime", 10f);
        }
    }
}
