using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

public sealed class MonsterData {

    string _filePath = "XML/Monster";


    void LoadXml()
    {
        TextAsset monsterXml = (TextAsset)Resources.Load(_filePath);
        XmlDocument xmlDoc = new XmlDocument();
        if (monsterXml == null)
        {
            Debug.LogError("Xml not find!");
            return;         
        }
        
        xmlDoc.LoadXml(monsterXml.text);
//        XmlNodeList monsterList = xmlDoc.GetElementsByTagName("Monster");

        /*foreach (XmlNode monster in monsterList)
        {
            if (monster.Attributes["ID"].Value == ID.ToString())
            {
                Debug.Log(monster.Attributes["HP"].Value);
            }

        }*/
    }
}
