using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("Inscribed")] 
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;
    public ScoreCounter scoreCounter; // keeps track of the score
   
    
    // Start is called before the first frame update
    
    // instantiate three copies of the Basket prefab that are spaced out vertically
    // but it's not going to run until we attach it to a GameObject in the scene. 
    void Start()
    {
        // find a GameObject named ScoreCounter in the Scene Hierarchy
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        
        // Get the ScoreCounter (Script) component of scoreGO
        scoreCounter = scoreGO.GetComponent<ScoreCounter>();
        
        // create a basketList 
        basketList = new List<GameObject>();
        
        for (int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
    }

    public void AppleMissed()
    {
        // Destroy all of the falling Apples
        GameObject[] appleArray = GameObject.FindGameObjectsWithTag("Apple");
        GameObject[] badAppleArray = GameObject.FindGameObjectsWithTag("BadApple");
        foreach (GameObject tempGO in appleArray)
        {
            Destroy(tempGO);
        }

        foreach (GameObject tempGO in badAppleArray)
        {
            Destroy(tempGO);
        }

        // Destroy one of the baskets

        // get the index of the last basket in basketList
        int basketIndex = basketList.Count - 1;

        // get a reference to that Basket GameOject
        GameObject basketGO = basketList[basketIndex];

        // Remove the Basket from the list and destroy the GameObject
        basketList.RemoveAt(basketIndex);
        Destroy(basketGO);

        // If there are no Baskets left, restart the game 
        if (basketList.Count == 0)
        {
            SceneManager.LoadScene("_Scene_0");
        }

    }
    

    // Update is called once per frame
    void Update()
    {
      
    }
    
}
