using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class WallDestroyer : MonoBehaviour
{
    public Tilemap tilemap;

    public Tile unbreakableWall;
    public Tile wall;
    public PlayerMovement player;
    //public int explosionLength;

    public GameObject middleExplosion;
    public GameObject verticalExplosion;
    public GameObject horizontalExplosion;
    public GameObject topEndExplosion;
    public GameObject bottomEndExplosion;
    public GameObject rightEndExplosion;
    public GameObject leftEndExplosion;
    public GameObject wallBreak;

    public int explosionLength = 1;
    


    public void Explode(Vector2 worldPos)
    {
        Vector3Int originCell = tilemap.WorldToCell(worldPos);

        ExplodeCell(originCell, middleExplosion);

        bool continueTop = true;
        bool continueBottom = true;
        bool continueRight = true;
        bool continueLeft = true;

        for (int i = 1; i < explosionLength; i++)
        {
            if (continueTop)
                continueTop = ExplodeCell(originCell + new Vector3Int(0, i, 0), verticalExplosion);

            if (continueBottom)
                continueBottom = ExplodeCell(originCell + new Vector3Int(0, -i, 0), verticalExplosion);

            if (continueLeft)
                continueLeft = ExplodeCell(originCell + new Vector3Int(-i, 0, 0), horizontalExplosion);

            if (continueRight)
                continueRight = ExplodeCell(originCell + new Vector3Int(i, 0, 0), horizontalExplosion);
        }
        

        if (continueTop)
            ExplodeCell(originCell + new Vector3Int(0, explosionLength, 0), topEndExplosion);

        if (continueBottom)
            ExplodeCell(originCell + new Vector3Int(0, -explosionLength, 0), bottomEndExplosion);

        if (continueLeft)
            ExplodeCell(originCell + new Vector3Int(-explosionLength, 0, 0), leftEndExplosion);

        if (continueRight)
            ExplodeCell(originCell + new Vector3Int(explosionLength, 0, 0), rightEndExplosion);

    }

    bool ExplodeCell(Vector3Int cell, GameObject animation)
    {
        Tile tile = tilemap.GetTile<Tile>(cell);
        
        if(player.GetCell() == cell)
        {
            Debug.Log("Player has been hit!");
        }

        if (tile == unbreakableWall)
        {
            return false;
        }

        Vector3 pos = tilemap.GetCellCenterWorld(cell);

        if (tile == wall)
        {
            tilemap.SetTile(cell, null);
            Instantiate(wallBreak, pos, Quaternion.identity);
            return false;
        }

        // Create an explosion
        Instantiate(animation, pos, Quaternion.identity);

        return true;
    }

}
