using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// This class is for the paddle that a player controls during the game
public class PlayerPaddle : MonoBehaviour
{
    [Header("Inscribed")]
    public float boundry = 10f;

    
    void Update()
    {
        // Get the current screen position of the mouse from input
        Vector3 mousePos2D = Input.mousePosition;
        
        // The Camera's z position sets how far to push the mouse into 3D
        mousePos2D.z = -Camera.main.transform.position.z;
        
        // Convert the point from 2D screen space into 3D game world space
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        
        
        //if within the boundry (left and right walls)
        if (mousePos3D.x < boundry && mousePos3D.x > -boundry)
        {
            Vector3 pos = this.transform.position;
            pos.x = mousePos3D.x;
            this.transform.position = pos;
        }
    }
}
