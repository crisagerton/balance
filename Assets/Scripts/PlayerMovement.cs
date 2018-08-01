using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    /// <summary>
    /// Player movement for Local Multiplayer
    /// </summary>

    public bool isLeft; //determines controls
    public int speed;

    private KeyCode upKey;
    private KeyCode downKey;
    private KeyCode leftKey;
    private KeyCode rightKey;

	void Start () {
        setControls(isLeft); 
        
	}
	
	void Update () {
        Move();
	}

    void Move()
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
        gameObject.transform.Translate(movement);
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
}
