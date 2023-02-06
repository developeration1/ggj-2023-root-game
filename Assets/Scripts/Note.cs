using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Doozy.Runtime.Reactor.Animators;

public class Note : MonoBehaviour
{
    UIAnimator movingIndicator;

    // Start is called before the first frame update
    void Start()
    {
        movingIndicator = GetComponent<UIAnimator>();
        GameManager.Instance.rootManager.PlayerMoved += OnPlayerMoved;
    }

    private void Update()
    {
        if ((!movingIndicator.animation.Scale.enabled 
            && movingIndicator.animation.Fade.enabled 
            && movingIndicator.animation.Fade.isIdle)
            || (movingIndicator.animation.Scale.enabled 
            && movingIndicator.animation.Scale.isIdle))
        {
            Note note = GameManager.Instance.songManager.notes[0];
            GameManager.Instance.songManager.notes.Remove(note);
            Destroy(note.gameObject);
        }
    }

    private void OnDisable()
    {
        GameManager.Instance.rootManager.PlayerMoved -= OnPlayerMoved;
    }

    public void OnPlayerMoved()
    {
        if (GameManager.Instance.songManager.notes[0].Equals(this))
        {
            movingIndicator.animation.Scale.Stop();
            movingIndicator.animation.Scale.enabled = false;
            movingIndicator.animation.Fade.enabled = true;
            movingIndicator.animation.Fade.Play();
        }
    }
}
