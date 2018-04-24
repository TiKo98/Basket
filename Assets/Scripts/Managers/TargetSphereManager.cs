using HoloToolkit.Unity.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSphereManager : KlotzManager {
    [SerializeField]
    [Tooltip("Target sphere prefab")]
    private GameObject TargetSphere;

    [SerializeField]
    [Tooltip("Bullet prefab")]
    private GameObject Bullet;

    [SerializeField]
    [Tooltip("Bullet button prefab")]
    private GameObject BtnReloadBulletPrefab;
    private GameObject BtnReloadBullet;
    
    public override GameObject AddKlotz() {
        GameObject newTarget = base.AddKlotz(TargetSphere);
        newTarget.transform.localPosition = new Vector3(Random.Range(-3f, 3f),
                                                        Random.Range(-3f, 3f),
                                                        Random.Range(-3f, 3f));
        return newTarget;
    }

    public override void Start() {
        base.Start();

        AddReloadBulletButton();
    }

    protected override void OnDestroy() {
        base.OnDestroy();

        RemoveReloadBulletButton();
    }

    private void AddReloadBulletButton() {
        //get tools content
        GameObject toolsContent = GameObject.FindGameObjectWithTag("SceneSelectionMenuToolsContent");
        //add reload bullet button
        BtnReloadBullet = Instantiate(BtnReloadBulletPrefab, toolsContent.transform);
        BtnReloadBullet.name = "BtnReloadBullet";
        //update object collection
        toolsContent.GetComponent<ObjectCollection>().UpdateCollection();

        //add bullet reload button to receiver interactables
        GetComponent<TargetSphereReceiver>().interactables.Add(BtnReloadBullet);
    }

    private void RemoveReloadBulletButton() {
        //destroy reload bullet button
        Destroy(BtnReloadBullet);
        GameObject toolsContent = GameObject.FindGameObjectWithTag("SceneSelectionMenuToolsContent");
        //update object collection
        toolsContent.GetComponent<ObjectCollection>().UpdateCollection();

        //remove bullet reload button to receiver
        GetComponent<TargetSphereReceiver>().interactables.Remove(BtnReloadBullet);
    }
}
