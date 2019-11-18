using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameController : MonoBehaviour
{
    public static GameController control;
    public int attack;
    public int defense;
    public int health;
    public int weaponNumber = 0;
    List<Weapon> weapons = new List<Weapon>();
    int indexCourant = 0;

    // Use this for initialization
    void Start()
    {


        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
            SetDefaultValues();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void SetDefaultValues()
    {
        attack = 1;
        defense = 1;
        health = 1;
    }
    public void AddAttack()
    {
        attack++;

    }
    public void AddDefense()
    {
        defense++;
    }
    public void AddHealth()
    {
        health++;
    }

    public void Load()
    {
        BinaryFormatter bf = new BinaryFormatter();
        if (!File.Exists(Application.persistentDataPath + "gameInfo.dat"))
        {
            throw new Exception("Game file don't exist");
        }
        FileStream file = File.Open(Application.persistentDataPath + "gameInfo.dat", FileMode.Open);
        PlayerData playeDataToLoad = (PlayerData)bf.Deserialize(file);
        file.Close();
        attack = playeDataToLoad.attack;
        defense = playeDataToLoad.defense;
        health = playeDataToLoad.health;
        weapons = playeDataToLoad.weapons;

        indexCourant = playeDataToLoad.weaponIndex;
        weaponNumber = weapons.Count;

    }
    public void Save()
    {

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "gameInfo.dat", FileMode.Create);
        PlayerData playerDataToSave = new PlayerData();
        playerDataToSave.attack = attack;
        playerDataToSave.defense = defense;
        playerDataToSave.health = health;
        playerDataToSave.weapons = weapons;
        playerDataToSave.weaponIndex = indexCourant;
        bf.Serialize(file, playerDataToSave);
        file.Close();


    }
    public void AddWeapon()
    {
        weaponNumber++;
        Weapon currentWeapon = new Weapon();
        currentWeapon.weaponAttack = 1;
        weapons.Add(currentWeapon);
        indexCourant = weapons.Count - 1;


    }
    public void AddWeaponAttack()
    {
        weapons[indexCourant].weaponAttack++;
    }
    public void NextWeapon()
    {
        if (indexCourant == weapons.Count-1)
        {
            indexCourant = 0;
        }
        else
        {
            indexCourant++;
        }

    }
    public void PerviousWeapon()
    {
        if (indexCourant == 0)
        {
            indexCourant = weapons.Count-1;
        }
        else
        {
            indexCourant--;
        }
    }

    private void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 32;
        GUI.Label(new Rect(10, 60, 180, 80), "Attack: " + attack, style);
        GUI.Label(new Rect(10, 100, 180, 80), "Defense: " + defense, style);
        GUI.Label(new Rect(10, 160, 180, 80), "Health: " + health, style);
        if (weaponNumber != 0)
        {
            GUI.Label(new Rect(10, 200, 180, 80), "WeaponIndex: " + indexCourant, style);
            GUI.Label(new Rect(10, 240, 180, 80), "WeaponAttack: " + weapons[indexCourant].weaponAttack, style);

        }

    }
}
[Serializable]
class PlayerData
{
    public int attack;
    public int defense;
    public int health;
    public List<Weapon> weapons;
    public int weaponIndex;
}
[Serializable]
class Weapon
{
    public int weaponAttack;

}

