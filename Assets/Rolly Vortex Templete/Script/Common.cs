using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
class Common
{
}

public class BallData
{
    public Vector3 pos;
    public Quaternion rotation;
    public float angle;
};

public enum AchieveType
{
    TotalScore = 1,
    PlayerTimes = 2,
    BestScore = 3,
}

public enum GameStateEnum
{
    None = 0,
    StartGame,
    GameOver,
}

public class PlayerPrefTag
{
    public const string TotalScore = "TotalScore"; 
    public const string PlayerTimes = "PlayerTimes";
    public const string BestScore = "BestScore";
    public const string SkinIndex = "SkinIndex";
    public const string TubeSkin = "TubeSkin";
    public const string Coin = "Coin";
    public const string TubeTexture = "TubeTexture";
}
