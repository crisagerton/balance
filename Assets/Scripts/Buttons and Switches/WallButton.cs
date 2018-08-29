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

    public AudioSource buttonsfx;
    public AudioSource wallsfx;

	void Start () {
        GetComponent<SpriteRenderer>().color = deactivationColor;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != player.GetComponent<Collider2D>())
            return;
        Activate();
        playSFX();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != player.GetComponent<Collider2D>())
            return;
        Deactivate();
        playSFX();
    }

    protected void Activate()
    {
        GetComponent<SpriteRenderer>().color = activationColor;
        wall.SetActive(false);
    }

    protected void Deactivate()
    {
        GetComponent<SpriteRenderer>().color = deactivationColor;
        wall.SetActive(true);
    }

    protected void playSFX()
    {
        if (buttonsfx)
            buttonsfx.Play();
        if (wallsfx)
            wallsfx.Play();
    }
}
