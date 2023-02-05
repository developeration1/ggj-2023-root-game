using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class RootController : MonoBehaviour
{
    public CharacterController controller;
    public LineRenderer lineRenderer;
    public float movementQuantity = 10;
    private int lineRendererPositions = 1;
    private Vector3 movementOutput;

    public event Action PlayerMoved = delegate { };

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer.SetPosition(lineRendererPositions - 1, controller.transform.position);
        movementOutput = new Vector3(0, -1, 0) * movementQuantity;
        MoveRoot();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void RootDirection(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Vector2 movementInput = context.ReadValue<Vector2>();
            if(HasInputValidValue(movementInput))
            {
                movementOutput = new Vector3(movementInput.x, movementInput.y, 0) * movementQuantity;
                // Call method.
                PlayerMoved.Invoke();
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
        lineRendererPositions++;
        lineRenderer.positionCount = lineRendererPositions;
        controller.Move(movementOutput);
        lineRenderer.SetPosition(lineRendererPositions - 1, controller.transform.position);
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
