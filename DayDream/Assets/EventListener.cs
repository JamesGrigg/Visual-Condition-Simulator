using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventListener : MonoBehaviour
{
    // Start is called before the first frame update
    private Renderer renderer;
    private Rigidbody rb;


    void Start()
    {
        renderer = gameObject.GetComponent<Renderer>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public void OnEnter()
    {
        renderer.material.color = Color.yellow;
    }

    public void OnExit()
    {
        renderer.material.color = Color.white;
    }

    public void OnGrab()
    {
        rb.isKinematic = true;
        Transform pointerTransform = GvrPointerInputModule.Pointer.PointerTransform;

        transform.SetParent(pointerTransform, true);
    }

    public void OnRelease()
    {
        rb.isKinematic = false;
        transform.SetParent(null, true);
    }
}
