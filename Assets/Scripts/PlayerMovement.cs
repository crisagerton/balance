using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    /// <summary>
    /// Player movement for Local Multiplayer
    /// </summary>

    public bool isLeft; //determines controls
    public int speed;
    public Camera cam;

    private KeyCode upKey;
    private KeyCode downKey;
    private KeyCode leftKey;
    private KeyCode rightKey;

	void Start () {
        setControls(isLeft); 
	}
	
	void Update () {
        if (cam)
            RestrictMove();
        else
            Move();
	}

    void Move()
    {
        /// Unrestricted movement
        Vector3 movement = getMovement();
        gameObject.transform.Translate(movement);
    }

    void RestrictMove()
    {
        /// Restricted movement
        Vector3 movement = getMovement();
        if (inCamBounds(transform.position + movement))
            gameObject.transform.Translate(movement);
    }

    Vector3 getMovement()
    {
        Vector3 movement = new Vector3(0, 0, 0);
        float truespeed = (float)speed / 10;
        if (Input.GetKey(upKey))
            movement = new Vector3(0, truespeed, 0);
        if (Input.GetKey(downKey))
            movement = new Vector3(0, -truespeed, 0);
        if (Input.GetKey(leftKey))
            movement = new Vector3(-truespeed, 0, 0);
        if (Input.GetKey(rightKey))
            movement = new Vector3(truespeed, 0, 0);

        return movement;
    }

    void setControls(bool isLeftSide)
    {
        /// <summary>
        /// isLeftSide == true : left side, makes controls WASD
        /// isLeftSide == false : right side, makes controls arrow keys
        /// </summary>

        if (isLeftSide)
        {
            upKey = KeyCode.W;
            downKey = KeyCode.S;
            leftKey = KeyCode.A;
            rightKey = KeyCode.D;
        }
        else
        {
            upKey = KeyCode.UpArrow;
            downKey = KeyCode.DownArrow;
            leftKey = KeyCode.LeftArrow;
            rightKey = KeyCode.RightArrow;
        }
    }

    bool inCamBounds(Vector3 center, int radius)
    {
        ///Checks to see if CIRCLE is fully in bounds
        ///hence why the z can be 0
        return inCamBounds(new Vector3(center.x + radius, center.y + radius, 0)) ||
            inCamBounds(new Vector3(center.x + radius, center.y + radius, 0));
    }

    bool inCamBounds(Vector3 position)
    {
        ///Checks to see if position is in bounds
        Bounds camBounds = getCameraBounds();
        return camBounds.max.x >= position.x &&
            camBounds.max.y >= position.y &&
            camBounds.min.x <= position.x &&
            camBounds.min.y <= position.y;
    }


    Bounds getCameraBounds()
    {
        /// Reference:
        /// https://answers.unity.com/questions/501893/calculating-2d-camera-bounds.html

        float screenAspect = (float)Screen.width / (float)Screen.height;
        float cameraHeight = cam.orthographicSize * 2;
        Bounds bounds = new Bounds(
            cam.transform.position,
            new Vector3(cameraHeight * screenAspect, cameraHeight, 0));
        return bounds;
    }
}
