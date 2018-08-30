using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class GameStateText : MonoBehaviour {

    public string gameStateTag;
    public GameState gameState;
    public TextType textType;

    public enum TextType
    {
        healPercent,
        destroyPercent,
        endResult
    }

    // Use this for initialization
    void Start () {
        gameState = GameObject.FindGameObjectWithTag(gameStateTag).GetComponent<GameState>();

        if (textType == TextType.healPercent || textType == TextType.destroyPercent)
            handlePercentTexts();
        else
            handleResultText();
    }

    void handlePercentTexts()
    {
        float percent;

        if (textType == TextType.healPercent)
            percent = gameState.getPercentAlive();
        else
            percent = 100 - gameState.getPercentAlive();

        GetComponent<Text>().text = string.Format("{0:000}%", percent);
    }

    void handleResultText()
    {
        float alivePercent = gameState.getPercentAlive();

        if (alivePercent == 100)
            changeTextAndColor("ONLY LIFE", Color.white);
        else if (alivePercent == 0)
            changeTextAndColor("ONLY DEATH", Color.black);
        else if (alivePercent == 50)
            changeTextAndColor("PERFECT BALANCE", Color.green);
        else
            changeTextAndColor("IMBALANCE", Color.grey);
    }

    void changeTextAndColor(string newText, Color color)
    {
        GetComponent<Text>().text = newText;
        GetComponent<Text>().color = color;
    }
	
}
