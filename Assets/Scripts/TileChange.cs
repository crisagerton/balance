using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileChange : MonoBehaviour {
    /// <summary>
    /// Determines how tiles will change based on the player's powers (the glow)
    /// Tiles affected by the healer will become alive.
    /// Tiles affected by the destroyer will become dead.
    /// Only affects tiles wtihin this tile map.
    /// </summary>

    public GameObject healerGlow;
    public GameObject destroyerGlow;

    public Tile alive;
    public Tile dead;

    public Tilemap tileMap;

    private List<Vector3> tilePositionsInWorld;

    private void Start()
    {
        tileMap = GetComponent<Tilemap>();
        tilePositionsInWorld = new List<Vector3>();

        fillPositionsList();
    }

    private void Update()
    {
        changeTiles(alive, healerGlow);
        changeTiles(dead, destroyerGlow);
    }


    private void changeTiles(Tile newTile, GameObject glow)
    {
        Bounds glowBounds = glow.GetComponent<CircleCollider2D>().bounds;

        foreach (Vector3 position in tilePositionsInWorld)
        {
            if (!glowBounds.Contains(position))
                continue;
            Vector3Int mapPosition = tileMap.WorldToCell(position);
            tileMap.SetTile(mapPosition, newTile);
        }
    }

    private void fillPositionsList()
    {
        #region Comment
        /*
         * Reference Source: 
         * https://forum.unity.com/threads/tilemap-tile-positions-assistance.485867/
        */
        #endregion

        for (int r = tileMap.cellBounds.xMin; r < tileMap.cellBounds.xMax; r++)
        {
            for (int c = tileMap.cellBounds.yMin; c < tileMap.cellBounds.yMax; c++)
            {
                Vector3Int localPlace = (new Vector3Int(r, c, (int)tileMap.transform.position.y));
                Vector3 position = tileMap.CellToWorld(localPlace);
                if (tileMap.HasTile(localPlace))
                {
                    tilePositionsInWorld.Add(position);
                }
            }
        }
    }
}
