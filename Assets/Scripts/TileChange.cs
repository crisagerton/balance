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
        foreach (Vector3 position in tilePositionsInWorld)
        {
            if (!positionInGlowBounds(position, glow))
                continue;
            Vector3Int mapPosition = tileMap.WorldToCell(position);
            tileMap.SetTile(mapPosition, newTile);
        }
    }

    private bool positionInGlowBounds(Vector3 position, GameObject glow)
    {
        Bounds glowBounds = glow.GetComponent<CircleCollider2D>().bounds;
        return glowBounds.max.x >= position.x && glowBounds.max.y >= position.y
            && glowBounds.min.x <= position.x && glowBounds.min.y <= position.y;

    }

    private void fillPositionsList()
    {
        #region Comment
        /*
         * Reference Source: 
         * https://forum.unity.com/threads/tilemap-tile-positions-assistance.485867/
        */
        #endregion

        for (int c = tileMap.cellBounds.xMin; c < tileMap.cellBounds.xMax; c++)
        {
            for (int r = tileMap.cellBounds.yMin; r < tileMap.cellBounds.yMax; r++)
            {
                Vector3Int localPlace = (new Vector3Int(c, r, (int)tileMap.transform.position.z));
                Vector3 position = tileMap.CellToWorld(localPlace);
                if (tileMap.HasTile(localPlace))
                {
                    tilePositionsInWorld.Add(position);
                }
            }
        }
    }
}
