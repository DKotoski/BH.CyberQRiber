using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ClickableItemController : MonoBehaviour
{
    private DateTime LastClicked;
    private TimeSpan RefreshTime;
    private DateTime PlannedRefresh;

    public int RefreshTimeSeconds;

    public Slider Slider { get; set; }

    public bool CanBeClicked { get { return SliderValue() <= 0; } }

    public Item Item;

    public List<Item> itemPool;

    private void Start()
    {
        Slider = GetComponent<Slider>();
        RefreshTime = new TimeSpan(RefreshTimeSeconds * 10000000);
        //  Click();
        Slider.value = SliderValue();
    }

    private void Update()
    {
        Slider.value = SliderValue();
        if (Slider.value == 0)
        {
            Item = itemPool.First();
            itemPool.RemoveAt(0);
        }
    }

    private float SliderValue()
    {
        if (LastClicked != null && PlannedRefresh != null)
        {
            var res = (PlannedRefresh.Ticks - DateTime.Now.Ticks) / (float)RefreshTime.Ticks;
            if (res < 0) return 0;
            return res;
        }
        return 0;
    }

    public void Click()
    {
        if (CanBeClicked)
        {
            LastClicked = DateTime.Now;
            PlannedRefresh = LastClicked + RefreshTime;
            RevealItem();
        }
    }

    public void RevealItem()
    {
        var coverButton = transform.parent.parent.GetChild(1).gameObject;
        coverButton.SetActive(true);

        coverButton.transform.GetChild(0).GetComponent<Image>().sprite = Item.Sprite;
        StartCoroutine(HideButtonAfter(1));
    }

    public IEnumerator HideButtonAfter(int time)
    {
        yield return new WaitForSeconds(time);

        var coverButton = transform.parent.parent.GetChild(1).gameObject;
        coverButton.SetActive(false);
    }
}