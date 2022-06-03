using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DescriptionController : MonoBehaviour
{
    [SerializeField] private Text descriptionText;

    public void SetDescription(string text)
    {
        descriptionText.text = text;
    }
}
