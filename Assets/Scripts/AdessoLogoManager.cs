using HoloToolkit.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdessoLogoManager : KlotzManager {
    [SerializeField]
    [Tooltip("Adesso logo prefab")]
    private GameObject AdessoLogoPrefab;

    public override GameObject AddKlotz() {
        return base.AddKlotz(AdessoLogoPrefab);
    }
}
