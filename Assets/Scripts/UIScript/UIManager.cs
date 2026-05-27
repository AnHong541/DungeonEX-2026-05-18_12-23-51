using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup menuBar;
    private bool isMenuActive;

    [SerializeField] private CanvasGroup statsMenu;
    [SerializeField] private CanvasGroup skillsMenu;


    private void Update()
    {
        if (Input.GetButtonDown("ToggleMenu"))
        {
            Time.timeScale = 0;
            isMenuActive = !isMenuActive;
            SetMenuState(menuBar, isMenuActive);

            if (!isMenuActive)
            {
                Time.timeScale = 1;
                SetMenuState(statsMenu, false);
                SetMenuState(skillsMenu, false);
            }
        }
    }

    public void ToggleMenu(CanvasGroup target)
    {
        if (!isMenuActive)
        {
            isMenuActive = true;
            SetMenuState(menuBar, true);
        }

        SetMenuState(statsMenu, false);
        SetMenuState(skillsMenu, false);
        SetMenuState(target, true);
    }

    private void SetMenuState(CanvasGroup group, bool active)
    {
        group.alpha = active ? 1 : 0;
        group.interactable = active;
        group.blocksRaycasts = active;
    }
}
