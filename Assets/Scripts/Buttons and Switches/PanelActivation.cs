using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelActivation : MonoBehaviour {

    public GameObject panel;

    public List<GameObject> players;
    public KeyCode activationKey;

    private bool playersReady = false;

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
        foreach (GameObject player in players)
        {
            if (collision.gameObject != player)
                return;
            playersReady = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playersReady = false;
    }

    private void showPanel()
    {
        Debug.Log("showing");
        panel.SetActive(true);
        foreach (GameObject player in players)
            player.SetActive(false);
    }

    private void hidePanel()
    {
        Debug.Log("not showing");
        panel.SetActive(false);
        foreach (GameObject player in players)
            player.SetActive(true);
    }
}
