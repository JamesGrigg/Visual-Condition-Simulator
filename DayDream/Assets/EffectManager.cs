using jp.gulti.ColorBlind;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using static jp.gulti.ColorBlind.ColorBlindnessSimulator;

public class EffectManager : MonoBehaviour
{
    public PostProcessVolume glaucomaLayer;
    public PostProcessVolume cataractsLayer;
    public PostProcessVolume starburstsLayer;

    public PostProcessingBlur blur;
    public Material postprocessBlur;
    public Material postprocessDoubleVision;

    public ColorBlindnessSimulator colourblindSim;

    // Start is called before the first frame update
    void Start()
    {
        glaucomaLayer.weight = 0;
        cataractsLayer.weight = 0;
        starburstsLayer.weight = 0;
        postprocessBlur.SetFloat("_BlurSize", 0);
        postprocessDoubleVision.SetFloat("_Size", 0);
        blur.enabled = false;

        colourblindSim.enabled = false;
    }


    public void ConditionSelector(string item)
    {
        if (item.Equals("Cataracts"))
        {
            //VisualConditionSim(cataractsLayer);
            CataractsController(postprocessBlur);
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
        else if (item.Equals("Protonopia"))
        {
            if (colourblindSim.BlindIntensity > 0.0f && colourblindSim.BlindMode == ColorBlindMode.Deuteranope)
            {
                colourblindSim.BlindIntensity = 0.0f;
            }
            
            colourblindSim.BlindMode = ColorBlindMode.Protanope;
            ColourBlindnessSim();
            colourblindSim.enabled = true;
        }
        else if (item.Equals("Deuteranopia"))
        {
            if (colourblindSim.BlindIntensity > 0.0f && colourblindSim.BlindMode == ColorBlindMode.Protanope)
            {
                colourblindSim.BlindIntensity = 0.0f;
            }

            colourblindSim.BlindMode = ColorBlindMode.Deuteranope;
            ColourBlindnessSim();
            colourblindSim.enabled = true;            
        }
        else if (item.Equals("Double Vision"))
        {
            DoubleVisionController(postprocessDoubleVision);
        }
        else if (item.Equals("Reset"))
        {
            glaucomaLayer.weight = 0;
            cataractsLayer.weight = 0;
            starburstsLayer.weight = 0;
            blur.enabled = false;
            colourblindSim.BlindIntensity = 0.0f;
            colourblindSim.enabled = false;
        }
        else
        {
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

        if (postprocessBlur.GetFloat("_BlurSize") < 0.02)
        {
            float temp = postprocessBlur.GetFloat("_BlurSize");
            postprocessBlur.SetFloat("_BlurSize", (temp += (float)0.005));
        }
        else
        {
            blur.enabled = false;
            postprocessBlur.SetFloat("_BlurSize", 0);
        }
    }

    void DoubleVisionController(Material cataractsMaterial)
    {
        if (postprocessDoubleVision.GetFloat("_Size") < 5)
        {
            float temp = postprocessDoubleVision.GetFloat("_Size");
            postprocessDoubleVision.SetFloat("_Size", (temp += (float)1));
        }
        else
        {
            blur.enabled = false;
            postprocessDoubleVision.SetFloat("_Size", 0);
        }
    }

    void ColourBlindnessSim()
    {
        if (colourblindSim.BlindIntensity < 1.0f)
        {
            colourblindSim.BlindIntensity += (float)0.2;
        }
        else
        {
            colourblindSim.BlindIntensity = 0;
        }
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
