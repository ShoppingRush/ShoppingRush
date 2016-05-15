using UnityEngine;
using System.Collections;
using System.Linq;
using Assets.Scripts;
using UnityEngine.SceneManagement;

public class InitializeMap : MonoBehaviour
{
    public GameObject[] Items;

    // Use this for initialization
    void Start()
    {
        SelectLevelMenu.CurrentLevel = SceneManager.GetActiveScene().name;

        var items = JsonUtility.FromJson<Items>(System.IO.File.ReadAllText("Assets/Config/items.json")).ItemsData;
        var colors = items.Select(item => ParseColor(item.Color)).ToList();
        var random = new System.Random();
        foreach (var shelf in GameObject.FindGameObjectsWithTag("Shelf"))
        {
            //for (int j = 0; j < 2; j++)
//            {
                for (int i = 0; i < 41; i++)
                {
                    for (var z = 0; z < 4; z++)
                    {
                        for (var side = -1; side < 2; side+=2)
                        {
                            var itemNumber = random.Next(items.Count);
                            GameObject item = Instantiate(Items[itemNumber]);
                            item.transform.parent = shelf.transform;
                            item.GetComponent<ShopItem>().ShopItemData = items[itemNumber];
                            item.GetComponent<MeshRenderer>().material.color = colors[itemNumber];

                            // 15,67 x 1,75
                            // z = 0,15
                            // z = 0.675
                            // z = 1.2
                            // z = 1.725

                            // pierwszy  0,075875 + (0.25 + 0.14175) * 19 + 0.25/2 =  7.644125
                            // ostatni - 0,075875 - (0.25 + 0.14175) * 19 - 0.25/2 = -7.644125

                            // f(0)  = -7.644125
                            // f(40) =  7.644125

                            // y = ax + b
                            // b = -7.644125
                            // y = ax - 7.644125
                            // a =  0.382206

                            item.transform.localPosition = new Vector3(0.382206f*i - 7.644125f, (2f - 0.25f/2 - 0.1f) * -side,
                                0.15f + 0.525f*z + 0.35f/2);
                        }
                    }
                }
//            }
        }
    }

    private static Color ParseColor(string col) {
         //Takes strings formatted with numbers and no spaces before or after the commas:
         var strings = col.Split(',');
         Color color = new Color();
         for (var i = 0; i < 4; i++) {
            color[i] = float.Parse(strings[i]);
         }
         return color;
     }
}
