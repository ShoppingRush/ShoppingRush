using System;
using UnityEngine;
using System.Collections.Generic;
using Assets.Scripts;
using System.Linq;
using Random = UnityEngine.Random;

public class InitializeCrowd : MonoBehaviour
{

    public GameObject PersonPrefab;

    public GameObject Box;

    // Use this for initialization
    void Start ()
    {
        List<GameObject> shelfes = new List<GameObject>(GameObject.FindGameObjectsWithTag("Shelf"));
        for (int z = -2; z < 2; z++)
        {
            for (int x = -2; x < 2; x++)
            {
                GameObject person = Instantiate(PersonPrefab);
                person.transform.position = new Vector3(x , 0.5f, z);
                Patrol patrol = person.GetComponent<Patrol>();
                patrol.Points = getRoute(shelfes);
            }
        }
    }

    private List<Transform> getRoute(List<GameObject> shelfes)
    {
        return shelfes.OrderBy(arg => Guid.NewGuid()).Take(10).Select(arg => arg.transform).ToList();
    }
}
