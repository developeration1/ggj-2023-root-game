using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class rootController : MonoBehaviour
{
    //public CharacterController controller;
    public LineRenderer lineRenderer;
    public float movementQuantity = 1;
    private int lineRendererPositions = 1;
    private Vector3 movementOutput;
    private bool moved = false;
    public float waitTime = 3;
    public Vector3 initialPosition = new Vector3(0.5f,-1.5f,0);

    LevelLayer routeLayer;
    LevelLayer rockLayer;

    bool canMove = false;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        transform.position = initialPosition;
        routeLayer = GameManager.Instance.levelManager.GetLayerByName("Route");
        rockLayer = GameManager.Instance.levelManager.GetLayerByName("Rock");
        canMove = true;
        lineRenderer.SetPosition(0, transform.position);
        movementOutput = new Vector3(0, -1, 0) * movementQuantity;
        MoveRoot();
        
        yield return new WaitForSeconds(waitTime);
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(lineRendererPositions - 1, transform.position);
        collisionDetection();
    }

    public void collisionDetection()
    {
        if (moved)
        {
            Vector3Int tileLocation = new Vector3Int(Mathf.FloorToInt(transform.position.x), Mathf.FloorToInt(transform.position.y), 0);
            bool hasWater = routeLayer.LayerMap.HasTile(tileLocation);
            bool hasRock = rockLayer.LayerMap.HasTile(tileLocation);
            switch(hasWater.ToString().ToLower() + "-" + hasRock.ToString().ToLower())
            {
                case "true-false": //Aqui se maneja la colision del agua
                    Debug.Log("Esto es agua");
                    routeLayer.LayerMap.SetTile(tileLocation, null);
                    GameManager.Instance.lifeManager.AddLife();
                break;

                case "false-true": //Aqui se maneja la colision de las piedras
                    Debug.Log("Esto es una piedra");
                    rockLayer.LayerMap.SetTile(tileLocation, null);
                    GameManager.Instance.lifeManager.HitObstacle();
                    break;

                default: //Aqui es en la tierra
                    Debug.Log("Actualmente estas en tierra");
                    GameManager.Instance.lifeManager.MissedRythm();
                break;
            }
            moved = false;
        }
    }

    public void RootDirection(InputAction.CallbackContext context)
    {
        if (context.started && canMove)
        {
            Vector2 movementInput = context.ReadValue<Vector2>();
            if (movementOutput == null || movementOutput.x == 0 || (movementOutput.x * -1) != movementInput.x)
            {
                movementOutput = new Vector3(movementInput.x, movementInput.y, 0) * movementQuantity;
            }
            MoveRoot();
        }
    }

    public void MoveRoot()
    {
        if (canMove)
        {
            lineRendererPositions++;
            lineRenderer.positionCount = lineRendererPositions;
            canMove = false;
            transform.DOMove(transform.position + movementOutput, .2f).SetEase(Ease.InCirc).OnComplete(() =>
            {
                canMove = true;
                moved = true;
            });
        }
    }
}
