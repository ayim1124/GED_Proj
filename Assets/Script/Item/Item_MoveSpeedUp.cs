using UnityEngine;
using System.Collections;

public class Item_MoveSpeedUp : ItemBase
{
    protected override void Effect(Collider2D Other)
    {
        Other.GetComponent<PlayerAttirbute>().MoveSpeed.Origin += 10;
    }
}
