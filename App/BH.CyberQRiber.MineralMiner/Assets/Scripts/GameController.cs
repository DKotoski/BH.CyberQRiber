using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private List<Item> itemPool;
    public List<ClickableItemController> clickables;

    // Use this for initialization
    private void Start()
    {
        RefreshItemPool();
    }

    // Update is called once per frame
    private void Update()
    {
        if (itemPool.Count < clickables.Count)
        {
            RefreshItemPool();
        }
    }

    private void RefreshItemPool()
    {
        itemPool = ItemPoolGenerator.Generate().OrderBy(x => GUID.Generate()).ToList();

        foreach (var clickable in clickables)
        {
            clickable.Item = itemPool.First();
            itemPool.RemoveAt(0);
        }
    }
}