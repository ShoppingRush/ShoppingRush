using UnityEngine;
using System.Collections;

public class InitializeMap : MonoBehaviour
{
    public GameObject ShelfPrefab;

    public GameObject MilkPrefab;

    // Use this for initialization
    void Start()
    {
        foreach(Transform child in gameObject.transform)
        {
            for (int i = 0; i < 10; i++)
            {
                GameObject milk = Instantiate(MilkPrefab);
                milk.transform.parent = child;
                milk.transform.localPosition = new Vector3(0.1f * i - 0.5f, 0.2f, 0.6f);
            }
        }
    }
}
