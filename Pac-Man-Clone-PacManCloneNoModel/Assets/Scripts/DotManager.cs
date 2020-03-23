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

    void MakeMap()
    {
        for (int i = 2; i < 28; i++)
        {
            for (int j = 2; j < 31; j++)
            {
                if (PosEmpty(i, j))
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
