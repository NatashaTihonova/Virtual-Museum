using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineralInfo : MonoBehaviour
{
    [SerializeField] private GameObject Circle;
    [SerializeField] public int ExhibitionID;
    [SerializeField] public int Class;
    [SerializeField] public int Number;

    public void SetCircle(bool value)
    {
        Circle.SetActive(value);
    }
}
