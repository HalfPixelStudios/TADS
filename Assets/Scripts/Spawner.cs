using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WayPoint))]
public class Spawner : MonoBehaviour
{

    public static int pedestrianCount = 0;
    public GameObject prefab;
    public float spawnInterval;
    public Transform parent;

    WayPoint waypoint;

    // Start is called before the first frame update
    void Start()
    {
        waypoint = GetComponent<WayPoint>();
        StartCoroutine(Spawn());




    }

    IEnumerator Spawn(){

        if (pedestrianCount > 100) { yield return null; }
        while (true)
        {
            GameObject g = Instantiate(prefab, transform.position, Quaternion.identity, parent);
            PedestrianController pc = g.GetComponent<PedestrianController>();
            pc.speed = 0.5f + Random.Range(0f,0.5f);

            pedestrianCount += 1;
            float rnd = Random.Range(0f,1f);

            if (rnd > 0.5f) {
                g.GetComponent<PathAI>().node = waypoint.connections[0];
                g.GetComponent<PathAI>().prevNode = waypoint;
            } else {
                g.GetComponent<PathAI>().node = waypoint.connections[1];
                g.GetComponent<PathAI>().prevNode = waypoint;
            }


            yield return new WaitForSeconds(5);

        }
    }

}
