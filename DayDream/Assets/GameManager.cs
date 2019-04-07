﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DaydreamElements.Common.IconMenu;
using DaydreamElements.ConstellationMenu;

public class GameManager : MonoBehaviour
{
    public GameObject completeLevelUI;
    public GameObject failedLevelUI;
    public GameObject removeUI;
    public GameObject timerSlider;
    public SliderScripts sliderTime;

    public ConstellationMenuRoot menuRoot;

    public EffectManager effectManager;

    public bool gameOver;

    bool win = false;

    void Start()
    {
        gameOver = false;
        timerSlider.SetActive(true);
        StartCoroutine(SpawnCoroutine());
        menuRoot.OnItemSelected.AddListener(OnItemSelected);
        effectManager = new EffectManager();
    }

    public void CompleteLevel()
    {
        win = true;
        gameOver = true;
        completeLevelUI.SetActive(true);
        RemoveUI();
        //StopCoroutine(SpawnCoroutine());
    }

    void EndGame()
    {
        gameOver = true;
        failedLevelUI.SetActive(true);
        RemoveUI();
    }

    void RemoveUI()
    {
        removeUI.SetActive(false);
        timerSlider.SetActive(false);
    }

    private void OnItemSelected(ConstellationMenuItem item)
    {
        if (item.prefab == null)
        {
            effectManager.ConditionSelector(item.toolTip);
            return;
        }
    }

    IEnumerator SpawnCoroutine()
    {
        yield return new WaitForSeconds(sliderTime.time); //wait 5 seconds
        timerSlider.SetActive(false);
        if (!win)
        {
            EndGame();
        }
    }
}
