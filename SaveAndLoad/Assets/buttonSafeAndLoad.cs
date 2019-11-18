using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonSafeAndLoad : MonoBehaviour {

	public void Save()
    {
        GameController.control.Save();
    }

    public void Load()
    {
        GameController.control.Load();
    }
    public void AddWeapon()
    {

        GameController.control.AddWeapon();
    }
    public void AddWeaponAttack()
    {
        GameController.control.AddWeaponAttack();
    }
    public void NextWeapon()
    {
        GameController.control.NextWeapon();

    }
    public void PerviousWeapon()
    {
        GameController.control.PerviousWeapon();
    }
}
