using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;
using System;

public class spawnTrack : MonoBehaviour {

    //public GameObject trackPiece;
    GameObject squareTrackSpawn;
    GameObject straightTrack;
    Vector3 currentTrackPosition;
    public int counter = 1;
    //bool isIdentical = true;

    private bool Load(string trackRead)
    {
        
        // Handle any problems that might arise when reading the text
        try
        {
            //string[] trackStore;
            string line;
            // Create a new StreamReader, tell it which file to read and what encoding the file
            // was saved as

            //string text = System.IO.File.ReadAllText("trackRead.txt");
            StreamReader theReader = new StreamReader(trackRead, Encoding.Default);
            // Immediately clean up the reader after this block of code is done.
            // You generally use the "using" statement for potentially memory-intensive objects
            // instead of relying on garbage collection.
            // (Do not confuse this with the using directive for namespace at the 
            // beginning of a class!)
            using (theReader)
            {
                // While there's lines left in the text file, do this:
                do
                {
                    line = theReader.ReadLine();

                    if (line != null)
                    {
                        // Do whatever you need to do with the text line, it's a string now
                        // In this example, I split it into arguments based on comma
                        // deliniators, then send that array to DoStuff()
                        string[] entries = line.Split(',');
                        if (entries.Length > 0)
                            //for (int i = 0; i < 4; i++)
                            //{
                                spawnTrackFromString(entries[1]);
                           // }
                    }
                }
                while (line != null);
                // Done reading, close the reader and return true to broadcast success    
                theReader.Close();
                return true;
            }
        }
        // If anything broke in the try block, we throw an exception with information
        // on what didn't work
        catch (Exception e)
        {
            Console.WriteLine("{0}\n", e.Message);
            return false;
        }
    }


// Use this for initialization
void Start () {
 
        
    }
	
    public void spawnTrackFromString(string trackPiece)
    {
        GameObject squareTrackSpawn = (GameObject)Instantiate(Resources.Load(trackPiece));
        currentTrackPosition = squareTrackSpawn.transform.position;
        currentTrackPosition.x += 1;
        currentTrackPosition.y += 1;
        currentTrackPosition.z += 1;
        straightTrack = Resources.Load(trackPiece) as GameObject;
        // Instantiate("straightTrack", squareTrackSpawn.transform.position, Quaternion.identity);

    }

    // Update is called once per frame
    void Update () {
        //spawnTrackFromString();
        //GameObject straightTrackSpawn = (GameObject)Instantiate(Resources.Load("straightTrack"));
        if (counter == 1)
        {
           // Instantiate(straightTrack, currentTrackPosition, Quaternion.identity);
            counter++;
        }

    }
}
