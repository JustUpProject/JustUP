
using UnityEngine;

public class Item_hide : Basic_Item
{
    // Start is called before the first frame update
    protected override void Start()
    {
        itemCode = 7;
        gameData = Resources.Load<GameData>("ScriptableObject/Datas");

    }
    
}
