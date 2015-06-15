using UnityEngine;
using System.Collections;
using System.Xml;
using System.IO;
using System;

public class MonsterAttribute : MonoBehaviour {
    //-Star -HP -ATK(Max/Cur) -AS(Max/Cur) -MV(Max/Cur) -AR(?) skill
    //Weapon/ -ATK -AR -AS -New Obj-> 爆炸範圍 效果

    public int ID = 0;

    public int Star { get; private set; }
    public int HP{ get; private set; }
    MaxAndCurrent _attack = new MaxAndCurrent();
    public MaxAndCurrent Attack { get { return _attack; } }
    MaxAndCurrent _attackSpeed = new MaxAndCurrent();
    public MaxAndCurrent AttackSpeed { get { return _attackSpeed; } }
    MaxAndCurrent _moveSpeed = new MaxAndCurrent();
    public MaxAndCurrent MoveSpeed { get { return _moveSpeed; }}

    void LoadXml() {
        string filepath = "XML/Monster";
        TextAsset monsterXml = (TextAsset)Resources.Load(filepath);

        XmlDocument xmlDoc = new XmlDocument();
        if (monsterXml != null) {
            xmlDoc.LoadXml(monsterXml.text);
        }else{
            Debug.LogError("XML not find");
        }
        XmlNodeList monsterList = xmlDoc.GetElementsByTagName("Monster");

        foreach (XmlNode monster in monsterList) {
            if (monster.Attributes["ID"].Value == ID.ToString()) {
                Star = Int32.Parse(monster.Attributes["Star"].Value);
                HP = Int32.Parse(monster.Attributes["HP"].Value);
                _attack.initial(Int32.Parse(monster.Attributes["MaxAtk"].Value), Int32.Parse(monster.Attributes["CurAtk"].Value));
                _attackSpeed.initial(Int32.Parse(monster.Attributes["MaxAs"].Value), Int32.Parse(monster.Attributes["CurAs"].Value));
                _moveSpeed.initial(Int32.Parse(monster.Attributes["MaxMv"].Value), Int32.Parse(monster.Attributes["CurMv"].Value));
            }
        }
    }

	// Use this for initialization
	void Start () {
        LoadXml();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
