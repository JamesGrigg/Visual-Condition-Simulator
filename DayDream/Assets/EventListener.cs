using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventListener : MonoBehaviour
{
    // Start is called before the first frame update
    private Renderer renderer;
    private Rigidbody rb;
    private Color objectColour;

    public GameManager gameManager;


    void Start()
    {
        renderer = gameObject.GetComponent<Renderer>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public void OnEnter()
    {
        objectColour = renderer.material.color;
        if (gameManager.gameStarted == true)
        {
            renderer.material.color = Color.yellow;
        }        
    }

    public void OnExit()
    {
        if (gameManager.gameStarted == true)
        {
            renderer.material.color = objectColour;
        }           
    }

    public void OnGrab()
    {
        if (gameManager.gameStarted == true)
        {
            rb.isKinematic = true;
            Transform pointerTransform = GvrPointerInputModule.Pointer.PointerTransform;

            transform.SetParent(pointerTransform, true);
        }       
    }

    public void OnRelease()
    {
        if (gameManager.gameStarted == true)
        {
            rb.isKinematic = false;
            transform.SetParent(null, true);
        }            
    }
}
