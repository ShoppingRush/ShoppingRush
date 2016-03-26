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

    private GameObject _player;

    private Camera _mainCamera;

    // Use this for initialization
    void Start ()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        _people = new List<GameObject>();
        for (int i = 0; i <100; i++)
        {
            GameObject person = Instantiate(PersonPrefab);
            person.transform.position = new Vector3(Random.Range(-13, 13) , 0.5f, Random.Range(-13, 13));
            _people.Add(person);
        }
    }

    /*void Update()
    {
        foreach(GameObject person in _people)
        {
            RaycastHit hit;
            Physics.Linecast(_player.transform.position, person.transform.position, out hit);
            bool enabled = person.transform.Equals(hit.transform);
                person.GetComponent<NavMeshAgent>().enabled = enabled;
                person.GetComponent<Animator>().enabled = enabled;
                person.GetComponent<AICharacterControl>().enabled = enabled;
                person.GetComponent<ThirdPersonCharacter>().enabled = enabled;
            person.GetComponent<Patrol>().enabled = enabled;
            //bool enabled = Vector3.Distance(person.transform.position, _player.transform.position) < 10;
        }
    }*/
}
