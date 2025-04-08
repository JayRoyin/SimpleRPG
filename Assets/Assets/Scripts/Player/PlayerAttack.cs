using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Weapon weapon;

    public Sprite weaponIcon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && weapon != null)
        {
            weapon.Attack();
        }
        else if (Input.GetMouseButtonDown(1) && weapon != null)
        {
            weapon.Attack();
        }
    }

    public void LoadWeapon(ItemSO itemSO)
    {
        if (weapon != null)
        {
            Destroy(weapon.gameObject);
            weapon = null;
        }
        string prefabName = itemSO.prefab.name;
        Transform weaponParent = transform.Find(prefabName + "Pos");
        GameObject weaponGO =  GameObject.Instantiate(itemSO.prefab);
        weaponGO.transform.parent = weaponParent;
        weaponGO.transform.localPosition = Vector3.zero;
        weaponGO.transform.localRotation = Quaternion.identity;

        this.weapon = weaponGO.GetComponent<Weapon>();
    }
    public void LoadWeapon(Weapon weapon)
    {
        this.weapon = weapon;
    }
    public void UnWeapon(Weapon weapon)
    {
        weapon = null;
    }
}
