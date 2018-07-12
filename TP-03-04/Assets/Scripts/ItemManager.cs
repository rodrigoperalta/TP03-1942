using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager itemManager;
    private int chanceOnItem;
    public List<Transform> items = new List<Transform>();                                                               //Creates item list

    public static ItemManager Get()
    {
        return itemManager;
    }

    private void Awake()
    {
        itemManager = this;
    }

    public void DropRandomItem(Vector2 enemyLocation)
    {
        chanceOnItem = Random.Range(0, 8);                                                                             //Chance of item drop
        if (chanceOnItem == 5)
            Instantiate(items[Random.Range(0, items.Count)], enemyLocation, Quaternion.identity);                      //Decides which item to drop
    }
}
