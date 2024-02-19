using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUIController : MonoBehaviour
{
    [SerializeField] private Image Health00;
    [SerializeField] private Image Health01;
    [SerializeField] private Image Health02;

    private Sprite HealthOn;
    private Sprite HealthOff;

    private void Awake()
    {
        HealthOn = Resources.Load<Sprite>("Image/lifepoint_on");
        HealthOff = Resources.Load<Sprite>("Image/lifepoint_off");
    }

    private void Update()
    {
        HealthUpdate();
    }

    public void HealthUpdate()
    {
        if (BasicControler.Instance.PlayerHealth == 3)
        {
            Health00.sprite = HealthOn;
            Health01.sprite = HealthOn;
            Health02.sprite = HealthOn;
        }
        else if (BasicControler.Instance.PlayerHealth == 2)
        {
            Health00.sprite = HealthOff;
            Health01.sprite = HealthOn;
            Health02.sprite = HealthOn;
        }
        else if (BasicControler.Instance.PlayerHealth == 1)
        {
            Health00.sprite = HealthOff;
            Health01.sprite = HealthOff;
            Health02.sprite = HealthOn;
        }
        else if (BasicControler.Instance.PlayerHealth <= 0)
        {
            Health00.sprite = HealthOff;
            Health01.sprite = HealthOff;
            Health02.sprite = HealthOff;
        }
    }
}
