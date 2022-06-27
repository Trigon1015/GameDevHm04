using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Level1()
    {
        SceneManager.LoadScene("Level1");
        GameManager.level = 1;

    }
    public void Level2()
    {
        SceneManager.LoadScene("Level2");
        GameManager.level = 2;
    }

    public void Level3()
    {
        SceneManager.LoadScene("Level3");
        GameManager.level = 3;
    }

    public void MenuScene()
    {
        SceneManager.LoadScene("Menu");
        GameManager.score = 0;
        
    }
}
