using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BayatGames.SaveGameFree;

public class LevelManager : MonoBehaviour
{
    public class PlayerData
    {
        public string name;
    }

     void Start()
    {
        PlayerData data = new PlayerData();
        data.name = "Josh";

        SaveGame.Save<PlayerData>("playerData", data);
    }
   
}
