using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering.PostProcessing;
using DaydreamElements.ConstellationMenu;

public class EventListener : MonoBehaviour
{
    // Start is called before the first frame update
    private Renderer renderer;
    private Rigidbody rb;

    private PostProcessVolume m_Volume;
    private Vignette m_Vignette;


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

    public void OnMenuDecision(ConstellationMenuItem menuItem)
    {
        print(menuItem);
        if (menuItem.ToString().Equals("Glaucoma (DaydreamElements.ConstellationMenu.ConstellationMenuItem)"))
        {
            Vignette(menuItem);
        }
    }

    public void Vignette(ConstellationMenuItem menuItem)
    {
        print(menuItem);

        m_Vignette = ScriptableObject.CreateInstance<Vignette>();
        m_Vignette.enabled.Override(true);
        m_Vignette.intensity.Override(1f);

        m_Volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, m_Vignette);
        m_Volume.weight = 1f;
    }
}
