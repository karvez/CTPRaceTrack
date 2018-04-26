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

    // Creating a 2D-Array of "tiles" for base as Perlin Noise algorithm

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
  
	}

    // Code below adapted from Nintendo Examiner
    // https://github.com/NintendoExaminer/Procedural-Terrain-Generation-Tutorial

    public void tileCreate()
    {
        
        for (int i = 0; i < 50; i++)
        {
           for (int j = 0; j < 50; j++)
            {
              
                // An array of gameobjects is initallity set, then each of those
                // gameobject's position is changed depending on the values
                // gathered from the perlinNoise function
                // in order to create the desired style of terrain

                perlinTileSpawn[i, j] = perlinTileSpawnObject;
                currentPerlinCubePositon = perlinTileSpawn[i, j].transform.position;

                float value = Mathf.PerlinNoise(i / (float)width * 2f, j / (float)height * 2f);

                if (value > 0.5000001f && value < 0.599999f)
                {

                    currentPerlinCubePositon.z = 0.1f;
                    Instantiate(perlinTileSpawn[i, j], currentPerlinCubePositon, Quaternion.identity);
                    perlinTileSpawn[i, j].GetComponent<Renderer>().material = redMaterial;

                }

                else if (value > 0.600001f && value < 0.699999f)
                {
                   
                    currentPerlinCubePositon.z = 0.2f;
                    Instantiate(perlinTileSpawn[i, j], currentPerlinCubePositon, Quaternion.identity);        
                    perlinTileSpawn[i, j].GetComponent<Renderer>().material = greenMaterial;

                }

                else if (value > 0.700001f && value < 0.799999f)
                {
                    
                    currentPerlinCubePositon.z = 0.3f;
                    Instantiate(perlinTileSpawn[i, j], currentPerlinCubePositon, Quaternion.identity);
                    perlinTileSpawn[i, j].GetComponent<Renderer>().material = blueMaterial;
                }

                else if (value > 0.800001f && value < 0.899999f)
                {
                   
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
                               
                    currentPerlinCubePositon.z = 0;
                    Instantiate(perlinTileSpawn[i, j], currentPerlinCubePositon, Quaternion.identity);
                    perlinTileSpawn[i, j].GetComponent<Renderer>().material = blackMaterial;
                }

                else if (value > 0.300001 && value < 0.399999f)
                {
                    
                    currentPerlinCubePositon.z = 0;
                    Instantiate(perlinTileSpawn[i, j], currentPerlinCubePositon, Quaternion.identity);
                    perlinTileSpawn[i, j].GetComponent<Renderer>().material = tealMaterial;
                }

                else if (value > 0.200001 && value < 0.299999f)
                {
                    
                    currentPerlinCubePositon.z = 0;
                    Instantiate(perlinTileSpawn[i, j], currentPerlinCubePositon, Quaternion.identity);
                    perlinTileSpawn[i, j].GetComponent<Renderer>().material = pinkMaterial;
                }

                else if (value < 0.199999f)
                {
                    
                    currentPerlinCubePositon.z = 0;
                    Instantiate(perlinTileSpawn[i, j], currentPerlinCubePositon, Quaternion.identity);
                    perlinTileSpawn[i, j].GetComponent<Renderer>().material = purpleMaterial;
                }

                // Increment the x value by the width of the cube being spawned
                
                currentPerlinCubePositon.x = currentPerlinCubePositon.x + 0.1f;
                perlinTileSpawn[i, j].transform.position = currentPerlinCubePositon;
                Debug.Log("Y SPAWN");
            }

            // After a row (50 cubes) have been spawned, then decrement the y value
            // by the height of a cube, in order to make sure the terrrain spawns
            // in a square shape.
            currentPerlinCubePositon.x = -3;
            currentPerlinCubePositon.y = currentPerlinCubePositon.y - 0.1f;
            for (int k = 0; k < 50; k++)
            {            
                perlinTileSpawn[i, k].transform.position = currentPerlinCubePositon;
            }
     
        }
        

    }

    // Update is called once per frame
    void Update () {
		
	}
}
