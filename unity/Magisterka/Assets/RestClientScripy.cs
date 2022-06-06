using Assets;
using Assets.scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RestClientScripy : MonoBehaviour
{
    #region Singleton
    public static RestClientScripy instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    string Eq = "";

    public IEnumerator GetUpgrades(string url, System.Action<UpgradesCollection> callBack)
    {
        using(UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                if (www.isDone)
                {
                    string jsonResult = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                    jsonResult = JsonHelper.fixJson("upgradesCollection", jsonResult);
                    UpgradesCollection upgrades = JsonUtility.FromJson<UpgradesCollection>(jsonResult);
                    callBack(upgrades);
                }
            }
        }
    }

    public IEnumerator AddEq(string wEB_URL, ItemInfo iteminfo, Action<int> refresh)
    {
        Item newItem = new Item(iteminfo.typ, iteminfo.hpmulti, iteminfo.attmulti, iteminfo.lvl);
        string serialized = JsonUtility.ToJson(newItem);
        using (UnityWebRequest www = UnityWebRequest.Post(wEB_URL, serialized))
        {
            www.SetRequestHeader("content-type", "application/json");
            www.SetRequestHeader("accept", "text/plain");
            www.uploadHandler.contentType = "application/json";
            www.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(serialized));
            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                if (www.isDone)
                {
                    var x = www.result;
                    //refresh(0);
                    //callBack(true);
                    //string jsonResult = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                    //jsonResult = JsonHelper.fixJson("upgradesCollection", jsonResult);
                    //UpgradesCollection upgrades = JsonUtility.FromJson<UpgradesCollection>(jsonResult);
                    //callBack(upgrades);
                }
            }
        }
    }

    internal string SubtractMoneyFromUserAccount(string uSER_URL, int money)
    {
        throw new NotImplementedException();
    }

    public IEnumerator DeleteEqNow(string wEB_URL, int id, Action<int> refresh)
    {
        string urlWithParams = string.Format("{0}/{1}", wEB_URL, id);
        using (UnityWebRequest www = UnityWebRequest.Delete(urlWithParams))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                if (www.isDone)
                {
                    //string jsonResult = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                    //Debug.Log(jsonResult);
                    refresh(0);
                }
            }
        }
    }

    public IEnumerator AddEqNow(string wEB_URL, ItemInfo itemInfo, Action<int> refresh)
    {
        Item newItem = new Item(itemInfo.typ, itemInfo.hpmulti, itemInfo.attmulti, itemInfo.lvl);
        string serialized = JsonUtility.ToJson(newItem);
        using (UnityWebRequest www = UnityWebRequest.Post(wEB_URL, serialized))
        {
            www.SetRequestHeader("content-type", "application/json");
            www.SetRequestHeader("accept", "text/plain");
            www.uploadHandler.contentType = "application/json";
            www.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(serialized));
            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                if (www.isDone)
                {
                    var x = www.result;
                    refresh(0);
                    //callBack(true);
                    //string jsonResult = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                    //jsonResult = JsonHelper.fixJson("upgradesCollection", jsonResult);
                    //UpgradesCollection upgrades = JsonUtility.FromJson<UpgradesCollection>(jsonResult);
                    //callBack(upgrades);
                }
            }
        }
    }

    public IEnumerator  DeleteEq(string wEB_URL, int id, Action<int> refresh)
    {
        string urlWithParams = string.Format("{0}/{1}", wEB_URL, id);
        using (UnityWebRequest www = UnityWebRequest.Delete(urlWithParams))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                if (www.isDone)
                {
                    //string jsonResult = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                    //Debug.Log(jsonResult);
                    //refresh(0);
                }
            }
        }
    }

    public IEnumerator GetEqNow(string wEB_URL, Action<EqCollection> getEQ)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(wEB_URL))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                if (www.isDone)
                {
                    string jsonResult = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                    Debug.Log(jsonResult);
                    jsonResult = JsonHelper.fixJson("eqCollection", jsonResult);
                    EqCollection upgrades = JsonUtility.FromJson<EqCollection>(jsonResult);
                    getEQ(upgrades);
                }
            }
        }
    }

    public IEnumerator GetEq(string wEB_URL, Action<EqCollection> getEQ)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(wEB_URL))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                if (www.isDone)
                {
                    string jsonResult = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                    jsonResult = JsonHelper.fixJson("eqCollection", jsonResult);
                    EqCollection eq = JsonUtility.FromJson<EqCollection>(jsonResult);
                    getEQ(eq);
                }
            }
        }
    }

    public IEnumerator PutUpgrades(string url, int id,int lvl, System.Action<bool> callBack)
    {
        string urlWithParams = string.Format("{0}{2}/{1}", url, id,"/api/upgrades");
        SerialInt intser = new SerialInt(lvl + 1);
        string json = JsonUtility.ToJson(intser);
        using (UnityWebRequest www = UnityWebRequest.Put(urlWithParams, json))
        {
            www.SetRequestHeader("content-type", "application/json");
            www.SetRequestHeader("accept", "text/plain");
            //www.uploadHandler.contentType = "application/json";
            //www.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(json));
            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                if (www.isDone)
                {
                    var x = www.result;
                    callBack(true);
                    //string jsonResult = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                    //jsonResult = JsonHelper.fixJson("upgradesCollection", jsonResult);
                    //UpgradesCollection upgrades = JsonUtility.FromJson<UpgradesCollection>(jsonResult);
                    //callBack(upgrades);
                }
            }
        }
    }
}
