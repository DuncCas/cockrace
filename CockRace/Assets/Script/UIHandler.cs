using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    Canvas currentActiveCanvas;
    public Canvas canvasMenu;
    public Canvas canvasLeaderboard;
    public Canvas canvasGameOver;


    public void CloseGame()
    {
        Debug.Log("Close");
        Application.Quit();
    }

    public void Start()
    {
        currentActiveCanvas = canvasMenu;
    }

    public void hideCurrentCanvas()
    {
        currentActiveCanvas.gameObject.SetActive(false);
    }


    public void OpenCanvas(Canvas canvas)
    {
        Debug.Log("Changing Menu with" + canvas);
        currentActiveCanvas.enabled = false;
        currentActiveCanvas = canvas;
        currentActiveCanvas.enabled= true;
    }

    public void OpenGameOverCanvas()
    {
        currentActiveCanvas = canvasGameOver;
        currentActiveCanvas.gameObject.SetActive(true);
    }

}
