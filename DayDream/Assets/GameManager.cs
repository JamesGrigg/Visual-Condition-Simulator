using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DaydreamElements.Common.IconMenu;
using DaydreamElements.ConstellationMenu;
using DaydreamElements.ObjectManipulation;

public class GameManager : MonoBehaviour
{
    public GameObject completeLevelUI;
    public GameObject failedLevelUI;
    public GameObject instructionUI;
    public GameObject timerSlider;
    public GameObject sliderUI;
    public SliderScripts sliderTime;

    public ConstellationMenuRoot menuRoot;
    public EffectManager effectManager;

    public bool gameOver;
    public bool sinkGame;

    public bool gameStarted; // This variable allows me to control elements in scene to stop things from being interacted with too early

    bool win = false;

    private MoveablePhysicsObject[] movableObjects;

    void Start()
    {
        gameStarted = false;
        gameOver = false;
        sinkGame = false;
        menuRoot.OnItemSelected.AddListener(OnItemSelected);
        sliderTime.enabled = false;

        movableObjects = (MoveablePhysicsObject[])GameObject.FindObjectsOfType(typeof(MoveablePhysicsObject));
        foreach (MoveablePhysicsObject movableObject in movableObjects)
        {
            movableObject.enabled = false;
        }
        //StartGame();
    }

    public void StartGame()
    {
        foreach (MoveablePhysicsObject movableObject in movableObjects)
        {
            movableObject.enabled = true;
        }

        gameStarted = true;
        sinkGame = true;
        sliderTime.enabled = true;
        timerSlider.SetActive(true);
        instructionUI.SetActive(true);
        sliderUI.SetActive(true);
        StartCoroutine(SpawnCoroutine());
    }

    public void CompleteLevel()
    {
        win = true;
        gameOver = true;
        completeLevelUI.SetActive(true);
        RemoveUI();
        StopCoroutine(SpawnCoroutine());
    }

    void EndGame()
    {
        gameOver = true;
        failedLevelUI.SetActive(true);
        RemoveUI();
    }

    void RemoveUI()
    {
        instructionUI.SetActive(false);
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
