using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : MonoBehaviour {

    public List<GameObject> players;
    public KeyCode activationKey;

    private bool playersReady = false;

    private void Update()
    {
        if (playersReady && Input.GetKey(activationKey))
        {
            Application.Quit();
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
}
