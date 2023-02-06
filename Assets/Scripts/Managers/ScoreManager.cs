using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Has the current score status and methods to update it.
 */
public class ScoreManager : MonoBehaviour
{
    public float completionPercentage = 0;
    public int multiplier = 1;
    public float stars = 0;
    public int streak = 0;
    public int hitNotes = 0;
    public int currentMultiplier = 1;

    /*****************
     *** Constants ***
     *****************/

    const int TotalNotes = 200;
    const int MaxStars = 3;
    const int MaxStreak = 8;
    const int MaxMultiplier = 4;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /**
     * Updates the hit notes and the streak and multiplier. 
     */
    public void IncreaseHitNotes()
    {
        hitNotes++;

        if (streak < MaxStreak)
        {
            streak++;
        }
        else
        {
            if (multiplier < MaxMultiplier)
            {
                ResetStreak();
                multiplier++;
            }
        }
        UpdatePercentage();
    }

    /**
     * Resets streak on max streak reached or missed note.
     */
    public void ResetStreak()
    {
        streak = 0;
    }

    /**
     * Updates the completion percentage score and stars 
     */
    public void UpdatePercentage()
    {
        completionPercentage = hitNotes * 100 / TotalNotes ;
        stars = completionPercentage / MaxStars;

    }
}
