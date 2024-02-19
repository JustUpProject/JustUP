using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosReset : MonoBehaviour
{
    void Start()
    {
        BasicControler.Instance.ResetPos();
    }

}
