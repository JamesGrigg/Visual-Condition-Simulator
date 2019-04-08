using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class EffectManager : MonoBehaviour
{
    public GameObject effects;
    public PostProcessVolume glaucomaLayer;
    public PostProcessVolume cataractsLayer;

    // Start is called before the first frame update
    void Start()
    {
        glaucomaLayer.weight = 0;
        cataractsLayer.weight = 0;
    }


    public void ConditionSelector(string item)
    {
        if (item.Equals("Cataracts"))
        {
            Cataracts();
        }
        else if (item.Equals("Diabetic Retinopathy"))
        {
            DiabeticRetinopy();
        }
        else if (item.Equals("Glaucoma"))
        {
            Glaucoma();
        }
        else if (item.Equals("Macular Degeneration"))
        {
            MascularDegeneration();
        }
        else if (item.Equals("Reset"))
        {
            glaucomaLayer.weight = 0;
            cataractsLayer.weight = 0;
        }
        else
        {
            print("Nothing");
        }
    }

    void Cataracts()
    {
        print("Cataracts");
        if (cataractsLayer.weight < 0.8)
        {
            cataractsLayer.weight += (float)0.2;
        }
        else
        {
            cataractsLayer.weight = 0;
        }
    }

    void DiabeticRetinopy()
    {
        print("DiabeticRetinopy");
    }

    void Glaucoma()
    {
        print("Glaucoma");
        if (glaucomaLayer.weight < 0.8)
        {        
            glaucomaLayer.weight += (float)0.2;
        }
        else
        {
            glaucomaLayer.weight = 0;
        }
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
