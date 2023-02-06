using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongManager : MonoBehaviour
{
    public GameObject notePrefab;
    public Transform parent;
    AudioSource audioSource;

    public List<Note> notes = new();

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        GameManager.Instance.gameStateManager.GameStateChanged += HandleSongState;
        StartCoroutine(ExampleCoroutine());
    }

    private void OnDisable()
    {
        GameManager.Instance.gameStateManager.GameStateChanged -= HandleSongState;
    }

    public void HandleSongState(GameStateManager.GameState gameState)
    {
        if (gameState == GameStateManager.GameState.Started)
        {
            audioSource.Play();
        }
        if (gameState == GameStateManager.GameState.Paused)
        {
            audioSource.Stop();
        }
    }

    public void SpawnNote()
    {
        GameObject gmObject = Instantiate(notePrefab, parent);
        Note note = gmObject.GetComponent<Note>();

        notes.Add(note);
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(98);

        GameManager.Instance.gameStateManager.Win();
    }
}
