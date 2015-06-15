using UnityEngine;
using System.Collections;

public static class ItemManage
{
    const string _path = "Item/";
    static string[] _names = {"", "Item_AtkSpeedUp", "Item_MoveSpeedUp", "Item_AttackUp" };

    public static GameObject RandomGet()
    {
        GameObject obj = null;
        string name = randomName();
        if (name != ""){
            Object prefab = Resources.Load(_path + name);
            if (prefab == null)
                Debug.LogError("Can't find resources : " + name);
            else
                obj = (GameObject)prefab;
        }
        return obj;
    }

    static string randomName() {
        return _names[Random.Range(0, _names.Length)];
    }
}
