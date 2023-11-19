using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class MenuManager
{
    private static GameObject instructionsMenu;
    public static void Init()
    {
        instructionsMenu = GameObject.Find("InstructionsPanelCanvas");
        if (instructionsMenu == null)
        {
            Debug.LogError("GameObject Not Found");
        }
        instructionsMenu.SetActive(false);
    }

    public static void GoToMenu(MenuEnum menu)
    {
        switch (menu) 
        {
            case MenuEnum.MainMenu:
                SceneManager.LoadScene("MainMenu");
                break;
            case MenuEnum.InstructionsMenu:
                instructionsMenu.SetActive(true);
                break;
        }
    }
}
