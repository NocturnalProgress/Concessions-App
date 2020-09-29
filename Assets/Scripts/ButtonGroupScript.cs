using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonGroupScript : MonoBehaviour
{
    public Canvas tutorialCanvas;
    public Canvas setupCanvas;
    public Canvas menuCanvas;
    public Canvas orderCanvas;
    public Canvas settingsCanvas;
    public Canvas statsCanvas;

    private Button button;

    void Start()
    {
        tutorialCanvas.rootCanvas.enabled = false;
        setupCanvas.rootCanvas.enabled = true;
        menuCanvas.rootCanvas.enabled = false;
        orderCanvas.rootCanvas.enabled = false;
        statsCanvas.rootCanvas.enabled = false;
        settingsCanvas.rootCanvas.enabled = false;
    }

    public void TutorialButton()
    {
        tutorialCanvas.rootCanvas.enabled = true;
        setupCanvas.rootCanvas.enabled = false;
        menuCanvas.rootCanvas.enabled = false;
        orderCanvas.rootCanvas.enabled = false;
        statsCanvas.rootCanvas.enabled = false;
        settingsCanvas.rootCanvas.enabled = false;
    }

    public void SetupButton()
    {
        tutorialCanvas.rootCanvas.enabled = false;
        setupCanvas.rootCanvas.enabled = true;
        menuCanvas.rootCanvas.enabled = false;
        orderCanvas.rootCanvas.enabled = false;
        statsCanvas.rootCanvas.enabled = false;
        settingsCanvas.rootCanvas.enabled = false;
    }

    public void MenuButton()
    {
        tutorialCanvas.rootCanvas.enabled = false;
        setupCanvas.rootCanvas.enabled = false;
        menuCanvas.rootCanvas.enabled = true;
        orderCanvas.rootCanvas.enabled = false;
        statsCanvas.rootCanvas.enabled = false;
        settingsCanvas.rootCanvas.enabled = false;
    }

    public void OrderButton()
    {
        tutorialCanvas.rootCanvas.enabled = false;
        setupCanvas.rootCanvas.enabled = false;
        menuCanvas.rootCanvas.enabled = false;
        orderCanvas.rootCanvas.enabled = true;
        statsCanvas.rootCanvas.enabled = false;
        settingsCanvas.rootCanvas.enabled = false;
    }

    public void StatsButton()
    {
        tutorialCanvas.rootCanvas.enabled = false;
        setupCanvas.rootCanvas.enabled = false;
        menuCanvas.rootCanvas.enabled = false;
        orderCanvas.rootCanvas.enabled = false;
        statsCanvas.rootCanvas.enabled = true;
        settingsCanvas.rootCanvas.enabled = false;
    }
    public void SettingsButton()
    {
        tutorialCanvas.rootCanvas.enabled = false;
        setupCanvas.rootCanvas.enabled = false;
        menuCanvas.rootCanvas.enabled = false;
        orderCanvas.rootCanvas.enabled = false;
        statsCanvas.rootCanvas.enabled = false;
        settingsCanvas.rootCanvas.enabled = true;
    }
}