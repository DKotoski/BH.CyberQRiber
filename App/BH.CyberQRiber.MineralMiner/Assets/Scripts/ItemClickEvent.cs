using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ItemClickEvent : MonoBehaviour
{
    private void Start()
    {
        var button = GetComponent<Button>();
        var component = button.transform.parent.GetComponent<ClickableItemController>();

        button.onClick.AddListener(component.Click);
    }
}