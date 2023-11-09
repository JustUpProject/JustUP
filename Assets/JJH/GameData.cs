using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Data
{
    public string key;
    public float value;
}


[CreateAssetMenu(fileName = "Data", menuName = "Game/GameData" )]
public class GameData : ScriptableObject
{
    [SerializeField]
    private Vector3 savePoint;       //게임 시작 시 초기화 필요
    public Vector3 SavePoint { get => savePoint; set => savePoint = value; }

    
    public List<Data> data = new List<Data>();

}
