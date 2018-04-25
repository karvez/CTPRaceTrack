using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class perlinHills : MonoBehaviour {

    public Material blueMaterial;
    public Material redMaterial;
    public Material greenMaterial;
    public Material blackMaterial;
    public Material whiteMat;
    public Material yellowMat;
    public Material tealMaterial;
    public Material purpleMaterial;
    public Material pinkMaterial;

    int width = 50;
    int height = 50;

    int[,] tileArray = new int[50, 50];
    GameObject[,] perlinTileSpawn = new GameObject[50, 50];

    GameObject perlinTileSpawnObject;
    Vector3 currentPerlinCubePositon = new Vector3(0, 0, 0);


    // Use this for initialization
    void Start () {

        perlinTileSpawnObject = Resources.Load("perlinTile") as GameObject;
        perlinTileSpawnObject.transform.position = new Vector3(-3, 3, 0);
        perlinTileSpawnObject.GetComponent<Renderer>().material = blackMaterial;
        tileCreate();
       // Renderer rend = GetComponent<Renderer>();
	}

    // Code below adapted from Nintendo Examiner
    // https://github.com/NintendoExaminer/Procedural-Terrain-Generation-Tutorial

    public void tileCreate()
    {
        
        for (int i = 0; i < 50; i++)
        {
           for (int j = 0; j < 50; j++)
            {
                // for first 

                
                perlinTileSpawn[i, j] = perlinTileSpawnObject;
                currentPerlinCubePositon = perlinTileSpawn[i, j].transform.position;

                float value = Mathf.PerlinNoise(i / (float)width * 2f, j / (float)height * 2f);

                if (value > 0.5000001f && value < 0.599999f)
                {
                    Debug.Log("VALUE BETWEEN 0.5 & 0.6");
                    currentPerlinCubePositon.z = 0.1f;

                    //Renderer rend = GetComponent<Renderer>();
                    //end.material.SetColor("_SpecColor", Color.red);
                    Instantiate(perlinTileSpawn[i, j], currentPerlinCubePositon, Quaternion.identity);
                    perlinTileSpawn[i, j].GetComponent<Renderer>().material = redMaterial;

                }

                else if (value > 0.600001f && value < 0.699999f)
                {
                    Debug.Log("VALUE > 0.6");
                    currentPerlinCubePositon.z = 0.2f;
                    Instantiate(perlinTileSpawn[i, j], currentPerlinCubePositon, Quaternion.identity);        
                    perlinTileSpawn[i, j].GetComponent<Renderer>().material = greenMaterial;

                }

                else if (value > 0.700001f && value < 0.799999f)
                {
                    Debug.Log("VALUE > 0.7");
                    currentPerlinCubePositon.z = 0.3f;
                    Instantiate(perlinTileSpawn[i, j], currentPerlinCubePositon, Quaternion.identity);
                    perlinTileSpawn[i, j].GetComponent<Renderer>().material = blueMaterial;
                }

                else if (value > 0.800001f && value < 0.899999f)
                {
                    Debug.Log("VALUE > 0.8");
                    currentPerlinCubePositon.z = 0.4f;
                    Instantiate(perlinTileSpawn[i, j], currentPerlinCubePositon, Quaternion.identity);
                    perlinTileSpawn[i, j].GetComponent<Renderer>().material = whiteMat;
                }

                else if (value > 0.900001f)
                {
                    currentPerlinCubePositon.z = 0.5f;
                    Instantiate(perlinTileSpawn[i, j], currentPerlinCubePositon, Quaternion.identity);
                    perlinTileSpawn[i, j].GetComponent<Renderer>().material = yellowMat;
                }

                else if ( value > 0.400001 && value < 0.499999f)
                {
                    Debug.Log("VALUE < 0.4");            
                    currentPerlinCubePositon.z = 0;
                    Instantiate(perlinTileSpawn[i, j], currentPerlinCubePositon, Quaternion.identity);
                    perlinTileSpawn[i, j].GetComponent<Renderer>().material = blackMaterial;
                }

                else if (value > 0.300001 && value < 0.399999f)
                {
                    Debug.Log("VALUE < 0.3");
                    currentPerlinCubePositon.z = 0;
                    Instantiate(perlinTileSpawn[i, j], currentPerlinCubePositon, Quaternion.identity);
                    perlinTileSpawn[i, j].GetComponent<Renderer>().material = tealMaterial;
                }

                else if (value > 0.200001 && value < 0.299999f)
                {
                    Debug.Log("VALUE < 0.2");
                    currentPerlinCubePositon.z = 0;
                    Instantiate(perlinTileSpawn[i, j], currentPerlinCubePositon, Quaternion.identity);
                    perlinTileSpawn[i, j].GetComponent<Renderer>().material = pinkMaterial;
                }

                else if (value < 0.199999f)
                {
                    Debug.Log("VALUE < 0.2");
                    currentPerlinCubePositon.z = 0;
                    Instantiate(perlinTileSpawn[i, j], currentPerlinCubePositon, Quaternion.identity);
                    perlinTileSpawn[i, j].GetComponent<Renderer>().material = purpleMaterial;
                }

                // 

                // If perlin noise value above 0.6, perlinTileSpawn[i, j]
                currentPerlinCubePositon.x = currentPerlinCubePositon.x + 0.1f;
                perlinTileSpawn[i, j].transform.position = currentPerlinCubePositon;
                Debug.Log("Y SPAWN");
            }

            currentPerlinCubePositon.x = -3;
            currentPerlinCubePositon.y = currentPerlinCubePositon.y - 0.1f;
            for (int k = 0; k < 50; k++)
            {
                //transform x position correctly
                perlinTileSpawn[i, k].transform.position = currentPerlinCubePositon;
            }

            //Instantiate(perlinTileSpawn[i, 0], currentPerlinCubePositon, Quaternion.identity);
            //Debug.Log("X SPAWN");
        }
        

    }

    // Update is called once per frame
    void Update () {
		
	}
}
