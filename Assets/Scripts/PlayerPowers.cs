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

    public int limit = 5;
    public powerType power;


    public enum powerType
    {
        BigWhenApartLimited, BigWhenApartUnlimited,
        BigWhenTogether, BigWhenBalanced
    }
	
	void Update () {
        handleGlowGrowth();
    }

    void handleGlowGrowth()
    {
        switch (power)
        {
            case powerType.BigWhenApartLimited:
                apartGrowthLimited();
                break;
            case powerType.BigWhenApartUnlimited:
                apartGrowthUnlimited();
                break;
            case powerType.BigWhenTogether:
                togetherGrowth();
                break;
            case powerType.BigWhenBalanced:
                balancedGrowth();
                break;
            default:
                break;
        }
    }

    #region Growth Functions
    void apartGrowthLimited()
    {
        /// Places a limit to how big the powers get
        /// Otherwise the powers will grow based on the distance between them

        if (partnerInRange(limit))
        {
            float distance = getDistanceFromPartner();
            glow.transform.localScale = new Vector3(distance, distance, 0);
        }
        else if (glow.transform.localScale.x < limit)
        {
            glow.transform.localScale += new Vector3(1, 1, 0);
        }
    }

    void apartGrowthUnlimited()
    {
        /// Does not place a limit to how big the powers can get
        /// Results in powers that always cover the distance between players

        float distance = getDistanceFromPartner();
        glow.transform.localScale = new Vector3(distance, distance, 0);
    }

    void togetherGrowth()
    {
        /// Requires players to be near each other to use their powers
        /// The closer they are, the more effective their powers are

        float distance = getDistanceFromPartner();
        if (1 / distance * limit >= 1)
            glow.transform.localScale = new Vector3(1 / distance * limit, 1 / distance * limit, 0);
    }

    void balancedGrowth()
    {
        /// Requires players to maintain a balanced distance to use their powers
        /// If they move too far, they won't be able to use their powers
        /// If they are too close, they loose some power

        float distance = getDistanceFromPartner();

        if (partnerInRange(limit))
        {
            glow.transform.localScale = new Vector3(distance, distance, 0);
        }
        else
        {
            float diff = 0;
            if (distance - limit <= limit - diff)
                diff = limit - (distance - limit);
            glow.transform.localScale = new Vector3(diff, diff, 0);
        }
    }
    #endregion

    #region Helper Functions
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
    #endregion
}
