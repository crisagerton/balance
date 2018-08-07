using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SelectiveEntry : MonoBehaviour {
    /// <summary>
    /// Determines if objects will collide or pass through.
    /// </summary>

    public List<GameObject> objectsAllowedPassage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (objectsAllowedPassage.Contains(collision.gameObject))
        {
            Physics2D.IgnoreCollision(collision.collider, collision.otherCollider);
        }
    }
}
