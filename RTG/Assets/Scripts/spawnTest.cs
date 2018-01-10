using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Text;

public class spawnTest : MonoBehaviour {

    GameObject straightTrackPieceObject;
    GameObject startTrack;
    GameObject uBendPiece;
    Vector3 currentTrackPosition;
    OrderedDictionary markovTrackPieces = new OrderedDictionary();
   // int dictionarySize = 600;
    List<string> listOfPieces = new List<string>();

    int currentCount;

    int STST = 0;
    int STCR = 0;

    Dictionary<string, string> markovTrackDict= new Dictionary<string, string>();

    string actualInputTest = @"C:\CTPRaceTrack\RTG\Assets\Resources\trackRead.txt";

    private int counter = 1;
    private string stTrackString = "straightTrackPiece";
    private string uTrackString = "uBendTest";
    //private string currentTrackToSpawn;

   //private int maxWordLength = 600; // actually max words value from text file, implement later

    // Use this for initialization
    void Start () {
        spawnTrackFromString();
        
        spawnNextPiece();

    }

    
//     public void ReadIt()
//{
//    // Open the file into a streamreader
//    using (System.IO.StreamReader sr = new System.IO.StreamReader("text_path_here.txt"))
//    {
//        while (!sr.EndOfStream) // Keep reading until we get to the end
//        {
//            string splitMe = sr.ReadLine();
//            string[] bananaSplits = splitMe.Split(new char[] { ',' }); //Split at the commas

//            //if (bananaSplits.Length < 2) // If we get less than 2 results, discard them
//             //   continue; 
//             if (bananaSplits.Length == 2) // Easy part. If there are 2 results, add them to the dictionary
//                allTheThings.Add(bananaSplits[0].Trim(), bananaSplits[1].Trim());
//            else if (bananaSplits.Length > 2)
//                SplitItGood(splitMe, allTheThings); // Hard part. If there are more than 2 results, use the method below.
//        }
//    }
//}

public void SplitItGood(string actualInputTest, Dictionary<string, string> markovTrackDict)
{
    StringBuilder sb = new StringBuilder();
    List<string> trackHold = new List<string>(); // This list will hold the keys and values as we find them
    bool hasFirstValue = false;

    foreach (char c in actualInputTest) // Iterate through each character in the input
    {
        if (c != ',') // Keep building the string until we reach a comma
            sb.Append(c);
        else if (c == ',' && !hasFirstValue)
        {
            trackHold.Add(sb.ToString().Trim());
                sb.Length = (0);
            hasFirstValue = true;
        }
        else if (c == ',' && hasFirstValue)
        {

            // Below, the StringBuilder currently has something like this:
            // "    235235         Some Text Here"
            // We trim the leading whitespace, then split at the first sign of a double space
            string[] bananaSplit = sb.ToString()
                                     .Trim()
                                     .Split(new string[] { "  " },
                                            StringSplitOptions.RemoveEmptyEntries);

                // Add both results to the list
                
                trackHold.Add(bananaSplit[0].Trim());
                trackHold.Add(bananaSplit[1].Trim());
                sb.Length = (0);
            }                    
    }

        trackHold.Add(sb.ToString().Trim()); // Add the last result to the list

        for (int i = 0; i < trackHold.Count; i += 2)
        {
        // This for loop assumes that the amount of keys and values added together
        // is an even number. If it comes out odd, then one of the lines on the input
        // text file wasn't parsed correctly or wasn't generated correctly.
        if (markovTrackDict.TryGetValue(actualInputTest, out currentCount))
            {
                markovTrackDict[actualInputTest] = currentCount + 1;
            //https://stackoverflow.com/questions/7132738/incrementing-a-numerical-value-in-a-dictionary
            
            }
                else
                 {
                    markovTrackDict.Add(trackHold[i], trackHold[i + 1]); 
                 }
        }
    }

    public void racetrackDictionary()
    {
        for (int i = 0; i < 50; i++)
        {
            // if (markovTrackDict.ContainsKey(actualInputTest))
            // {
            if (markovTrackDict.TryGetValue(actualInputTest,out currentCount))
        {
                markovTrackDict[actualInputTest] = currentCount + 1;
                //https://stackoverflow.com/questions/7132738/incrementing-a-numerical-value-in-a-dictionary
                // markovTrackDict[i++],actualInputTest
            }


           // else
           // {
             //   markovTrackDict.Add(actualInputTest, currentCount);
             //       }


            //if (markovTrackDict[i]
            //markovTrackDict(KeyValuePair <[i][++] >);
            //markovTrackDict(key[i], value++);
            //}
        }

       
    } 


 public void DisplayContents(ICollection keyCollection, ICollection valueCollection,int dictionarySize)
    {

        String[] myKeys = new String[dictionarySize];
        String[] myValues = new String[dictionarySize];
        keyCollection.CopyTo(myKeys, 0);
        valueCollection.CopyTo(myValues, 0);

        // Displays the contents of the OrderedDictionary
           for (int i = 0; i < maxWordLength; i++)
        {
            listOfPieces[i] = myValues[i];
        }

           

        
    }


    public void addTrackPiecesToDict()
    {

        ICollection keyCollection = markovTrackPieces.Keys;
        ICollection valueCollection = markovTrackPieces.Values;

        // increment each variable for how many times it's found in list
        //

        for (int i = 0; i < maxWordLength; i ++)
        {
            if (listOfPieces[i] == "ST" && listOfPieces[i+1] == "ST")
            {
                STST++;
            }
            if (listOfPieces[i] == "ST" && listOfPieces[i + 1] == "CR")
            {
                STCR++;
            }

        }
       
    }

    public void calculateTrackProbability()
    {
        // For each variable track piece e.g. STST, add up how many
        // time each variation for STST, STCR etc occurs, then divide
        // by each track varation to get percentage for each track varation probability
        // STST+STCR.. + STRT = STSUM
        // STST/STSUM = STP     STCR/STSUM = STCRP
        // Then, based on this probability, (let's plug in semi-random numbers for testing purposes)
        // Calculate what track piece will come next and spawn
    }

    public void spawnBasedOnProbability()
    {
        // Use probability selecter, if piece is STST, instantiate ST
        // if STCR, instantiate CR
    }

    public void spawnTrackFromString()
    {
       // GameObject straightTrackPieceObject = (GameObject)Instantiate(Resources.Load(stTrackString));
        currentTrackPosition = new Vector3(0,0,0);

        straightTrackPieceObject = Resources.Load(stTrackString) as GameObject;
       Instantiate(straightTrackPieceObject, currentTrackPosition, Quaternion.identity);
        currentTrackPosition.y += 1;

    }

    public void spawnNextPiece()
    {
        //GameObject uBendPiece = (GameObject)Instantiate(Resources.Load(uTrackString));
        // Check orientation - will piece be added starting left side or right side?

        // If (currentTrackToSpawn == uBend)
        // 

        uBendPiece = Resources.Load(uTrackString) as GameObject;

        Instantiate(uBendPiece, currentTrackPosition, Quaternion.identity);
        currentTrackPosition.x += 10;
    }


    // Update is called once per frame
    void Update () {
		
	}
}
