using UnityEngine;
using System.Collections;

public class GenerateShelfes : MonoBehaviour
{


    public GameObject ShelfPrefab;

    public GameObject MilkPrefab;

    // Use this for initialization
    void Start()
    {
        for (int z = -7; z < 7; z++)
        {
            for (int x = -9; x <= -2; x++)
            {
                //GameObject shelf = Instantiate(ShelfPrefab);
                //shelf.transform.position = new Vector3(3 * x, 0, 5 * z + 2.5f);
                GameObject milk = Instantiate(MilkPrefab);
                milk.transform.position = new Vector3(3 * x, 1.5f, 5 * z + 2.5f);
                //milk.transform.parent = shelf.transform;
            }
            for (int x = 2; x <= 9; x++)
            {
                //GameObject shelf = Instantiate(ShelfPrefab);
                //shelf.transform.position = new Vector3(3 * x, 0, 5 * z + 2.5f);
                GameObject milk = Instantiate(MilkPrefab);
                milk.transform.position = new Vector3(3 * x, 1.5f, 5 * z + 2.5f);
                //milk.transform.parent = shelf.transform;
            }
        }
    }
}
