using UnityEngine;
using System.Collections;

public class Item_AtkSpeedUp : ItemBase
{
    protected override void Effect(Collider2D Other)
    {
        Other.GetComponent<PlayerAttirbute>().AttackSpeed.Origin += 10;
    }
}
