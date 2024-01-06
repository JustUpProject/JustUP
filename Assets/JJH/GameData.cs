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

    //큐는 직렬화가 안되서 보이지가 않음. 때문에 리스트로 큐느낌으로 구현하거나 다른 방법을 생각해봐야겠슴
    [SerializeField]
    private List<int> inventory = new List<int>(3);
    public List<int> Inventory { get => inventory; set => inventory = value; }

    //public List<int> Inventory 

    public List<Data> data = new List<Data>();

}