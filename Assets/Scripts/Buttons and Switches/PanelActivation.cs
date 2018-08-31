using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelActivation : MonoBehaviour {

    public GameObject panel;

    public List<GameObject> players;
    public KeyCode activationKey;
    public Text instructions; //This isn't necessary, but is good for tutorial levels

    private bool playersReady = false;
    private List<Collider2D> playersColliding = new List<Collider2D>();

    // Use this for initialization
    void Start () {
        panel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (!playersReady)
            return;
        if (Input.GetKeyDown(activationKey))
        {
            if (!panel.activeSelf)
                showPanel();
            else
                hidePanel();
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!checkColliderIsPlayer(collision))
            return;

        playersColliding.Add(collision);

        if (players.Count != playersColliding.Count)
            return;
        showInstructions();
        playersReady = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!playersColliding.Contains(collision))
            return;
        playersColliding.Remove(collision);
        playersReady = false;
        hideInstructions();
    }

    private void showPanel()
    {
        Debug.Log("showing");
        panel.SetActive(true);
        foreach (GameObject player in players)
            player.SetActive(false);
        hideInstructions();
    }

    private void hidePanel()
    {
        Debug.Log("not showing");
        panel.SetActive(false);
        foreach (GameObject player in players)
            player.SetActive(true);
        showInstructions();
    }

    private bool checkColliderIsPlayer(Collider2D collision)
    {
        bool playerConfirmed = false;
        foreach (GameObject player in players)
            if (player.GetComponent<Collider2D>() == collision)
            {
                playerConfirmed = true;
                break;
            }
        return playerConfirmed;
    }

    private void showInstructions()
    {
        if (instructions)
            instructions.gameObject.SetActive(true);
    }

    private void hideInstructions()
    {
        if (instructions)
            instructions.gameObject.SetActive(false);
    }
}
