using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WallPlacer : MonoBehaviour
{
    public Tilemap tilemap;
    public Tile wall;
    // Update is called once per frame
    void Start()
    {
        BoundsInt bounds = tilemap.cellBounds;
        List<Vector2Int> spawnPoint = new List<Vector2Int>();
        spawnPoint.Add(new Vector2Int(bounds.xMin + 1, bounds.yMax - 2));
        spawnPoint.Add(new Vector2Int(bounds.xMin + 2, bounds.yMax - 2));
        spawnPoint.Add(new Vector2Int(bounds.xMin + 1, bounds.yMax - 3));

        for (int x = bounds.xMin; x < bounds.xMax; x++)
        {
            for (int y = bounds.yMin; y < bounds.yMax; y++)
            {
                Vector2Int temp = new Vector2Int(x, y);
                if (spawnPoint.Contains(temp))
                {
                    continue;
                }
                TileBase tile = tilemap.GetTile(new Vector3Int(x, y, 0));
                if (tile == null)
                {
                    if(Random.Range(0, 100) < 50)
                    {
                        tilemap.SetTile(new Vector3Int(x, y, 0), wall);
                    }
                }
            }
        }
    }
    void Update()
    {

    }
}
