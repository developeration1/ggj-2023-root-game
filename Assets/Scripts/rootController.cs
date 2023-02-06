using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;
using System;

public class RootController : MonoBehaviour
{
    //public CharacterController controller;
    public LineRenderer lineRenderer;
    public float movementQuantity = 10;
    private int lineRendererPositions = 1;
    private Vector3 movementOutput;

    LevelLayer routeLayer;
    Tilemap routeTilemap;
    public event Action PlayerMoved = delegate { };

    bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        routeLayer = GameManager.Instance.levelManager.GetLayerByName("Route");
        lineRenderer.SetPosition(0, transform.position);
        movementOutput = new Vector3(0, -1, 0) * movementQuantity;
        MoveRoot();
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(lineRendererPositions - 1, transform.position);
    }



    public void RootDirection(InputAction.CallbackContext context)
    {
        if (context.started && canMove)
        {
            Vector2 movementInput = context.ReadValue<Vector2>();
            if(HasInputValidValue(movementInput))
            {
                movementOutput = new Vector3(movementInput.x, movementInput.y, 0) * movementQuantity;
                PlayerMoved.Invoke();

                // Start Game on First input.
                if(GameManager.Instance.gameStateManager.currentState == GameStateManager.GameState.NonPaused)
                {
                    GameManager.Instance.gameStateManager.StartLevel();
                }
            }
            MoveRoot();
        }
    }

    public bool HasInputValidValue(Vector2 movementInput)
    {
        if (movementOutput.x == 0 || (movementOutput.x * -1 != movementInput.x))
            return true;

        return false;
    }

    public void MoveRoot()
    {
        if(canMove)
        {
            lineRendererPositions++;
            lineRenderer.positionCount = lineRendererPositions;
            canMove = false;
            transform.DOMove(transform.position + movementOutput, .2f).SetEase(Ease.InCirc).OnComplete(() =>
            {
                canMove = true;
            });
        }
    }
}
