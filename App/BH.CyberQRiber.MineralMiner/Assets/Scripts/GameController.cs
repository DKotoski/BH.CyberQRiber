using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private List<Item> itemPool;
    public List<ClickableItemController> clickables;

    public GameObject ClickablePrefab;
    public GameObject canvas;

    public List<Sprite> spriteDictionary;

    public GameController()
    {
        itemPool = new List<Item>();
        ItemPoolGenerator.Sprites = spriteDictionary;
        GenerateStage();
        RefreshItemPool();
    }

    // Use this for initialization
    private void Start()
    {
        ItemPoolGenerator.Sprites = spriteDictionary;
        GenerateStage();
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
        itemPool.AddRange(ItemPoolGenerator.Generate().OrderBy(x => GUID.Generate()).ToList());

        foreach (var clickable in clickables)
        {
            clickable.Item = itemPool.First();
            clickable.itemPool = itemPool;
            itemPool.RemoveAt(0);
        }
    }

    private void GenerateStage()
    {
        var offset = 100;
        for (var y = 0; y < 4; y++)

        {
            for (var x = 0; x < 4; x++)

            {
                var cube = Instantiate(ClickablePrefab, new Vector3(150 + x * offset, 50 + y * offset, 0), Quaternion.identity);
                cube.transform.parent = canvas.transform;
                cube.transform.Rotate(0, 0, 90);
                clickables.Add(cube.GetComponent<ClickableItemController>());
            }
        }
    }
}