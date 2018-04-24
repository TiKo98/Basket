using HoloToolkit.Unity;
using System.Collections.Generic;
using UnityEngine;

public abstract class KlotzManager : Singleton<KlotzManager> {
    [SerializeField]
    private GameObject klotzHolder;
    [SerializeField]
    private List<GameObject> KlotzList;

    public virtual void Start() {
        KlotzList = new List<GameObject>();

        if(klotzHolder == null) {
            klotzHolder = this.gameObject;
        }
    }

    public abstract GameObject AddKlotz();

    public virtual GameObject AddKlotz(GameObject klotzPrefab) {   
        GameObject klotz = Instantiate(klotzPrefab, klotzHolder.transform);
        KlotzList.Add(klotz);
        return klotz;
    }

    public virtual void RemoveKlotz(GameObject klotzGameobject) {
        KlotzList.Remove(klotzGameobject);
        Destroy(klotzGameobject);
    }

    public virtual void RemoveAllKlotzes() {
        foreach(GameObject klotz in KlotzList) {
            Destroy(klotz);
        }
        KlotzList.Clear();
    }
}
