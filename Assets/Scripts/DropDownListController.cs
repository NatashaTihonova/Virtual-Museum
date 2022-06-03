using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDownListController : MonoBehaviour
{
    [SerializeField] private Dropdown dropDown;

    //private List<int> _classes = new List<int> { 231, 13413, };

    private void OnEnable()
    {
        dropDown?.onValueChanged.AddListener(ChooseMinerals);
    }

    private void OnDisable()
    {
        dropDown?.onValueChanged.RemoveListener(ChooseMinerals);
    }

    private void ChooseMinerals(int value)
    {
        PlayerPrefs.SetInt("Id", value);
        Debug.Log(value);
    }
}
