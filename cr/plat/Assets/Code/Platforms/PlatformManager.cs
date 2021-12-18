using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public List<GameObject> tilesColliding = new List<GameObject>();
    [SerializeField] private GameObject[] tiles;
    // Start is called before the first frame update
    public List<Vector3> GetTilesPositions()
    {
        tiles = GameObject.FindGameObjectsWithTag("Platforms");
        List<Vector3> positions = new List<Vector3>();
 
        foreach (GameObject tile in tiles)
        {
            if (this.tilesColliding.Contains(tile))
            {
                positions.Add(tile.transform.position);
            }
        }
 
        return positions;
    }
    void Start()
    {
        GetTilesPositions();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
