using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDualSwitch : WallButton {
    public GameObject otherButton;
    public bool switchedOn;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != player.GetComponent<Collider2D>() || !wall.activeSelf)
            return;

        switchedOn = true;
        GetComponent<SpriteRenderer>().color = activationColor;

        if (switchedOn && otherButton.GetComponent<WallDualSwitch>().switchedOn)
        {
            Activate();
            otherButton.GetComponent<WallDualSwitch>().Activate();
            playSFX();
        }
        else
            Deactivate();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != player.GetComponent<Collider2D>() || !wall.activeSelf)
            return;

        switchedOn = false;
        GetComponent<SpriteRenderer>().color = deactivationColor;
    }
}
