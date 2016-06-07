using UnityEngine;
using System.Collections;
using System.IO;
using System.Linq;
using Assets.Scripts;
using UnityEngine.SceneManagement;

public class InitializeMap : MonoBehaviour
{
    public GameObject Map;

    public GameObject[] ShelfGroups;

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
