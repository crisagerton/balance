using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowers : MonoBehaviour {

    public bool isHealer; //if true, has healing powers. if false, has destroying powers
    public GameObject glow;
    public GameObject partner;

    private int range = 5;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        handleGlowGrowth();
    }

    void handleGlowGrowth()
    {
        #region Unused Distance Code
        /*
         * Concerning the below code:
         * This is for if I decide there should be a limit to how big the powers get
         * Otherwise the powers will grow based on the distance between them
         */
        //if (!partnerInRange(range) && glow.transform.localScale.x < range)
        //    glow.transform.localScale += new Vector3(1, 1, 0);
        //else if (partnerInRange(range))
        //{
        //    float distance = getDistanceFromPartner();
        //    glow.transform.localScale = new Vector3(distance, distance, 0);
        //}
        #endregion

        float distance = getDistanceFromPartner();
        glow.transform.localScale = new Vector3(distance, distance, 0);
    }

    public BoundsInt getBoundary()
    {
        Vector3 center = transform.position;
        float radius = getDistanceFromPartner() / 2;

        Vector3Int topCorner = new Vector3Int((int) (center.x + radius),
            (int) (center.y + radius), (int) (center.z + radius));
        Vector3Int bottomCorner = new Vector3Int((int)(center.x - radius),
            (int)(center.y - radius), (int)(center.z - radius));

        BoundsInt bi = new BoundsInt(topCorner, bottomCorner);
        return bi;
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
