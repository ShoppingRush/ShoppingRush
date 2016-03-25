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
        for (int z = -50; z < 50; z++)
        {
            for (int x = -2; x < 2; x++)
            {
                GameObject person = Instantiate(PersonPrefab);
                person.transform.position = new Vector3(x , 0.5f, z);
            }
        }
    }
}
