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

    [Header("Obstacles")]
    [SerializeField]
    [Range(0, 1)] float obstaclesThreshold = .5f;
    [SerializeField] float perlinScale;
    

    public void RockGeneration1(Tile[] tiles, Tilemap tilemap)
    {
        Vector2Int backgroundEndPoint = new (Mathf.FloorToInt(backgroundSize.x / 2), 0);
        Vector2Int backgroundStartPoint = new (-backgroundEndPoint.x, -backgroundSize.y);
        for(int x = backgroundStartPoint.x; x < backgroundEndPoint.x; x++)
        {
            for (int y = backgroundStartPoint.y; y < backgroundEndPoint.y; y++)
            {
                Vector2 perlinCoordinates = new((float)x / backgroundSize.x * perlinScale + Random.Range(0, 1000), (float)y / backgroundSize.y * perlinScale + Random.Range(0, 1000));
                float perlin = Mathf.PerlinNoise(perlinCoordinates.x, perlinCoordinates.y);
                if(perlin > obstaclesThreshold)
                {
                    tilemap.SetTile(new Vector3Int(x, y, 0), tiles[Random.Range(0, tiles.Length)]);
                }
            }
        }
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
        Vector2Int backgroundEndPoint = new (Mathf.FloorToInt(backgroundSize.x / 2), 0);
        Vector2Int backgroundStartPoint = new (-backgroundEndPoint.x, -backgroundSize.y);
        for (int x = backgroundStartPoint.x; x < backgroundEndPoint.x; x++)
        {
            for (int y = backgroundStartPoint.y; y < backgroundEndPoint.y; y++)
            {
                tilemap.SetTile(new Vector3Int(x, y, 1), tiles[Random.Range(0, tiles.Length)]);
            }
        }
    }
}
