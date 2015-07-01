using UnityEngine;
using System.Collections;
using System.Xml;
using System.IO;
using System;

public sealed class LevelGenerator : MonoBehaviour {
    const string _xmlPath = "XML/Level01";
    const string _landPath = "Land/";
    const string _playerImagePath = "Image/Player/";
    public Transform LandCollect;
    
    // Use this for initialization
	void Start () {
        SoundManage.Instance.Menu.Stop();
        SoundManage.Instance.Fight.Play();

        if (PassData.PlayerAmount == 0)
        {
            PassData.PlayerAmount = 2;
            PlayerIndexSelect.SaveData(PlayerIndex.P1);
            PassData.MonstersP1[0] = 1;
            PassData.MonstersP1[1] = 2;
            PassData.MonstersP1[2] = 3;
            PlayerIndexSelect.SaveData(PlayerIndex.P2);
            PassData.MonstersP2[0] = 4;
        }

        LoadXml();
	}

    
     void LoadXml() {
        TextAsset levelXml = (TextAsset)Resources.Load(_xmlPath);

        XmlDocument xmlDoc = new XmlDocument();
        if( ErrorLog.CheckComponentExist( levelXml, "XML" ) )
            xmlDoc.LoadXml(levelXml.text);

        XmlNodeList landList = xmlDoc.GetElementsByTagName("Land");
        foreach (XmlNode land in landList)
        {
            XmlNode positionNode = land.LastChild;
            string strx = positionNode.Attributes["x"].Value;
            string stry = positionNode.Attributes["y"].Value;
            string strz = positionNode.Attributes["z"].Value;
            float x, y, z;
            float.TryParse(strx, out x);
            float.TryParse(stry, out y);
            float.TryParse(strz, out z);

            GameObject obj = PrefabInstantiate.Create(_landPath + land.Attributes["Name"].Value, land.Attributes["Name"].Value);
            obj.transform.parent = LandCollect;
            obj.transform.localPosition = new Vector3(x * BaseDefine.g_scale, y * BaseDefine.g_scale, z);
        }

        XmlNodeList playerList = xmlDoc.GetElementsByTagName("Player");
        foreach (XmlNode player in playerList) {
            if (Int32.Parse(player.Attributes["Index"].Value) < PassData.PlayerAmount) {
                Sprite icon = Resources.Load<Sprite>(_playerImagePath + player.Attributes["Image"].Value);
                XmlNode positionNode = player.LastChild;
                string strx = positionNode.Attributes["x"].Value;
                string stry = positionNode.Attributes["y"].Value;
                string strz = positionNode.Attributes["z"].Value;
                float x, y, z;
                float.TryParse(strx, out x);
                float.TryParse(stry, out y);
                float.TryParse(strz, out z);

                PlayerGenerator.Create((PlayerIndex)Enum.Parse(typeof(PlayerIndex), player.Attributes["Index"].Value), new Vector3(x * BaseDefine.g_scale, y * BaseDefine.g_scale, z), icon);
            }
        }

        GameObject.Find("PlayerManage").GetComponent<PlayersManage>().Initial();
    }
}
