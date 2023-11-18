using UnityEngine;

public class Item_Shield : Basic_Item
{

    // Start is called before the first frame update
    protected override void Start()
    {
        itemCode = 1;
        gameData = Resources.Load<GameData>("ScriptableObject/Datas");

    }

    // Update is called once per frame
    void Update()
    {

    }
}
