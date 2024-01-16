using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject platformPrefab;
    public float xstartpos, xendpos, ystartpos, yendpos;
    
    // Start is called before the first frame update
    void Start()
    {
        Vector3 SpawnerPosition = new Vector3();
        for(int i = 0; i < 10; i++)
        {
            SpawnerPosition.x = Random.Range(xstartpos, xendpos);
            SpawnerPosition.y = Random.Range(ystartpos, yendpos);
            GameObject platformGO =  Instantiate(platformPrefab, SpawnerPosition, Quaternion.identity);
            Platform platform= platformGO.GetComponent<Platform>();
            platform.setPlatformSpawnParametrs(xstartpos, xendpos, ystartpos, yendpos);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
