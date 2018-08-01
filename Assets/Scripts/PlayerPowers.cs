using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowers : MonoBehaviour {
    /// <summary>
    /// Helps control the extent of the player's powers (the glow)
    /// Growth is based on the player's distance from their partner
    /// </summary>

    public bool isHealer; //if true, has healing powers. if false, has destroying powers
    public GameObject glow;
    public GameObject partner;

    private int range = 5;
	
	void Update () {
        handleGlowGrowth();
    }

    void handleGlowGrowth()
    {
        #region Distance Code - Limited Ver
        /*
         * Concerning the below code:
         * Places a limit to how big the powers get
         * Otherwise the powers will grow based on the distance between them
         */
        if (!partnerInRange(range) && glow.transform.localScale.x < range)
            glow.transform.localScale += new Vector3(1, 1, 0);
        else if (partnerInRange(range))
        {
            float distance = getDistanceFromPartner();
            glow.transform.localScale = new Vector3(distance, distance, 0);
        }
        #endregion

        #region Distance Code - Unlimited Ver
        /*
         * Concerning the below code:
         * Does not place alimit to how big the powers can get
         * Results in powers that always cover the distance between players
         */
        //float distance = getDistanceFromPartner();
        //glow.transform.localScale = new Vector3(distance, distance, 0);
        #endregion
    }


    bool partnerInRange(int targetRange)
    {
        float distance = getDistanceFromPartner();

        return (distance <= targetRange);
    }

    float getDistanceFromPartner()
    {
        Vector3 partnerLocation = partner.transform.position;
        Vector3 playerLocation = transform.position;

        return getDistanceBetween(partnerLocation, playerLocation);
    }

    float getDistanceBetween(Vector3 position1, Vector3 position2)
    {
        Vector3 difference = position1 - position2;
        return difference.magnitude;
    }
}
