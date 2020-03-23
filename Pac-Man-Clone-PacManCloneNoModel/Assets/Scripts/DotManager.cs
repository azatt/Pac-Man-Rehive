using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class DotManager : MonoBehaviour
{
    public GameObject Dotprefab;
    public List<Options> options = new List<Options>();

    void Start()
    {
        MakeMap();
    }

    void Update()
    {
        
    }

    // Check every tile (from (2, 2) to (28, 31)) of the maze and add it to the List<Vector2>options if location is "valid".
    // Afterwards, place 1 dot in every valid location.
    void MakeMap() 
    {
        for (int j = 2; j < 31; j++)
        {
            for (int i = 2; i < 28; i++)
            {
                if (j > 11 && j < 23 && i != 22 && i != 7) // avoid middle part of the mace (ghosthouse and TP)
                {
                    continue;
                }

                if ((j == 28 || j == 8) && (i == 27 || i == 2)) //avoid power pellets
                {
                    continue;
                }

                else if (PosEmpty(i, j)) // avoid walls
                {
                    options.Add(new Options(i, j));
                }
            }
        }
        foreach (var option in options)
        {
            Vector3 pos = new Vector3(option.x, option.y, 0);
            Instantiate(Dotprefab, pos, Quaternion.identity);
        }
    }

    bool PosEmpty(int x, int y)
    {
        Vector2 pos = new Vector2(x, y);
        Collider2D[] collider = Physics2D.OverlapCircleAll(pos, 0f);
        if (collider.Length > 0)
        {
            return false;
        }

        return true;
    }

    public class Options
    {
        public int x { get; set; }
        public int y { get; set; }

        public Options(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
