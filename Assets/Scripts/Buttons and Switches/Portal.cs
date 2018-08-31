using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour {
    /// <summary>
    /// Objects with this script will act as portals to the specified scene
    /// </summary>

    public string sceneName;
    public List<GameObject> players;
    public KeyCode activationKey;
    public Text instructions; //This isn't necessary, but is good for tutorial levels

    private bool playersReady = false;
    private List<Collider2D> playersColliding = new List<Collider2D>();

    private void Update()
    {
        if (playersReady && Input.GetKey(activationKey))
        {
            SceneManager.LoadScene(sceneName);
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


}
