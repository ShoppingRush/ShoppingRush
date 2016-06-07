using UnityEngine;
using System.Collections;
using System.IO;
using System.Linq;
using Assets.Scripts;
using UnityEngine.SceneManagement;

public class InitializeMap : MonoBehaviour
{
    public GameObject Map;

    public GameObject[] Items;

    public GameObject[] VegetableStallGroups;



    // Use this for initialization
    void Start()
    {
        SelectLevelMenu.CurrentLevel = SceneManager.GetActiveScene().name;

        //var prefabs = Directory.GetFiles("Assets\\Prefabs\\Items", "*.prefab", SearchOption.AllDirectories);


        var random = new System.Random();
        var freezers = GameObject.FindGameObjectsWithTag(Tags.Freezer.ToString());
        var vegetableStalls = GameObject.FindGameObjectsWithTag(Tags.VegetableStall.ToString());
        var hangers = GameObject.FindGameObjectsWithTag(Tags.Hanger.ToString());
        var hangersLarge = GameObject.FindGameObjectsWithTag(Tags.HangerLarge.ToString());
        var shelfs = GameObject.FindGameObjectsWithTag(Tags.Shelf.ToString());
        var shelfsLarge = GameObject.FindGameObjectsWithTag(Tags.ShelfLarge.ToString());
        var refrigerators = GameObject.FindGameObjectsWithTag(Tags.Refrigerator.ToString());
        foreach (var vegetableStall in vegetableStalls)
        {
            foreach (var x in new float[] {2.175f, 0.725f, -2.175f, -0.725f})
            {
                var itemNumber = random.Next(VegetableStallGroups.Length);
                GameObject item = Instantiate(VegetableStallGroups[itemNumber]);
                item.transform.parent = vegetableStall.transform;
                item.transform.localPosition = new Vector3(x, -0.5f, 0.6f);
                item.transform.localRotation = new Quaternion(0,0,0,0);
            }
        }
        foreach (var shelf in GameObject.FindGameObjectsWithTag("Freezer"))
        {
            for (var i = 0; i < 41; i++)
            {
                for (var z = 0; z < 4; z++)
                {
                    for (var side = -1; side < 2; side+=2)
                    {
                        var itemNumber = random.Next(Items.Length);
                        GameObject item = Instantiate(Items[itemNumber]);
                        item.transform.parent = shelf.transform;

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
