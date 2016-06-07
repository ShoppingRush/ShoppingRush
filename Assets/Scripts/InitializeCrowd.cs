using System;
using UnityEngine;
using System.Collections.Generic;
using Assets.Scripts;
using System.Linq;
using Random = UnityEngine.Random;
using UnityStandardAssets.Characters.ThirdPerson;

public class InitializeCrowd : MonoBehaviour
{
    public GameObject[] PeoplePrefab;

    public int PersonCount;


    // Use this for initialization
    void Start ()
    {
        var random = new System.Random();
        for (int i = 0; i < PersonCount; i++)
        {
            var personNumber = random.Next(PeoplePrefab.Length);
            GameObject person = Instantiate(PeoplePrefab[personNumber]);
            var position  = Patrol.RandomNavSphere(new Vector3(1, 0.5f, 17.5f), 50, 1);
            person.transform.position = position;
            person.transform.rotation = Quaternion.AngleAxis(random.Next(360), Vector3.up);
        }
    }
}
