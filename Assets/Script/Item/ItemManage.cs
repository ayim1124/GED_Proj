using UnityEngine;
using System.Collections;

public static class ItemManage
{
    const string _path = "Item/";
    static string[] _names = {"", "Item_AtkSpeedUp", "Item_MoveSpeedUp", "Item_AttackUp" };

    public static GameObject RandomGet()
    {
        string name = randomName();
        if( name == "" )
            return null;
        return GetPrefabAtResource.Create(_path + name);
    }

    static string randomName() {
        return _names[Random.Range(0, _names.Length)];
    }
}
