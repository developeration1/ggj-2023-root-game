using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class RootController : MonoBehaviour
{
    //public CharacterController controller;
    public LineRenderer lineRenderer;
    public float movementQuantity = 10;
    private int lineRendererPositions = 1;
    private Vector3 movementOutput;

    LevelLayer routeLayer;

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
        if (context.started)
        {
            Vector2 movementInput = context.ReadValue<Vector2>();
            Debug.Log(movementInput);
            if (movementOutput == null || movementOutput.x == 0 || (movementOutput.x * -1) != movementInput.x)
            {
                movementOutput = new Vector3(movementInput.x, movementInput.y, 0) * movementQuantity;
            }
            MoveRoot();
        }
    }

    public void BeatPress(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            //if(not on time){
            //controller.Move hacia abajo
            //quita vida
            //}else
            //{

            //}
        }
    }

    public void MoveRoot()
    {
        //transform.Translate(movementOutput);
        lineRendererPositions++;
        lineRenderer.positionCount = lineRendererPositions;
        transform.DOMove(transform.position + movementOutput, .2f).SetEase(Ease.InCirc);
        // transform.DOMove(movementOutput + transform.position, 1, true).SetEase(Ease.InCubic);
       // controller.Move(movementOutput);
        //lineRenderer.SetPosition(lineRendererPositions - 1, controller.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Hubo colision con " + other.tag);
        string tag = other.tag;
        switch (tag.ToLower())
        {
            case "agua":
                Debug.Log("Es agua");
            break;
            case "piedra":
                Debug.Log("Es piedra");
            break;

        }
            
    }
}
