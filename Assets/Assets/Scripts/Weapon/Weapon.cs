using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int attackValue;

    public virtual void Attack()
    {
        Debug.Log("Attacking with " + this.name + " for " + attackValue + " damage.");
    }
}
