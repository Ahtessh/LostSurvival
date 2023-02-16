using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public weapons weaponType;

    public string getWeaponType()
    {
        return weaponType.ToString();
    }
}
