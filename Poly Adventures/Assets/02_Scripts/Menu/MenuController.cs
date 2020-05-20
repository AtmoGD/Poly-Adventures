using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void PlayButtonClicked()
    {
        if (SaveSystemController.LoadPlayer() != null)
        {
            SceneManager.LoadScene(2);
        } else
        {
            SceneManager.LoadScene(1);
        }
    }
    public void NewGameButtonClicked()
    {
        SceneManager.LoadScene(1);
    }
    public void WarriorButtonClicked()
    {
        SaveSystemController.createNewGameState(HeroType.Warrior);
        SceneManager.LoadScene(2);
    }
    public void HunterButtonClicked()
    {
        SaveSystemController.createNewGameState(HeroType.Hunter);
        SceneManager.LoadScene(2);
    }
    public void MageButtonClicked()
    {
        SaveSystemController.createNewGameState(HeroType.Hunter);
        SceneManager.LoadScene(2);
    }
}
