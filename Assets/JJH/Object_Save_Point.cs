using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Save_Point : MonoBehaviour
{
    public GameData gameData;

    private void Start()
    {
        gameData = Resources.Load<GameData>("ScriptableObject/Datas");
        if(gameData.data == null)
        {
            Debug.Log("ins");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log(gameData.data[0].key + gameData.data[0].value);
            gameData.SavePoint = this.transform.position;
        }
    }
}
