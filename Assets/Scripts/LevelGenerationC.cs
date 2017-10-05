using UnityEngine;
using System.Collections;

public class LevelGenerationC : MonoBehaviour
{
    public GameObject GrassPlatform;
    public GameObject DirtPlatform;
    public GameObject StonePlatform;

    public int width;
    public float height;
    public int heightIncrease;
    public float smooth;

    public GameObject QuadCoal;
    public GameObject QuadFood;
    public GameObject QuadGold;
    public GameObject QuadCraft;

    public float coalRandom;
    public float foodRandom;
    public float goldRandom;
    public float craftRandom;

    [HideInInspector]
    public float seed;
    // Use this for initialization
    void Start()
    {
        Generation();
        //seed = Random.Range(-10000f, 10000f);
    }

    // Update is called once per frame
    void Generation()
    {
        for (int i = 0; i < width; i++)
        {
            int h = Mathf.RoundToInt(Mathf.PerlinNoise(seed, (i + transform.position.x) / smooth) * height) + heightIncrease;

            for (int j = 0; j < h; j++)
            {
                GameObject tileSelected;
                if (j < h - 4)
                {
                    tileSelected = StonePlatform;
                }
                else if (j < h - 1)
                {
                    tileSelected = DirtPlatform;
                }
                else
                {
                    tileSelected = GrassPlatform;
                }
                //Part 1 Instantiate(tileSelected, new Vector3(i, j), Quaternion.identity);
                GameObject newPLatform = Instantiate(tileSelected, Vector3.zero, Quaternion.identity) as GameObject;
                newPLatform.transform.parent = this.gameObject.transform;
                newPLatform.transform.localPosition = new Vector3(i, j);
            }
        }
        Population();
        PopulationDirt();
    }
    public void Population()
    {
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("stone"))
            if (g.transform.parent == this.gameObject.transform)
            {
                {
                    float r = Random.Range(0f, 100f);
                    GameObject selectedTile = null;
                    if (r < goldRandom)
                    {
                        selectedTile = QuadGold;
                    }
                    else if (r < foodRandom)
                    {
                        selectedTile = QuadFood;
                    }
                   
                    if (selectedTile != null)
                    {
                        GameObject newSourceTile = Instantiate(selectedTile, g.transform.position, Quaternion.identity) as GameObject;
                        //newSourceTile.transform.parent = transform;
                        Destroy(g);
                    }
                }
            }
    }

    public void PopulationDirt()
    { 
    foreach (GameObject d in GameObject.FindGameObjectsWithTag("Dirt"))
            if (d.transform.parent == this.gameObject.transform)
            {
                {
                    float f = Random.Range(0f, 100f);
                    GameObject selectedTile = null;
                   
                    if (f < craftRandom)
                    {
                        selectedTile = QuadCraft;
                    }

                    else if (f < coalRandom)
                    {
                        selectedTile = QuadCoal;
                    }




                    if (selectedTile != null)
                    {
                        GameObject newSourceTile = Instantiate(selectedTile, d.transform.position, Quaternion.identity) as GameObject;
                        //newSourceTile.transform.parent = transform;
                        Destroy(d);
                    }
                }
            }
    }
    }



