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
            var position  = Patrol.RandomNavSphere(new Vector3(1, 0.5f, 17.5f), 50, 1);
            person.transform.position = position;
            _people.Add(person);
        }
    }
}
