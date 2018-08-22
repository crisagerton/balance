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

    private void Update()
    {
        Debug.Log("Player Ready: " + playersReady);
        Debug.Log("activated: " + Input.GetKey(activationKey));
        if (playersReady && Input.GetKey(activationKey))
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (GameObject player in players)
        {
            if (collision.gameObject != player)
                return;
            showInstructions();
            playersReady = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playersReady = false;
    }

    private void showInstructions()
    {
        if (instructions)
            instructions.gameObject.SetActive(true);
    }


}
