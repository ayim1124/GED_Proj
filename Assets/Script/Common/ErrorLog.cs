using UnityEngine;
using System.Collections;

public static class ErrorLog {
    /// <summary>
    /// type為Component的型態，name為物件的名稱
    /// 物件存在會回傳true 物件null回傳false
    /// </summary>
    public static bool CheckComponentExist<T>(T obj, string type,  string name = "" )
    {
        if (obj == null)
        {
            string log = type + " not find";
            if (name != "")
                log = name + " : Component " + log;
            Debug.LogError(log);
            return false;
        }
        return true;
    }
}
