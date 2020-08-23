using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonGroupScript : MonoBehaviour {
    public Canvas tutorialCanvas;
    public Canvas setupCanvas;
    public Canvas menuCanvas;
    public Canvas orderCanvas;
    public Canvas settingsCanvas;

    private CanvasGroup tutorialCanvasGroup;
    private CanvasGroup setupCanvasGroup;
    private CanvasGroup menuCanvasGroup;
    private CanvasGroup orderCanvasGroup;
    private CanvasGroup settingsCanvasGroup;

    // Start is called before the first frame update
    void Start () {
        tutorialCanvasGroup = tutorialCanvas.GetComponent<CanvasGroup> ();
        setupCanvasGroup = setupCanvas.GetComponent<CanvasGroup> ();
        menuCanvasGroup = menuCanvas.GetComponent<CanvasGroup> ();
        orderCanvasGroup = orderCanvas.GetComponent<CanvasGroup> ();
        settingsCanvasGroup = settingsCanvas.GetComponent<CanvasGroup> ();
    }

    // Update is called once per frame
    void Update () {

    }

    public void TutorialButton () {
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

        settingsCanvasGroup.alpha = 0;
        settingsCanvasGroup.interactable = false;
        settingsCanvasGroup.blocksRaycasts = false;

    }

    public void SetupButton () {
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

        settingsCanvasGroup.alpha = 0;
        settingsCanvasGroup.interactable = false;
        settingsCanvasGroup.blocksRaycasts = false;
    }

    public void MenuButton () {
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

        settingsCanvasGroup.alpha = 0;
        settingsCanvasGroup.interactable = false;
        settingsCanvasGroup.blocksRaycasts = false;
    }

    public void OrderButton () {
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

        settingsCanvasGroup.alpha = 0;
        settingsCanvasGroup.interactable = false;
        settingsCanvasGroup.blocksRaycasts = false;
    }

    public void SettingsButton () {
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

        settingsCanvasGroup.alpha = 1;
        settingsCanvasGroup.interactable = true;
        settingsCanvasGroup.blocksRaycasts = true;
    }
}