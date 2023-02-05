using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Grid))]
public class LevelGenerator : MonoBehaviour
{
    [SerializeField] LevelLayer[] levelLayers;

    IEnumerator Start()
    {
        foreach(LevelLayer layer in levelLayers)
        {
            layer.Init(transform);
            yield return new WaitForEndOfFrame();
        }
    }
}
