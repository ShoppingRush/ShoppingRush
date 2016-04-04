using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class InitializeMap : MonoBehaviour
{
    public GameObject ShelfPrefab;

    public GameObject ItemPrefab;

    // Use this for initialization
    void Start()
    {
        var items = JsonUtility.FromJson<Items>(System.IO.File.ReadAllText("Assets/Config/items.json")).ItemsData;
        var number = 0;
        foreach (Transform child in gameObject.transform)
        {
            for (int i = 0; i < 10; i++)
            {
                GameObject item = Instantiate(ItemPrefab);
                item.transform.parent = child;
                item.GetComponent<ShopItem>().ShopItemData = items[number%items.Count];
                item.GetComponent<MeshRenderer>().material.color = ParseColor(items[number % items.Count].Color);
                item.transform.localPosition = new Vector3(0.1f * i - 0.5f, 0.2f, 0.6f);
            }
            number ++;
        }
    }

    private static Color ParseColor(string col) {
         //Takes strings formatted with numbers and no spaces before or after the commas:
         var strings = col.Split(',');
         Color color = new Color();
         for (var i = 0; i < 4; i++) {
            color[i] = System.Single.Parse(strings[i]);
         }
         return color;
     }
}
