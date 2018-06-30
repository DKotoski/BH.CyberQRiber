using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class ItemPoolGenerator
{
    private static int PoolGenerationTryouts = 100;
    private static Random rnd;

    static ItemPoolGenerator(){
        rnd = new Random();
}

    public static IEnumerable<Item> Generate()
    {
        var pool = new List<Item>();
        var poolStats = GetItemPoolStats();
        for(int i = 0; i < PoolGenerationTryouts; i++)
        {
            foreach(var stat in poolStats)
            {
                var roll = rnd.Next(100);
                if(roll< stat.DropChance && stat.DropChance != 0)
                {
                    pool.Add(new Item { TypeIdentifier = stat.TypeIdentifier });
                    if (stat.ItemPoolCount > 0)
                    {
                        stat.ItemPoolCount--;
                    }
                }
            }
        }

        return pool;
    }

    static IEnumerable<ItemPoolStat> GetItemPoolStats()
    {
        return new List<ItemPoolStat>
        {
            new ItemPoolStat
            {
                TypeIdentifier="1",
                DropChance=50,
                ItemPoolCount = -1
            },
            new ItemPoolStat
            {
                TypeIdentifier="2",
                DropChance=10,
                ItemPoolCount = -1
            },new ItemPoolStat
            {
                TypeIdentifier="3",
                DropChance=2,
                ItemPoolCount = -1
            },new ItemPoolStat
            {
                TypeIdentifier="4",
                DropChance=2,
                ItemPoolCount = 10
            }
            ,new ItemPoolStat
            {
                TypeIdentifier="5",
                DropChance=2,
                ItemPoolCount = 0
            }
        };
    }
}