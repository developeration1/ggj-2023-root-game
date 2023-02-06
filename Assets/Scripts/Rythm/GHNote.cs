using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GHNote : MonoBehaviour
{
    public int BPM;
    private float speed;
    public float factor = 1;

    // Start is called before the first frame update
    void Start()
    {
        speed = BPM * factor;
        GameManager.Instance.gameStateManager.GameStateChanged += HandleSongState;
    }

    private void OnDisable()
    {
        GameManager.Instance.gameStateManager.GameStateChanged -= HandleSongState;
    }

    public void HandleSongState(GameStateManager.GameState gameState)
    {
        if (gameState == GameStateManager.GameState.Started)
        {
            
        }
        if (gameState == GameStateManager.GameState.Paused)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.gameStateManager.currentState == GameStateManager.GameState.Started)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("StartNote"))
        {
            GameManager.Instance.songManager.SpawnNote();
        } else if (collision.CompareTag("MissedNote"))
        {
            Destroy(gameObject);
        }
    }


    /*
        else if (collision.gameObject.tag == "PerfectNote")
        {

        }
        else if (collision.gameObject.tag == "GoodNote")
        {

        }
        else if (collision.gameObject.tag == "NiceNote")
        {

        }
        else if (collision.gameObject.tag == "MissedNote")
        {

        }
     */
}
