using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        rb.useGravity = false;
        Transform pointerTransform = GvrPointerInputModule.Pointer.PointerTransform;

        transform.SetParent(pointerTransform, true);
    }

    public void OnRelease()
    {
        rb.useGravity = true;
        transform.SetParent(null, true);
    }
}
