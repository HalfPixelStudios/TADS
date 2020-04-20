using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public WayPoint node;
    public WayPoint prevNode;
    public float spawnInterval;
    public Transform parent;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
        



    }

    IEnumerator Spawn(){
        while (true)
        {
            GameObject g = Instantiate(prefab, transform.position, Quaternion.identity, parent);
            g.GetComponent<PathAI>().node = node;
            g.GetComponent<PathAI>().prevNode = prevNode;
            yield return new WaitForSeconds(5);
            
        }
    }
    
}
