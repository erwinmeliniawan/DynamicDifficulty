using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coint : Collectable
{
    [SerializeField] int cointValue = 10;
    protected override void Collected()
    {
        //SaveCoint
        GameManager.MyInstance.AddCoins(cointValue);
        Destroy(this.gameObject);
    }
}
