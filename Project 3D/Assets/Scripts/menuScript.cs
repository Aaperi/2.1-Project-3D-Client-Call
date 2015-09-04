using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class menuScript : MonoBehaviour
{

    public Canvas menu;
    public Canvas exitMenu;
    public Canvas pauseMenu;

    public Button playButton;
    public Button continueButton;
    public Button exitButton;
    public Button quitButton;

    public bool canvasOn;
    public bool paused;

    CameraSpline cam;
    SmallBroMovement sBro;
    BigBroMovement bBro;
    CheckIfGrounded checker;

    // Use this for initialization
    void Start()
    {
        menu = menu.GetComponent<Canvas>();
        exitMenu = exitMenu.GetComponent<Canvas>();
        pauseMenu = pauseMenu.GetComponent<Canvas>();

        playButton = playButton.GetComponent<Button>();
        continueButton = continueButton.GetComponent<Button>();
        exitButton = exitButton.GetComponent<Button>();
        quitButton = quitButton.GetComponent<Button>();

        exitMenu.enabled = false;
        pauseMenu.enabled = false;

        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraSpline>();

        bBro = GameObject.FindGameObjectWithTag("Big").GetComponent<BigBroMovement>();
        sBro = GameObject.FindGameObjectWithTag("Small").GetComponent<SmallBroMovement>();
        checker = sBro.GetComponent<CheckIfGrounded>();

    }

    void Update()
    {
        if (menu.enabled)
        {
            canvasOn = true;
            cam.enabled = false;
        }


        else
        {
            canvasOn = false;
            cam.enabled = true;
        }


        if (canvasOn || paused)
        {
            bBro.enabled = false;
            sBro.enabled = false;
            
        }

        else
        {
            bBro.enabled = true;
            sBro.enabled = true;
        }


        if (Input.GetKeyDown(KeyCode.Escape))
            paused = true;


        if (paused)
            pauseMenu.enabled = true;
        else
            pauseMenu.enabled = false;

    }

    public void playClick()
    {
        menu.enabled = false;
        cam.MoveToNext();


    }

    public void exitClick()
    {
        exitMenu.enabled = true;
        playButton.enabled = false;
        exitButton.enabled = false;
        quitButton.enabled = false;
        continueButton.enabled = false;

    }

    public void yesClick()
    {
        Application.Quit();

    }

    public void noClick()
    {
        exitMenu.enabled = false;
        playButton.enabled = true;
        exitButton.enabled = true;
        quitButton.enabled = false;
        continueButton.enabled = false;
    }

    public void pauseQuit()
    {
        exitMenu.enabled = true;
        playButton.enabled = false;
        exitButton.enabled = false;
        quitButton.enabled = true;
        continueButton.enabled = true;
    }

    public void contYes()
    {
        paused = false;
        pauseMenu.enabled = false;
        bBro.enabled = true;
        sBro.enabled = true;
        cam.enabled = true;
    }

    public void quitClick()
    {
        exitMenu.enabled = true;
    }

}
