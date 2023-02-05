using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "Layer", menuName = "Level Generation/Layer")]
public class LevelLayer : ScriptableObject
{
    [SerializeField] Tile[] tiles;
    [SerializeField] UnityEvent<Tile[], Tilemap>[] generators;
    [SerializeField] GameObject prefabMap;

    GameObject map;

    Tilemap layerMap = null;

    public Tilemap LayerMap => layerMap;

    public void Init(Transform parent = null)
    {
        if (!prefabMap)
            map = new GameObject();
        else
            map = Instantiate(prefabMap, parent);
        layerMap = map.GetComponent<Tilemap>();
        if (!layerMap)
            layerMap = map.AddComponent<Tilemap>();
        foreach (UnityEvent <Tile[], Tilemap> generator in generators)
        {
            generator.Invoke(tiles, layerMap);
        }
    }
}