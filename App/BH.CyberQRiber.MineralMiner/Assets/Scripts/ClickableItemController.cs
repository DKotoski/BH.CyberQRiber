using System;
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


    void Start()
    {
        Slider = GetComponent<Slider>();
        RefreshTime = new TimeSpan(RefreshTimeSeconds*10000000);
        Click();
        Slider.value = SliderValue();

    }

    void Update()
    {
        Slider.value = SliderValue();
    }

    float SliderValue()
    {


        if (LastClicked != null && PlannedRefresh != null)
        { 
            var res = (PlannedRefresh.Ticks - DateTime.Now.Ticks)/ (float)RefreshTime.Ticks;
            if (res < 0) return 0;
            return res;
        }
        return 0;
    }

    public void Click()
    {
        LastClicked = DateTime.Now;
        PlannedRefresh = LastClicked + RefreshTime;
    }
}
