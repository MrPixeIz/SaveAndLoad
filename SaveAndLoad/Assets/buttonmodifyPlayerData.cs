﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonmodifyPlayerData : MonoBehaviour
{
    public void IncreaseAttack()
    {
        GameController.control.AddAttack();
    }
    public void IncreaseDefense()
    {
        GameController.control.AddDefense();
    }
    public void IncreaseHealth()
    {
        GameController.control.AddHealth();
    }


}
