using Assets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUpgrades : MonoBehaviour
{
    public string upgrades_URL = "";
    public string account_URL = "";
    public string upgradeTag = "";
    public string USER_URL = "";
    public string moneyTag = "";
    public int money = 1000;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RestClientScripy.instance.GetUpgrades(upgrades_URL, GetUpgrades));
        //TODO get info about money
    }
    void GetUpgrades(UpgradesCollection upgradesCollection)
    {
        GameObject[] upgrades = GameObject.FindGameObjectsWithTag(upgradeTag);
        
        for(int i=0; i<upgradesCollection.upgradesCollection.Length; i++)
        {
            GameObject level = upgrades[i].transform.GetChild(1).gameObject;
            GameObject price = upgrades[i].transform.GetChild(3).gameObject;
            GameObject button = upgrades[i].transform.GetChild(5).gameObject;
            GameObject upgradesPanels = upgrades[i].transform.GetChild(4).gameObject;
            GameObject multiplayer = upgrades[i].transform.GetChild(6).gameObject;
            level.GetComponent<Text>().text = "Level: " + upgradesCollection.upgradesCollection[i].lvl;
            price.GetComponent<Text>().text = upgradesCollection.upgradesCollection[i].price.ToString();
            multiplayer.GetComponent<Text>().text = Math.Round(upgradesCollection.upgradesCollection[i].multiplayer,2).ToString();
            if (upgradesCollection.upgradesCollection[i].lvl > 19)
            {
                button.GetComponent<Button>().interactable = false;
                button.GetComponent<Image>().color = new Color(43, 115, 32);
            }
            for(int j=0;j< upgradesCollection.upgradesCollection[i].lvl; j++)
            {
                upgradesPanels.transform.GetChild(j).gameObject.GetComponent<Image>().color = new Color(0,255,255);
            }
        }
    }
    public void AddLevelToUpgrade(int index)
    {
        GameObject obj = GameObject.FindGameObjectsWithTag(upgradeTag)[index - 1].transform.GetChild(1).gameObject;
        int x = int.Parse(obj.GetComponent<Text>().text.Substring(7, obj.GetComponent<Text>().text.Length - 7));
        money -= int.Parse(GameObject.FindGameObjectsWithTag(upgradeTag)[index - 1].transform.GetChild(3).GetComponent<Text>().text);
        StartCoroutine(RestClientScripy.instance.SubtractMoneyFromUserAccount(USER_URL, money));
        GameObject.FindGameObjectWithTag(moneyTag).GetComponent<Text>().text = money.ToString();
        StartCoroutine(RestClientScripy.instance.PutUpgrades(upgrades_URL, index,x, RefreshUpgrades));
    }

    void RefreshUpgrades(bool ok)
    {
        StartCoroutine(RestClientScripy.instance.GetUpgrades(upgrades_URL, GetUpgrades));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
