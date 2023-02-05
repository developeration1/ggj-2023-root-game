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
        if (movingIndicator.animation.isPaused)
        {
            Debug.Log("HELLOOO");
        }
    }

    private void OnDisable()
    {
        GameManager.Instance.rootManager.PlayerMoved -= OnPlayerMoved;
    }

    public void OnPlayerMoved()
    {
        movingIndicator.animation.Scale.Stop();
        movingIndicator.animation.Scale.enabled = false;
        movingIndicator.animation.Fade.enabled = true;
        movingIndicator.animation.Fade.Play();
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
