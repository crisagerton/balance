using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class WallButton : MonoBehaviour {
    /// <summary>
    /// Handles all funcitonalities for wall buttons
    /// which activate/deactivate the designated wall if collided with
    /// </summary>

    public Color deactivationColor;
    public Color activationColor;

    public GameObject wall;
    public GameObject player;

	void Start () {
        GetComponent<SpriteRenderer>().color = deactivationColor;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != player.GetComponent<Collider2D>())
            return;
        GetComponent<SpriteRenderer>().color = activationColor;
        wall.SetActive(false);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != player.GetComponent<Collider2D>())
            return;
        GetComponent<SpriteRenderer>().color = deactivationColor;
        wall.SetActive(true);
    }
}
