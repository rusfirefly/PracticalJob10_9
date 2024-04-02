using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Weapon",menuName ="Weapon/NewWeapon")]
public class WeaponItem : ScriptableObject
{
    [field: SerializeField] public float Damage { get; private set; }

    [field: SerializeField] public float SpeedAttack { get; private set; }



    [field: SerializeField] public GameObject Bullet { get; private set; }

}
