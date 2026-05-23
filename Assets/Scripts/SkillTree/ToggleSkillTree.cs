using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ToggleSkillTree : MonoBehaviour
{
    public CanvasGroup statsCanvas;
    private bool SkillPanelActive = false;

    private void Update()
    {
        if (Input.GetButtonDown("ToggleSkillTree"))
        {
            if (SkillPanelActive)
            {
                Time.timeScale = 1;
                statsCanvas.alpha = 0;
                statsCanvas.blocksRaycasts = false;
                SkillPanelActive = false;
            }
            else
            {
                Time.timeScale = 0;
                statsCanvas.alpha = 1;
                statsCanvas.blocksRaycasts = true;
                SkillPanelActive = true;
            }
        }
    }
}
