using UnityEngine;
using System.Collections;

public static class GetPrefabAtResource {
    public static GameObject Create( string prefabName )
    {
        GameObject obj = null;
        if (prefabName != "")
        {
            Object prefab = Resources.Load(prefabName);
            if( ErrorLog.CheckComponentExist(prefab, "Resources", prefabName) )
                obj = (GameObject)prefab;
        }
        return obj;
    }
}
