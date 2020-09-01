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

    private CanvasGroup tutorialCanvasGroup;
    private CanvasGroup setupCanvasGroup;
    private CanvasGroup menuCanvasGroup;
    private CanvasGroup orderCanvasGroup;
    private CanvasGroup settingsCanvasGroup;

    private CanvasGroup statsCanvasGroup;

    private Button button;

    void Awake()
    {
        tutorialCanvasGroup = tutorialCanvas.GetComponent<CanvasGroup>();
        setupCanvasGroup = setupCanvas.GetComponent<CanvasGroup>();
        menuCanvasGroup = menuCanvas.GetComponent<CanvasGroup>();
        orderCanvasGroup = orderCanvas.GetComponent<CanvasGroup>();
        settingsCanvasGroup = settingsCanvas.GetComponent<CanvasGroup>();
        statsCanvasGroup = statsCanvas.GetComponent<CanvasGroup>();
    }

    void Start()
    {
        tutorialCanvasGroup.alpha = 0;
        tutorialCanvasGroup.interactable = false;
        tutorialCanvasGroup.blocksRaycasts = false;

        setupCanvasGroup.alpha = 1;
        setupCanvasGroup.interactable = true;
        setupCanvasGroup.blocksRaycasts = true;

        menuCanvasGroup.alpha = 0;
        menuCanvasGroup.interactable = false;
        menuCanvasGroup.blocksRaycasts = false;

        orderCanvasGroup.alpha = 0;
        orderCanvasGroup.interactable = false;
        orderCanvasGroup.blocksRaycasts = false;

        statsCanvasGroup.alpha = 0;
        statsCanvasGroup.interactable = false;
        statsCanvasGroup.blocksRaycasts = false;

        settingsCanvasGroup.alpha = 0;
        settingsCanvasGroup.interactable = false;
        settingsCanvasGroup.blocksRaycasts = false;
    }

    public void TutorialButton()
    {
        tutorialCanvasGroup.alpha = 1;
        tutorialCanvasGroup.interactable = true;
        tutorialCanvasGroup.blocksRaycasts = true;

        setupCanvasGroup.alpha = 0;
        setupCanvasGroup.interactable = false;
        setupCanvasGroup.blocksRaycasts = false;

        menuCanvasGroup.alpha = 0;
        menuCanvasGroup.interactable = false;
        menuCanvasGroup.blocksRaycasts = false;

        orderCanvasGroup.alpha = 0;
        orderCanvasGroup.interactable = false;
        orderCanvasGroup.blocksRaycasts = false;

        statsCanvasGroup.alpha = 0;
        statsCanvasGroup.interactable = false;
        statsCanvasGroup.blocksRaycasts = false;

        settingsCanvasGroup.alpha = 0;
        settingsCanvasGroup.interactable = false;
        settingsCanvasGroup.blocksRaycasts = false;
    }

    public void SetupButton()
    {
        tutorialCanvasGroup.alpha = 0;
        tutorialCanvasGroup.interactable = false;
        tutorialCanvasGroup.blocksRaycasts = false;

        setupCanvasGroup.alpha = 1;
        setupCanvasGroup.interactable = true;
        setupCanvasGroup.blocksRaycasts = true;

        menuCanvasGroup.alpha = 0;
        menuCanvasGroup.interactable = false;
        menuCanvasGroup.blocksRaycasts = false;

        orderCanvasGroup.alpha = 0;
        orderCanvasGroup.interactable = false;
        orderCanvasGroup.blocksRaycasts = false;

        statsCanvasGroup.alpha = 0;
        statsCanvasGroup.interactable = false;
        statsCanvasGroup.blocksRaycasts = false;

        settingsCanvasGroup.alpha = 0;
        settingsCanvasGroup.interactable = false;
        settingsCanvasGroup.blocksRaycasts = false;
    }

    public void MenuButton()
    {
        tutorialCanvasGroup.alpha = 0;
        tutorialCanvasGroup.interactable = false;
        tutorialCanvasGroup.blocksRaycasts = false;

        setupCanvasGroup.alpha = 0;
        setupCanvasGroup.interactable = false;
        setupCanvasGroup.blocksRaycasts = false;

        menuCanvasGroup.alpha = 1;
        menuCanvasGroup.interactable = true;
        menuCanvasGroup.blocksRaycasts = true;

        orderCanvasGroup.alpha = 0;
        orderCanvasGroup.interactable = false;
        orderCanvasGroup.blocksRaycasts = false;

        statsCanvasGroup.alpha = 0;
        statsCanvasGroup.interactable = false;
        statsCanvasGroup.blocksRaycasts = false;

        settingsCanvasGroup.alpha = 0;
        settingsCanvasGroup.interactable = false;
        settingsCanvasGroup.blocksRaycasts = false;
    }

    public void OrderButton()
    {
        tutorialCanvasGroup.alpha = 0;
        tutorialCanvasGroup.interactable = false;
        tutorialCanvasGroup.blocksRaycasts = false;

        setupCanvasGroup.alpha = 0;
        setupCanvasGroup.interactable = false;
        setupCanvasGroup.blocksRaycasts = false;

        menuCanvasGroup.alpha = 0;
        menuCanvasGroup.interactable = false;
        menuCanvasGroup.blocksRaycasts = false;

        orderCanvasGroup.alpha = 1;
        orderCanvasGroup.interactable = true;
        orderCanvasGroup.blocksRaycasts = true;

        statsCanvasGroup.alpha = 0;
        statsCanvasGroup.interactable = false;
        statsCanvasGroup.blocksRaycasts = false;

        settingsCanvasGroup.alpha = 0;
        settingsCanvasGroup.interactable = false;
        settingsCanvasGroup.blocksRaycasts = false;
    }

    public void StatsButton()
    {
        tutorialCanvasGroup.alpha = 0;
        tutorialCanvasGroup.interactable = false;
        tutorialCanvasGroup.blocksRaycasts = false;

        setupCanvasGroup.alpha = 0;
        setupCanvasGroup.interactable = false;
        setupCanvasGroup.blocksRaycasts = false;

        menuCanvasGroup.alpha = 0;
        menuCanvasGroup.interactable = false;
        menuCanvasGroup.blocksRaycasts = false;

        orderCanvasGroup.alpha = 0;
        orderCanvasGroup.interactable = false;
        orderCanvasGroup.blocksRaycasts = false;

        statsCanvasGroup.alpha = 1;
        statsCanvasGroup.interactable = true;
        statsCanvasGroup.blocksRaycasts = true;

        settingsCanvasGroup.alpha = 0;
        settingsCanvasGroup.interactable = false;
        settingsCanvasGroup.blocksRaycasts = false;
    }
    public void SettingsButton()
    {
        tutorialCanvasGroup.alpha = 0;
        tutorialCanvasGroup.interactable = false;
        tutorialCanvasGroup.blocksRaycasts = false;

        setupCanvasGroup.alpha = 0;
        setupCanvasGroup.interactable = false;
        setupCanvasGroup.blocksRaycasts = false;

        menuCanvasGroup.alpha = 0;
        menuCanvasGroup.interactable = false;
        menuCanvasGroup.blocksRaycasts = false;

        orderCanvasGroup.alpha = 0;
        orderCanvasGroup.interactable = false;
        orderCanvasGroup.blocksRaycasts = false;

        statsCanvasGroup.alpha = 0;
        statsCanvasGroup.interactable = false;
        statsCanvasGroup.blocksRaycasts = false;

        settingsCanvasGroup.alpha = 1;
        settingsCanvasGroup.interactable = true;
        settingsCanvasGroup.blocksRaycasts = true;
    }
}