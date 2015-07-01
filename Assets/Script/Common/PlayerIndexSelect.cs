using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerIndexSelect {
    public static List<int> SaveData(PlayerIndex player)
    {
        List<int> saveData = null;
        switch (player)
        {
            case PlayerIndex.P1:
                saveData = PassData.MonstersP1;
                break;
            case PlayerIndex.P2:
                saveData = PassData.MonstersP2;
                break;
            case PlayerIndex.P3:
                saveData = PassData.MonstersP3;
                break;
            case PlayerIndex.P4:
                saveData = PassData.MonstersP4;
                break;
            default:
                Debug.LogError(player);
                break;
        }

        if (saveData.Count == 0)
        {
            for( int i = 0; i < 3; i++ )
                saveData.Add(0);
        }

        return saveData;
    }

    
}
