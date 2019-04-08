using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class EffectManager : MonoBehaviour
{
    public GameObject effects;
    public PostProcessVolume ppLayer;
    public double ppWeight;

    // Start is called before the first frame update
    void Start()
    {
        ppLayer.weight = 0;
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
        if (ppWeight < 0.8)
        {
            ppWeight += 0.2;
            float b = Convert.ToSingle(ppWeight);
            ppLayer.weight = b;
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
