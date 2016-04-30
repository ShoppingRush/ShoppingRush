using System;
using UnityEngine;
using System.Collections.Generic;
using Assets.Scripts;
using System.Linq;
using Random = UnityEngine.Random;
using UnityStandardAssets.Characters.ThirdPerson;

public class InitializeCrowd : MonoBehaviour
{
    public GameObject PersonPrefab;

    private List<GameObject> _people;

    // Use this for initialization
    void Start ()
    {
        _people = new List<GameObject>();
        for (int i = 0; i <100; i++)
        {
            GameObject person = Instantiate(PersonPrefab);
            person.transform.position = new Vector3(Random.Range(-13, 13) , 0f, Random.Range(-13, 13));
            _people.Add(person);
        }
    }
}
