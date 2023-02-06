using System.Collections;
using System.Collections.Generic;
using Doozy.Runtime.UIManager.Components;
using UnityEngine;

/**
 * Has the current life status and methods to update it.
 */
public class LifeManager : MonoBehaviour
{

    public UISlider slider;

    public float currentLife;

    /*****************
     *** Constants ***
     *****************/

    const float ObstacleHitMultiplier = 1.2f;
    
    const float MaxLife = 100;
    const float MinLife = 0;

    const float BaseLifeAddition = 2;
    const float BaseLifeSubtraction = 10;
    const float ObstacleSubtraction = BaseLifeSubtraction * ObstacleHitMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        currentLife = MaxLife;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = currentLife / 100;
    }

    /**
     * Called when the player takes a drop of water.
     * Adds life.
     */
    public void AddLife()
    {
        float addedLife = currentLife + BaseLifeAddition;
        if (addedLife < MaxLife)
        {
            currentLife += addedLife;
        }
    }

    /**
     * Helper method to remove life.
     */
    public void SubtractLife(float amount)
    {
        if (amount >= MinLife)
        {
            currentLife -= amount;
        }
        else
        {
            // Lose
        }
    }

    /**
     * Called when the player misses a rythm note.
     */
    public void MissedRythm()
    {
        SubtractLife(currentLife - BaseLifeSubtraction);
    }

    /**
     * Called when the player hits an obstacle.
     */
    public void HitObstacle()
    {
        SubtractLife(currentLife - ObstacleSubtraction);
    }
}
