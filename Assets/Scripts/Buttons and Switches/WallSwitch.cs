using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSwitch : WallButton {
    /// <summary>
    /// Similar to WallButton, but lowers wall until swtiched off
    /// </summary>

    public bool startActive;

    void Start()
    {
        if (startActive)
            Activate();
        else
            Deactivate();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != player.GetComponent<Collider2D>())
            return;
        if (wall.activeSelf)
            Activate();
        else
            Deactivate();
       
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

    }
}
