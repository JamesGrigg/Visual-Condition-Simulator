using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class EffectManager : MonoBehaviour
{
    public GameObject effects;

    private PostProcessVolume m_Volume;
    private Vignette m_Vignette;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void ConditionSelector(string item)
    {
        if (item.Equals("Cataracts"))
        {
            Cataracts();
        }
        else if (item.Equals("Diabetic Retinopy"))
        {
            DiabeticRetinopy();
        }
        else if (item.Equals("Glaucoma"))
        {
            Glaucoma();
        }
        else if (item.Equals("Mascular Degeneration"))
        {
            MascularDegeneration();
        }
        else
        {
            print("Nothing");
        }
    }

    void Cataracts()
    {
        print("Cataracts");
    }

    void DiabeticRetinopy()
    {
        print("DiabeticRetinopy");
    }

    void Glaucoma()
    {
        print("Glaucoma");
    }

    void MascularDegeneration()
    {
        print("MascularDegeneration");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
