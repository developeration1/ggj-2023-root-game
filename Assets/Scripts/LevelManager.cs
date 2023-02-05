using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    LevelGenerator levelGenerator;

    private void Awake()
    {
        levelGenerator = FindObjectOfType<LevelGenerator>();
    }

    public LevelLayer GetLayerByName(string name)
    {
        return levelGenerator.GetLayerByName(name);
    }
}
