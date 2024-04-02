using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected WeaponItem _weapon;

    public virtual void Shoot()
    {

    }
}
