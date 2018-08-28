using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class GameStateText : MonoBehaviour {

    public string gameStateTag;
    public GameState gameState;
    public bool healText; //if not, it's destroyedText

    // Use this for initialization
    void Start () {
        gameState = GameObject.FindGameObjectWithTag(gameStateTag).GetComponent<GameState>();

        if (healText)
            GetComponent<Text>().text = gameState.getPercentAlive() + "%";
        else
            GetComponent<Text>().text = gameState.getPercentDead() + "%";
    }
	
}
