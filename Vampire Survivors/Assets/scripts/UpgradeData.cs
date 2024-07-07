using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum UpgradeType{
    WeaponUpgrade,
    SpeedUpgrade
}

[CreateAssetMenu]

public class UpgradeData : MonoBehaviour
{
    public UpgradeType upgradeType;
    public string Name;
    public Sprite icon;
}
