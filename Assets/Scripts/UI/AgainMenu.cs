using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AgainMenu : MonoBehaviour
{
    public void Replay()
    {
        SceneManager.LoadScene("Video");
    }

    public void MainMenu()
    {
        MenuManager.GoToMenu(MenuEnum.MainMenu);
    }
}
