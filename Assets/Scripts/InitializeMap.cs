using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Assets.Scripts;
using UnityEngine.SceneManagement;

public class InitializeMap : MonoBehaviour
{
    public GameObject Map;

    public GameObject[] ShelfGroups;

    public GameObject[] VegetableStallGroups;

    public ShopItemList ShopItemList;


    // Use this for initialization
    void Start()
    {
        var random = new System.Random();
        var shopItemDatas = new List<ShopItemData>();
        foreach (var shelfGroup in ShelfGroups)
        {
            shopItemDatas.Add(shelfGroup.GetComponentInChildren<ShopItemData>());
        }
        foreach (var shelfGroup in VegetableStallGroups)
        {
            shopItemDatas.Add(shelfGroup.GetComponentInChildren<ShopItemData>());
        }

        ShopItemList.ShopItemToCollect = shopItemDatas.Where(d => random.NextDouble() < 0.3).ToDictionary(data => data, data => random.Next(10));
        

        SelectLevelMenu.CurrentLevel = SceneManager.GetActiveScene().name;

        var vegetableStalls = GameObject.FindGameObjectsWithTag(Tags.VegetableStall.ToString());
        var shelfs = GameObject.FindGameObjectsWithTag(Tags.Shelf.ToString());
        var shelfsLarge = GameObject.FindGameObjectsWithTag(Tags.ShelfLarge.ToString());
        foreach (var vegetableStall in vegetableStalls)
        {
            foreach (var x in new[] {2.175f, 0.725f, -2.175f, -0.725f})
            {
                var itemNumber = random.Next(VegetableStallGroups.Length);
                GameObject item = Instantiate(VegetableStallGroups[itemNumber]);
                item.transform.parent = vegetableStall.transform;
                item.transform.localPosition = new Vector3(x, -0.5f, 0.6f);
                item.transform.localRotation = new Quaternion(0,0,0,0);
            }
        }

        foreach (var shelf in shelfs)
        {
            foreach (var x in new[] { 2.175f, 0.725f, -2.175f, -0.725f })
            {
                foreach (var z in new[] { 0.6875f, 1.225f, 1.7625f, 0.15f })
                {
                    var itemNumber = random.Next(ShelfGroups.Length);
                    GameObject item = Instantiate(ShelfGroups[itemNumber]);
                    item.transform.parent = shelf.transform;
                    item.transform.localPosition = new Vector3(x, -0.5f, z);
                    item.transform.localRotation = new Quaternion(0, 0, 0, 0);
                }
            }
        }
        foreach (var shelf in shelfsLarge)
        {
            foreach (var x in new[] { -3, -1.5f, 0, 1.5f, 3 })
            {
                foreach (var z in new[] { 0.6875f, 1.225f, 1.7625f, 0.15f })
                {
                    var itemNumber = random.Next(ShelfGroups.Length);
                    GameObject item = Instantiate(ShelfGroups[itemNumber]);
                    item.transform.parent = shelf.transform;
                    item.transform.localPosition = new Vector3(x, -0.5f, z);
                    item.transform.localRotation = new Quaternion(0, 0, 0, 0);
                }
            }
        }

    }
}
