using HoloToolkit.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class KlotzManager : Singleton<KlotzManager>
{

    public GameObject klotzHolder;

    public List<GameObject> KlotzList;

    private void Start() {
        KlotzList = new List<GameObject>();
    }

    internal GameObject AddKlotz(GameObject klotzPrefab)
    {   
        GameObject klotz = Instantiate(klotzPrefab, klotzHolder.transform);
        KlotzList.Add(klotz);
        return klotz;
    }

    internal void RemoveKlotz(GameObject klotzGameobject) {
        KlotzList.Remove(klotzGameobject);
        Destroy(klotzGameobject);
    }

    internal void RemoveAllKlotzes() {
        foreach(GameObject klotz in KlotzList) {
            Destroy(klotz);
        }
        KlotzList.Clear();
    }
}
