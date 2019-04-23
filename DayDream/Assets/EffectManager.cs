using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class EffectManager : MonoBehaviour
{
    public PostProcessVolume glaucomaLayer;
    public PostProcessVolume cataractsLayer;
    public PostProcessVolume starburstsLayer;

    public PostProcessingBlur blur;
    public Material postprocessMaterial;

    // Start is called before the first frame update
    void Start()
    {
        glaucomaLayer.weight = 0;
        cataractsLayer.weight = 0;
        starburstsLayer.weight = 0;
        postprocessMaterial.SetFloat("_BlurSize", 0);
        blur.enabled = false;

        print(postprocessMaterial.GetFloat("_BlurSize"));
        //postprocessMaterial.SetFloat("_BlurSize", )
    }


    public void ConditionSelector(string item)
    {
        if (item.Equals("Cataracts"))
        {
            //VisualConditionSim(cataractsLayer);
            CataractsController(postprocessMaterial);


        }
        else if (item.Equals("Diabetic Retinopathy"))
        {
            DiabeticRetinopy();
        }
        else if (item.Equals("Glaucoma"))
        {
            VisualConditionSim(glaucomaLayer);
        }
        else if (item.Equals("Macular Degeneration"))
        {
            MascularDegeneration();
        }
        else if (item.Equals("Starbursts"))
        {
            VisualConditionSim(starburstsLayer);
        }
        else if (item.Equals("Reset"))
        {
            glaucomaLayer.weight = 0;
            cataractsLayer.weight = 0;
            starburstsLayer.weight = 0;
            blur.enabled = false;
        }
        else
        {
            print("Nothing");
        }
    }

    void VisualConditionSim(PostProcessVolume visualCondition)
    {
        if (visualCondition.weight < 0.8)
        {
            visualCondition.weight += (float)0.2;
        }
        else
        {
            visualCondition.weight = 0;
        }
    }

    void CataractsController(Material cataractsMaterial)
    {
        if (blur.enabled == false)
        {
            blur.enabled = true;            
        }

        if (postprocessMaterial.GetFloat("_BlurSize") < 0.02)
        {
            float temp = postprocessMaterial.GetFloat("_BlurSize");
            postprocessMaterial.SetFloat("_BlurSize", (temp += (float)0.005));
        }
        else
        {
            blur.enabled = false;
            postprocessMaterial.SetFloat("_BlurSize", 0);
        }
    }

    void ColourBlindnessSim()
    {

    }

    void DiabeticRetinopy()
    {
        print("DiabeticRetinopy");
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
