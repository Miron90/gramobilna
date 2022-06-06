using Assets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEq : MonoBehaviour
{
    public string WEB_URL_EQ = "";
    public string WEB_URL_EQNOW = "";
    public string EQTag = "";
    public string HpTag = "";
    public string AttTag = "";
    double hp = 100;
    double att = 10;
    public int money = 1000;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RestClientScripy.instance.GetEq(WEB_URL_EQ, GetEQ));
        StartCoroutine(RestClientScripy.instance.GetEqNow(WEB_URL_EQNOW, GetEQNow));
        //info about helath and attack
        //TODO get info about money
    }

    public void RefreshEq(int id)
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("eqnow"))
        {
            int count = obj.transform.childCount;
            for (int i = 0; i < count; i++)
            {
                Destroy(obj.transform.GetChild(0).gameObject);
            }
        }
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("eq"))
        {
            int count = obj.transform.childCount;
            for (int i = 0; i < count; i++)
            {
                Destroy(obj.transform.GetChild(0).gameObject);
            }
        }
        StartCoroutine(RestClientScripy.instance.GetEq(WEB_URL_EQ, GetEQ));
        StartCoroutine(RestClientScripy.instance.GetEqNow(WEB_URL_EQNOW, GetEQNow));
        //info about helath and attack
    }
    public void DeleteFromEqAddToEqnow(ItemInfo itemInfo)
    {
        StartCoroutine(RestClientScripy.instance.DeleteEq(WEB_URL_EQ, itemInfo.id, RefreshEq));
        StartCoroutine(RestClientScripy.instance.AddEqNow(WEB_URL_EQNOW, itemInfo, RefreshEq));
    }

    public void DeleteFromEqNowAddToEq(ItemInfo itemInfo)
    {
        //seriazlize and send it
        StartCoroutine(RestClientScripy.instance.AddEq(WEB_URL_EQ, itemInfo, RefreshEq));
        StartCoroutine(RestClientScripy.instance.DeleteEqNow(WEB_URL_EQNOW, itemInfo.id, RefreshEq));
    }

    private void GetEQNow(EqCollection eqNowCollection)
    {
        GameObject[] eqslots = GameObject.FindGameObjectsWithTag(EQTag);
        for(int i = 0; i < eqslots.Length; i++)
        {
            for(int j = 0; j < eqNowCollection.eqCollection.Length; j++)
            {
                if (eqslots[i].GetComponent<ItemSlot>().tag.Equals(eqNowCollection.eqCollection[j].typ))
                {
                    GameObject[] image = GameObject.FindGameObjectsWithTag(eqNowCollection.eqCollection[j].typ);
                    GameObject im = Instantiate(image[eqNowCollection.eqCollection[j].lvl - 1]);
                    im.transform.parent = eqslots[i].transform;
                    im.transform.position = eqslots[i].transform.position;
                    im.GetComponent<ItemInfo>().id = eqNowCollection.eqCollection[j].id;
                    im.GetComponent<ItemInfo>().typ = eqNowCollection.eqCollection[j].typ;
                    im.GetComponent<ItemInfo>().lvl = eqNowCollection.eqCollection[j].lvl;
                    im.GetComponent<ItemInfo>().hpmulti = eqNowCollection.eqCollection[j].hpmulti;
                    im.GetComponent<ItemInfo>().attmulti = eqNowCollection.eqCollection[j].attmulti;
                    im.GetComponent<ItemInfo>().slot = EQTag;
                    hp *= eqNowCollection.eqCollection[j].hpmulti;
                    att *= eqNowCollection.eqCollection[j].attmulti;
                    break;
                }
            }
            GameObject.FindGameObjectWithTag(HpTag).GetComponent<Text>().text = hp.ToString();
            GameObject.FindGameObjectWithTag(AttTag).GetComponent<Text>().text = att.ToString();
        }
    }

    void GetEQ(EqCollection eqCollection)
    {
        GameObject[] eq = GameObject.FindGameObjectsWithTag("eq");
        
        for(int i=0; i< eqCollection.eqCollection.Length; i++)
        {
            GameObject[] image = GameObject.FindGameObjectsWithTag(eqCollection.eqCollection[i].typ);
            GameObject im = Instantiate(image[eqCollection.eqCollection[i].lvl - 1]);
            im.transform.parent = eq[i].transform;
            im.transform.position = eq[i].transform.position;
            im.GetComponent<ItemInfo>().id = eqCollection.eqCollection[i].id;
            im.GetComponent<ItemInfo>().typ = eqCollection.eqCollection[i].typ;
            im.GetComponent<ItemInfo>().lvl = eqCollection.eqCollection[i].lvl;
            im.GetComponent<ItemInfo>().hpmulti = eqCollection.eqCollection[i].hpmulti;
            im.GetComponent<ItemInfo>().attmulti = eqCollection.eqCollection[i].attmulti;
            im.GetComponent<ItemInfo>().slot = "eq";
        }
    }

   
}
