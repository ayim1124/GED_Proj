using UnityEngine;
using System.Collections;

public class Item_AtkUp : ItemBase
{
    protected override void Effect(Collider2D Other)
    {
        Other.GetComponent<PlayerAttirbute>().Attack.Origin += 10;
    }
}
