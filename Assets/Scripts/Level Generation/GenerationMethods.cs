using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Tilemaps;

public class GenerationMethods : MonoBehaviour
{
    [Header("Background")]
    [SerializeField] Vector2Int backgroundSize;

    [Header("Route")]
    [SerializeField] Vector3Int routeStartingPoint;
    [SerializeField] int routeLength;

    public void RockGeneration(Tile[] tiles, Tilemap tilemap)
    {
        
    }

    public void RouteGeneration(Tile[] tiles, Tilemap tilemap)
    {
        Vector3Int next = routeStartingPoint;
        for(int i = 0; i < routeLength; i++)
        {
            tilemap.SetTile(next, tiles[Random.Range(0, tiles.Length)]);
            Vector3Int prev = next;
            while(tilemap.HasTile(next))
            {
                next = prev;
                int direction = Random.Range(0, 3);
                next = direction switch
                {
                    0 => new Vector3Int(next.x - 1, next.y, next.z),
                    1 => new Vector3Int(next.x, next.y - 1, next.z),
                    2 => new Vector3Int(next.x + 1, next.y, next.z),
                    _ => throw new System.NotImplementedException(),
                };
            }
        }
    }

    public void BackgroundGeneration(Tile[] tiles, Tilemap tilemap)
    {
        Vector2Int backgroundEndPoint = new Vector2Int(Mathf.FloorToInt(backgroundSize.x / 2), 0);
        Vector2Int backgroundStartPoint = new Vector2Int(-backgroundEndPoint.x, -backgroundSize.y);
        for (int x = backgroundStartPoint.x; x < backgroundEndPoint.x; x++)
        {
            for (int y = backgroundStartPoint.y; y < backgroundEndPoint.y; y++)
            {
                tilemap.SetTile(new Vector3Int(x, y, 1), tiles[Random.Range(0, tiles.Length)]);
            }
        }
    }
}
