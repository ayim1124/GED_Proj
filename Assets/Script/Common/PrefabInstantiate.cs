using UnityEngine;
using System.Collections;

public static class PrefabInstantiate {
    public static GameObject Create(string prefabName, string objName, Vector3 pos, Quaternion rotation)
    {
        Object prefab = Resources.Load(prefabName);
        if (prefab == null)
        {
            Debug.LogError("Can't find resources : " + prefabName);
            return null;
        }

        GameObject obj = (GameObject)MonoBehaviour.Instantiate(prefab, pos, rotation);
        if (obj == null)
        {
            Debug.LogError("Instantiate fail : " + prefabName);
            return null;
        }

        obj.name = objName;
        return obj;
    }

    public static GameObject Create(string prefabName, string objName)
    {
        Object prefab = Resources.Load(prefabName);
        if (prefab == null)
        {
            Debug.LogError("Can't find resources : " + prefabName);
            return null;
        }

        GameObject obj = (GameObject)MonoBehaviour.Instantiate(prefab);
        if (obj == null)
        {
            Debug.LogError("Instantiate fail : " + prefabName);
            return null;
        }

        obj.name = objName;
        return obj;
    }
}
