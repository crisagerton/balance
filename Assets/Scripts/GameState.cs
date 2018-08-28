using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameState : MonoBehaviour {

    public int totalChangableTiles = 0;
    public int totalDead = 0;
    public int totalAlive = 0;

    private int numCurrentLevelTiles = 0;
    private int numCurrentAlive = 0;
    private int numCurrentDead = 0;

    private List<TileChange> tileChanges = new List<TileChange>();

    public float getPercentAlive()
    {
        if (totalChangableTiles != 0)
            return (float) totalAlive / (float) totalChangableTiles * 100;
        return 0;
    }

    public float getPercentDead()
    {
        if (totalChangableTiles != 0)
            return (float) totalDead / (float) totalChangableTiles * 100;
        return 0;
    }

	void Start () {
        DontDestroyOnLoad(this.gameObject);
        OnLevelWasLoaded(0);
	}
	
	void Update () {
        updateAliveAndDead();
    }

    private void OnLevelWasLoaded(int level)
    {
        ///Sets up the necessary tile information for this level

        handlePreviousSceneTotals();
        clearCurrentVars();
        setCurrentVars();
    }


    #region Helper Functions

    private void handlePreviousSceneTotals()
    {
        totalChangableTiles += numCurrentLevelTiles;
        totalAlive += numCurrentAlive;
        totalDead += numCurrentDead;
    }

    private void clearCurrentVars()
    {
        tileChanges.Clear();
        numCurrentLevelTiles = 0;
        numCurrentAlive = 0;
        numCurrentDead = 0;
    }

    private void setCurrentVars()
    {
        GameObject[] changableTiles = GameObject.FindGameObjectsWithTag("Changable Tiles");
        foreach (GameObject changable in changableTiles)
        {
            TileChange tiles = changable.GetComponent<TileChange>();
            if (tiles)
            {
                tileChanges.Add(tiles);
                numCurrentLevelTiles += tiles.getSizeTilePositions();
            }
        }
    }

    private void updateAliveAndDead()
    {
        foreach (TileChange tileChange in tileChanges)
        {
            numCurrentAlive = tileChange.getNumAlive();
            numCurrentDead = tileChange.getNumDead();
        }
    }
    #endregion
}
