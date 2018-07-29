using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileChange : MonoBehaviour {

    public Tile alive;
    public Tile dead;

    public Tilemap tileMap;

    private void Start()
    {
        tileMap = GetComponent<Tilemap>();
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        
        Vector2 collisionPosition = collision.GetComponent<Rigidbody2D>().position;

        Vector3Int collisionPoint = new Vector3Int((int)collisionPosition.x, (int) collisionPosition.y, 0);
        TileBase collidedTile = tileMap.GetTile(collisionPoint);

        if (collision.tag == "Destroyer")
        {
            //BoundsInt boundary = collision.GetComponentInParent<PlayerPowers>().getBoundary();
            //tileMap.SetTile(collisionPoint, dead);
            //TileBase[] deadTiles = new TileBase[1];
            //deadTiles[0] = dead;
            //tileMap.SetTilesBlock(boundary, deadTiles);
        }
        
    }
}
