using Assets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMap : MonoBehaviour
{
    public int indexOfmap = 0;
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }
    public void StartGame()
    {
        SceneManager.LoadScene(3 + indexOfmap);
    }
    public void RightArrow()
    {
        
        GameObject[] buttons = GameObject.FindGameObjectsWithTag("button");
        buttons[1].GetComponent<Button>().interactable = true;
        if (indexOfmap < 3)
        {
            indexOfmap++;

        }
        if (indexOfmap >= 3)
        {
            buttons[0].GetComponent<Button>().interactable = false;
            return;
        }
    }
    public void LeftArrow()
    {
        GameObject[] buttons = GameObject.FindGameObjectsWithTag("button");
        buttons[0].GetComponent<Button>().interactable = true;
        if (indexOfmap > 0)
        {
            indexOfmap--;
        }
        if (indexOfmap <= 0)
        {
            buttons[1].GetComponent<Button>().interactable = false;
            return;
        }
    }
}
