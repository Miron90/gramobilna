using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void MapScene()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            return;
        }
        SceneManager.LoadScene(0);
    }
    public void EqScene()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            return;
        }
        SceneManager.LoadScene(1);
    }
    public void UpgradeScene()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            return;
        }
        SceneManager.LoadScene(2);
    }
}
