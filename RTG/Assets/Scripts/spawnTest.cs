using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.IO;
using System.Text;
using Accord.Statistics;
using Accord.MachineLearning;
using Accord.Math;
using Accord.Statistics.Models.Markov;
using Accord.Statistics.Models.Markov.Learning;
using Accord.Statistics.Filters;
using Accord.Statistics.Models.Markov.Topology;

public class spawnTest : MonoBehaviour {

    GameObject straightTrackPieceObject;
    GameObject startTrack;
    GameObject nextTrackObjectToSpawn;
    UnityEngine.Vector3 currentTrackPosition;
    public Quaternion currentTrackRotation;

    OrderedDictionary markovTrackPieces = new OrderedDictionary();
  
    List<string> listOfPieces = new List<string>();

    int currentCount = 0;

    int straightCount = 0;
    int sphereCount = 0;
    int squareCount = 0;

    Dictionary<string, int> markovTrackDict = new Dictionary<string, int>();
    
    private int counter = 1;
    private string stTrackString = "straightTrackPiece";
    private string uTrackString = "uBendTest";
    //private string currentTrackToSpawn;

    private List<string> trackHold = new List<string>();

    private string nextTrackStringToSpawn = "ST";

    private int numberOfPiecesSpawning = 0;

    private double STST = 0;
    private double STCR = 0;
    private double STCL = 0;
    private double STBR = 0;
    private double STU = 0;
    private double STWCR = 0;
    private double STLT = 0;
    private double STWCL = 0;
    private double STBL = 0;
    private double STZ = 0;
    private double STBB = 0;
    private double STTB = 0;
    private double STRT = 0;
    private double stTotal = 0;

    private double CRST = 0;
    private double CRCR = 0;
    private double CRCL = 0;
    private double CRBR = 0;
    private double CRU = 0;
    private double CRWCR = 0;
    private double CRLT = 0;
    private double CRWCL = 0;
    private double CRBL = 0;
    private double CRZ = 0;
    private double CRBB = 0;
    private double CRTB = 0;
    private double CRRT = 0;
    private double crTotal = 0;

    private double CLST = 0;
    private double CLCR = 0;
    private double CLCL = 0;
    private double CLBR = 0;
    private double CLU = 0;
    private double CLWCR = 0;
    private double CLLT = 0;
    private double CLWCL = 0;
    private double CLBL = 0;
    private double CLZ = 0;
    private double CLBB = 0;
    private double CLTB = 0;
    private double CLRT = 0;
    private double clTotal = 0;

    private double BRST = 0;
    private double BRCR = 0;
    private double BRCL = 0;
    private double BRBR = 0;
    private double BRU = 0;
    private double BRWCR = 0;
    private double BRLT = 0;
    private double BRWCL = 0;
    private double BRBL = 0;
    private double BRZ = 0;
    private double BRBB = 0;
    private double BRTB = 0;
    private double BRRT = 0;
    private double brTotal = 0;

    private double UST = 0;
    private double UCR = 0;
    private double UCL = 0;
    private double UBR = 0;
    private double UU = 0;
    private double UWCR = 0;
    private double ULT = 0;
    private double UWCL = 0;
    private double UBL = 0;
    private double UZ = 0;
    private double UBB = 0;
    private double UTB = 0;
    private double URT = 0;
    private double uTotal = 0;

    private double WCRST = 0;
    private double WCRCR = 0;
    private double WCRCL = 0;
    private double WCRBR = 0;
    private double WCRU = 0;
    private double WCRWCR = 0;
    private double WCRLT = 0;
    private double WCRWCL = 0;
    private double WCRBL = 0;
    private double WCRZ = 0;
    private double WCRBB = 0;
    private double WCRTB = 0;
    private double WCRRT = 0;
    private double wcrTotal = 0;

    private double LTST = 0;
    private double LTCR = 0;
    private double LTCL = 0;
    private double LTBR = 0;
    private double LTU = 0;
    private double LTWCR = 0;
    private double LTLT = 0;
    private double LTWCL = 0;
    private double LTBL = 0;
    private double LTZ = 0;
    private double LTBB = 0;
    private double LTTB = 0;
    private double LTRT = 0;
    private double ltTotal = 0;

    private double WCLST = 0;
    private double WCLCR = 0;
    private double WCLCL = 0;
    private double WCLBR = 0;
    private double WCLU = 0;
    private double WCLWCR = 0;
    private double WCLLT = 0;
    private double WCLWCL = 0;
    private double WCLBL = 0;
    private double WCLZ = 0;
    private double WCLBB = 0;
    private double WCLTB = 0;
    private double WCLRT = 0;
    private double wclTotal = 0;

    private double BLST = 0;
    private double BLCR = 0;
    private double BLCL = 0;
    private double BLBR = 0;
    private double BLU = 0;
    private double BLWCR = 0;
    private double BLLT = 0;
    private double BLWCL = 0;
    private double BLBL = 0;
    private double BLZ = 0;
    private double BLBB = 0;
    private double BLTB = 0;
    private double BLRT = 0;
    private double blTotal = 0;

    private double ZST = 0;
    private double ZCR = 0;
    private double ZCL = 0;
    private double ZBR = 0;
    private double ZU = 0;
    private double ZWCR = 0;
    private double ZLT = 0;
    private double ZWCL = 0;
    private double ZBL = 0;
    private double ZZ = 0;
    private double ZBB = 0;
    private double ZTB = 0;
    private double ZRT = 0;
    private double zTotal = 0;

    private double BBST = 0;
    private double BBCR = 0;
    private double BBCL = 0;
    private double BBBR = 0;
    private double BBU = 0;
    private double BBWCR = 0;
    private double BBLT = 0;
    private double BBWCL = 0;
    private double BBBL = 0;
    private double BBZ = 0;
    private double BBBB = 0;
    private double BBTB = 0;
    private double BBRT = 0;
    private double bbTotal = 0;

    private double TBST = 0;
    private double TBCR = 0;
    private double TBCL = 0;
    private double TBBR = 0;
    private double TBU = 0;
    private double TBWCR = 0;
    private double TBLT = 0;
    private double TBWCL = 0;
    private double TBBL = 0;
    private double TBZ = 0;
    private double TBBB = 0;
    private double TBTB = 0;
    private double TBRT = 0;
    private double tbTotal = 0;

    private double RTST = 0;
    private double RTCR = 0;
    private double RTCL = 0;
    private double RTBR = 0;
    private double RTU = 0;
    private double RTWCR = 0;
    private double RTLT = 0;
    private double RTWCL = 0;
    private double RTBL = 0;
    private double RTZ = 0;
    private double RTBB = 0;
    private double RTTB = 0;
    private double RTRT = 0;
    private double rtTotal = 0;


    // Use this for initialization


    void Start() {
        accordMarkov();
        //nextTrackObjectToSpawn = Resources.Load(nextTrackStringToSpawn) as GameObject;
        //Instantiate(nextTrackObjectToSpawn, currentTrackPosition, currentTrackRotation);

        //racetrackRead();
        //racetrackVariableCount();
        //racetrackSelectPiece();
        //displayDictionary();

       // spawnTrackFromString();
        
        //spawnNextPiece();

    }

    public void accordMarkov ()
      {
           string[][] phrases =
          {
              new[] { "ST", "CR", "ST", "BR", "ST", "U", "ST", "RT", "U", "ST" },
              new[] { "ST", "BR", "BL", "BR", "ST", "BL", "BR", "ST", "U", "ST" },
              new[] { "ST", "U", "RT", "RT", "ST", "U", "ST", "WCL", "ST", "U" },
              new[] { "ST", "BR", "CL", "ST", "RT", "WCR", "ST", "Z", "ST", "WCR" },
              new[] { "ST", "CR", "BR", "RT", "WCR", "LT", "WCR","WCL", "ST", "CR" },
              new[] { "ST", "WCR", "ST", "U", "ST", "WCL", "LT", "WCL", "LT", "ST" },
              new[] { "ST", "BR", "BL", "ST", "RT", "RT","RT","BR","ST","LT" }
          };

        // Let's begin by transforming them to sequence of
        // integer labels using a codification codebook:
        var codebook = new Codification("Words", phrases);

        // Now we can create the training data for the models:
        int[][] sequence = codebook.Transform("Words", phrases);

        // To create the models, we will specify a forward topology,
        // as the sequences have definite start and ending points.
        // 
        var topology = new Forward(states: 10);
        int symbols = codebook["Words"].NumberOfSymbols; // We have 7 different words

        // Create the hidden Markov model
        var hmm = new HiddenMarkovModel(topology, symbols);

        // Create the learning algorithm
        var teacher = new BaumWelchLearning(hmm);

        // Teach the model
        teacher.Learn(sequence);

        // Now, we can ask the model to generate new samples
        // from the word distributions it has just learned:
        // 
        int[] sample = hmm.Generate(10);

        // And the result will be: "those", "are", "words".
        string[] result = codebook.Revert("Words", sample);
        
            Debug.Log(result[0] + " " + result[1] + " " + result[2] + " " + result[3] + " " + result[4] + " " + result[5] + " " + result[6] + " " + result[7] + " " + result[8] + " " + result[9]) ;

       //nextTrackObjectToSpawn = Resources.Load(nextTrackStringToSpawn) as GameObject;


        for (int i = 0; i < 10; i++)
        {
            if (result[i] == "ST")
            {
                nextTrackObjectToSpawn = Resources.Load("ST") as GameObject;
                currentTrackPosition.x += 2;
                Instantiate(nextTrackObjectToSpawn, currentTrackPosition, currentTrackRotation);
                currentTrackPosition.x += 2;
            }


            if (result[i] == "CR") //
            {
                nextTrackObjectToSpawn = Resources.Load("CR") as GameObject;
                currentTrackRotation.Set(90, 0, 0, 0);
                // currentTrackPosition.x -= 1;
                Instantiate(nextTrackObjectToSpawn, currentTrackPosition, currentTrackRotation);
                currentTrackPosition.y -= 1;
                currentTrackPosition.x += 1;
            }

            if (result[i] == "CL") //
            {

                nextTrackObjectToSpawn = Resources.Load("CL") as GameObject;
                //currentTrackPosition.x += 1;
                currentTrackRotation.Set(0, 180, 0, 0);
                Instantiate(nextTrackObjectToSpawn, currentTrackPosition, currentTrackRotation);
                currentTrackPosition.y -= 1;
            }

            if (result[i] == "BR")
            {
                nextTrackObjectToSpawn = Resources.Load("BR") as GameObject;
                currentTrackRotation.Set(45, 0, 0, 0);
                Instantiate(nextTrackObjectToSpawn, currentTrackPosition, currentTrackRotation);
                currentTrackPosition.y -= 1;
                currentTrackPosition.x += 1;
            }

            if (result[i] == "U") //
            {
                nextTrackObjectToSpawn = Resources.Load("U") as GameObject;
                currentTrackRotation.Set(45, 90, 0, 0);
                Instantiate(nextTrackObjectToSpawn, currentTrackPosition, currentTrackRotation);
                currentTrackPosition.x += 2;
                currentTrackPosition.y -= 1;

            }

            if (result[i] == "WCR")//
            {
                nextTrackObjectToSpawn = Resources.Load("WCR") as GameObject;
                currentTrackRotation.Set(180, 0, 0, 0);
                Instantiate(nextTrackObjectToSpawn, currentTrackPosition, currentTrackRotation);
                currentTrackPosition.y -= 2;
                currentTrackPosition.x += 1;

            }

            if (result[i] == "LT") //
            {
                nextTrackObjectToSpawn = Resources.Load("LT") as GameObject;
                currentTrackRotation.Set(180, 0, 0, 0);
                Instantiate(nextTrackObjectToSpawn, currentTrackPosition, currentTrackRotation);
                currentTrackPosition.y += 1;
                currentTrackPosition.x += 1;
            }

            if (result[i] == "WCL") //
            {
                nextTrackObjectToSpawn = Resources.Load("WCL") as GameObject;
                currentTrackRotation.Set(-180, 0, 0, 0);
                Instantiate(nextTrackObjectToSpawn, currentTrackPosition, currentTrackRotation);
                currentTrackPosition.y -= 2;
                currentTrackPosition.x += 1;
            }

            if (result[i] == "BL") //
            {
                nextTrackObjectToSpawn = Resources.Load("BL") as GameObject;
                currentTrackRotation.Set(180, 90, 0, 0);
                Instantiate(nextTrackObjectToSpawn, currentTrackPosition, currentTrackRotation);
                currentTrackPosition.y += 1;
                currentTrackPosition.x += 1;
            }

            if (result[i] == "Z") //
            {
                nextTrackObjectToSpawn = Resources.Load("Z") as GameObject;
                currentTrackRotation.Set(90, 0, 0, 0);
                Instantiate(nextTrackObjectToSpawn, currentTrackPosition, currentTrackRotation);
                currentTrackPosition.y -= 2;
                currentTrackPosition.x += 2;
            }

            if (result[i] == "BB") //
            {
                nextTrackObjectToSpawn = Resources.Load("BB") as GameObject;
                currentTrackRotation.Set(90, 0, 0, 0);
                Instantiate(nextTrackObjectToSpawn, currentTrackPosition, currentTrackRotation);
                currentTrackPosition.y -= 1;
                currentTrackPosition.x += 2;
            }

            if (result[i] == "TB") //
            {
                nextTrackObjectToSpawn = Resources.Load("TB") as GameObject;
                Instantiate(nextTrackObjectToSpawn, currentTrackPosition, currentTrackRotation);
                currentTrackPosition.y -= 2;
                currentTrackPosition.x += 2;
            }

            if (result[i] == "RT") //
            {
                nextTrackObjectToSpawn = Resources.Load("RT") as GameObject;
                currentTrackRotation.Set(180, 0, 0, 0);
                Instantiate(nextTrackObjectToSpawn, currentTrackPosition, currentTrackRotation);
                currentTrackPosition.y -= 1;
                currentTrackPosition.x += 1;
            }


        }

        //if (nextTrackStringToSpawn == "ST")//
        //{
        //    currentTrackPosition.x += 2;
        //    Instantiate(nextTrackObjectToSpawn, currentTrackPosition, currentTrackRotation);
        //    currentTrackPosition.x += 2;
        //}

        //if (nextTrackStringToSpawn == "CR") //
        //{

        //    currentTrackRotation.Set(90, 0, 0, 0);
        //    // currentTrackPosition.x -= 1;
        //    Instantiate(nextTrackObjectToSpawn, currentTrackPosition, currentTrackRotation);
        //    currentTrackPosition.y -= 1;
        //    currentTrackPosition.x += 1;
        //}

        //if (nextTrackStringToSpawn == "CL") //
        //{

        //    //currentTrackPosition.x += 1;
        //    currentTrackRotation.Set(0, 180, 0, 0);
        //    Instantiate(nextTrackObjectToSpawn, currentTrackPosition, currentTrackRotation);
        //    currentTrackPosition.y -= 1;
        //}

        //if (nextTrackStringToSpawn == "BR")
        //{

        //    currentTrackRotation.Set(45, 0, 0, 0);
        //    Instantiate(nextTrackObjectToSpawn, currentTrackPosition, currentTrackRotation);
        //    currentTrackPosition.y -= 1;
        //    currentTrackPosition.x += 1;
        //}

        //if (nextTrackStringToSpawn == "U") //
        //{

        //    currentTrackRotation.Set(45, 90, 0, 0);
        //    Instantiate(nextTrackObjectToSpawn, currentTrackPosition, currentTrackRotation);
        //    currentTrackPosition.x += 2;
        //    currentTrackPosition.y -= 1;

        //}

        //if (nextTrackStringToSpawn == "WCR")//
        //{

        //    currentTrackRotation.Set(180, 0, 0, 0);
        //    Instantiate(nextTrackObjectToSpawn, currentTrackPosition, currentTrackRotation);
        //    currentTrackPosition.y -= 2;
        //    currentTrackPosition.x += 1;

        //}

        //if (nextTrackStringToSpawn == "LT") //
        //{

        //    currentTrackRotation.Set(180, 0, 0, 0);
        //    Instantiate(nextTrackObjectToSpawn, currentTrackPosition, currentTrackRotation);
        //    currentTrackPosition.y += 1;
        //    currentTrackPosition.x += 1;
        //}

        //if (nextTrackStringToSpawn == "WCL") //
        //{

        //    currentTrackRotation.Set(-180, 0, 0, 0);
        //    Instantiate(nextTrackObjectToSpawn, currentTrackPosition, currentTrackRotation);
        //    currentTrackPosition.y -= 2;
        //    currentTrackPosition.x += 1;
        //}

        //if (nextTrackStringToSpawn == "BL") //
        //{

        //    currentTrackRotation.Set(180, 90, 0, 0);
        //    Instantiate(nextTrackObjectToSpawn, currentTrackPosition, currentTrackRotation);
        //    currentTrackPosition.y += 1;
        //    currentTrackPosition.x += 1;
        //}

        //if (nextTrackStringToSpawn == "Z") //
        //{

        //    currentTrackRotation.Set(90, 0, 0, 0);
        //    Instantiate(nextTrackObjectToSpawn, currentTrackPosition, currentTrackRotation);
        //    currentTrackPosition.y -= 2;
        //    currentTrackPosition.x += 2;
        //}

        //if (nextTrackStringToSpawn == "BB") //
        //{

        //    currentTrackRotation.Set(90, 0, 0, 0);
        //    Instantiate(nextTrackObjectToSpawn, currentTrackPosition, currentTrackRotation);
        //    currentTrackPosition.y -= 1;
        //    currentTrackPosition.x += 2;
        //}

        //if (nextTrackStringToSpawn == "TB") //
        //{

        //    Instantiate(nextTrackObjectToSpawn, currentTrackPosition, currentTrackRotation);
        //    currentTrackPosition.y -= 2;
        //    currentTrackPosition.x += 2;
        //}

        //if (nextTrackStringToSpawn == "RT") //
        //{

        //    currentTrackRotation.Set(180, 0, 0, 0);
        //    Instantiate(nextTrackObjectToSpawn, currentTrackPosition, currentTrackRotation);
        //    currentTrackPosition.y -= 1;
        //    currentTrackPosition.x += 1;
        //}

    }

    public void displayDictionary()
    {
        //Dictionary<string, int>.KeyCollection trackKeyColl = markovTrackDict.Keys;
        //Dictionary<string, int>.ValueCollection trackValueColl = markovTrackDict.Values;

        //foreach (string trackKeyString in trackKeyColl)
        //{
        //    Debug.Log("Type of track piece: " + trackKeyString);
        //}

        foreach (KeyValuePair<string, int> kvp in markovTrackDict)
        {
            Debug.Log("Dictionary contains" + kvp.Key + kvp.Value);
        }
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

    //public void SplitItGood(string actualInputTest, Dictionary<string, int> markovTrackDict)
    //{
    //    StringBuilder sb = new StringBuilder();
    //    List<string> trackHold = new List<string>(); // This list will hold the keys and values as we find them
    //    bool hasFirstValue = false;

    //    foreach (char c in actualInputTest) // Iterate through each character in the input
    //    {
    //        if (c != ',') // Keep building the string until we reach a comma
    //            sb.Append(c);
    //        else if (c == ',' && !hasFirstValue)
    //        {
    //            trackHold.Add(sb.ToString().Trim());
    //                sb.Length = (0);
    //            hasFirstValue = true;
    //        }
    //        //else if (c == ',' && hasFirstValue)
    //       // {

    //            // Below, the StringBuilder currently has something like this:
    //            // "    235235         Some Text Here"
    //            // We trim the leading whitespace, then split at the first sign of a double space
    //            //string[] bananaSplit = sb.ToString()
    //            //                         .Trim()
    //            //                         .Split(new string[] { "  " },
    //            //                                StringSplitOptions.RemoveEmptyEntries);

    //            //    // Add both results to the list

    //            //    trackHold.Add(bananaSplit[0].Trim());
    //            //    trackHold.Add(bananaSplit[1].Trim());
    //            //    sb.Length = (0);
    //           // }                    
    //    }

    //        trackHold.Add(sb.ToString().Trim()); // Add the last result to the list

    //for (int i = 0; i < trackHold.Count; i += 2)
    //{
    // This for loop assumes that the amount of keys and values added together
    // is an even number. If it comes out odd, then one of the lines on the input
    // text file wasn't parsed correctly or wasn't generated correctly.

    //markovTrackDict.Add(trackHold[i], trackHold[i + 1]);

    // }
    // }

    public void racetrackRead()
    {
        StringBuilder sb = new StringBuilder();

        bool alreadyContained = false;

        string path = @"C:\CTPRaceTrack\RTG\Assets\Resources\trackRead.txt";

        string actualInputString = File.ReadAllText(path);

        foreach (char c in actualInputString)
        // Iterate through each character in the input

        {
            alreadyContained = false;

            if (c != ',')
            // Keep building the string until we reach a comma
            {

                sb.Append(c);

                // If string(track piece) already in dictioanry, increment it's value by 1
                // currentCount needs to be greater than 0?

            }

            // If track piece ISN'T in dictionary, add it to dictionary
            // And start stringbuilder process again

            else if (c == ',' && (alreadyContained == false))
            {

                trackHold.Add(sb.ToString().Trim());
                sb.Length = (0);
                // markovTrackDict.Add(sb.ToString(), currentCount);
                // sb.Length = (0);
            }
        }
    }


   public void racetrackVariableCount()
            
      {   
        
        // Need to be up until the trackhold.Count -1 for 2nd i parameter

        for (int i = 0; i < trackHold.Count -1; i ++)
        {
            if (trackHold[i] == "ST")
            {
                if (trackHold[i + 1] == "ST")
                { STST++; }

                if (trackHold[i + 1] == "CR")
                { STCR++;}

                if (trackHold[i + 1] == "CL")
                { STCL++; }

                if (trackHold[i + 1] == "BR")
                { STBR++; }

                if (trackHold[i + 1] == "U")
                { STU++; }

                if (trackHold[i + 1] == "WCR")
                { STWCR++; }

                if (trackHold[i + 1] == "LT")
                { STLT++; }

                if (trackHold[i + 1] == "WCL")
                { STWCL++; }

                if (trackHold[i + 1] == "BL")
                { STBL++; }

                if (trackHold[i + 1] == "Z")
                { STZ++; }

                if (trackHold[i + 1] == "BB")
                { STBB++; }

                if (trackHold[i + 1] == "TB")
                { STTB++; }

                if (trackHold[i + 1] == "RT")
                { STRT++; }

            }

            // C bend right

            if (trackHold[i] == "CR")
            {
                if (trackHold[i + 1] == "ST")
                { CRST++; }

                if (trackHold[i + 1] == "CR")
                { CRCR++; }

                if (trackHold[i + 1] == "CL")
                { CRCL++; }

                if (trackHold[i + 1] == "BR")
                { CRBR++; }

                if (trackHold[i + 1] == "U")
                { CRU++; }

                if (trackHold[i + 1] == "WCR")
                { CRWCR++; }

                if (trackHold[i + 1] == "LT")
                { CRLT++; }

                if (trackHold[i + 1] == "WCL")
                { CRWCL++; }

                if (trackHold[i + 1] == "BL")
                { CRBL++; }

                if (trackHold[i + 1] == "Z")
                { CRZ++; }

                if (trackHold[i + 1] == "BB")
                { CRBB++; }

                if (trackHold[i + 1] == "TB")
                { CRTB++; }

                if (trackHold[i + 1] == "RT")
                { CRRT++; }

            }

            // C bend left

            if (trackHold[i] == "CL")
            {
                if (trackHold[i + 1] == "ST")
                { CLST++; }

                if (trackHold[i + 1] == "CR")
                { CLCR++; }

                if (trackHold[i + 1] == "CL")
                { CLCL++; }

                if (trackHold[i + 1] == "BR")
                { CLBR++; }

                if (trackHold[i + 1] == "U")
                { CLU++; }

                if (trackHold[i + 1] == "WCR")
                { CLWCR++; }

                if (trackHold[i + 1] == "LT")
                { CLLT++; }

                if (trackHold[i + 1] == "WCL")
                { CLWCL++; }

                if (trackHold[i + 1] == "BL")
                { CLBL++; }

                if (trackHold[i + 1] == "Z")
                { CLZ++; }

                if (trackHold[i + 1] == "BB")
                { CLBB++; }

                if (trackHold[i + 1] == "TB")
                { CLTB++; }

                if (trackHold[i + 1] == "RT")
                { CLRT++; }

            }


            // Bend right pieces

            if (trackHold[i] == "BR")
            {
                if (trackHold[i + 1] == "ST")
                { BRST++; }

                if (trackHold[i + 1] == "CR")
                { BRCR++; }

                if (trackHold[i + 1] == "CL")
                { BRCL++; }

                if (trackHold[i + 1] == "BR")
                { BRBR++; }

                if (trackHold[i + 1] == "U")
                { BRU++; }

                if (trackHold[i + 1] == "WCR")
                { BRWCR++; }

                if (trackHold[i + 1] == "LT")
                { BRLT++; }

                if (trackHold[i + 1] == "WCL")
                { BRWCL++; }

                if (trackHold[i + 1] == "BL")
                { BRBL++; }

                if (trackHold[i + 1] == "Z")
                { BRZ++; }

                if (trackHold[i + 1] == "BB")
                { BRBB++; }

                if (trackHold[i + 1] == "TB")
                { BRTB++; }

                if (trackHold[i + 1] == "RT")
                { BRRT++; }

            }


            // U-Bend pieces

            if (trackHold[i] == "U")
            {
                if (trackHold[i + 1] == "ST")
                { UST++; }

                if (trackHold[i + 1] == "CR")
                { UCR++; }

                if (trackHold[i + 1] == "CL")
                { UCL++; }

                if (trackHold[i + 1] == "BR")
                { UBR++; }

                if (trackHold[i + 1] == "U")
                { UU++; }

                if (trackHold[i + 1] == "WCR")
                { UWCR++; }

                if (trackHold[i + 1] == "LT")
                { ULT++; }

                if (trackHold[i + 1] == "WCL")
                { UWCL++; }

                if (trackHold[i + 1] == "BL")
                { UBL++; }

                if (trackHold[i + 1] == "Z")
                { UZ++; }

                if (trackHold[i + 1] == "BB")
                { UBB++; }

                if (trackHold[i + 1] == "TB")
                { UTB++; }

                if (trackHold[i + 1] == "RT")
                { URT++; }

            }


            // Wide corner right pieces

            if (trackHold[i] == "WCR")
            {
                if (trackHold[i + 1] == "ST")
                { WCRST++; }

                if (trackHold[i + 1] == "CR")
                { WCRCR++; }

                if (trackHold[i + 1] == "CL")
                { WCRCL++; }

                if (trackHold[i + 1] == "BR")
                { WCRBR++; }

                if (trackHold[i + 1] == "U")
                { WCRU++; }

                if (trackHold[i + 1] == "WCR")
                { WCRWCR++; }

                if (trackHold[i + 1] == "LT")
                { WCRLT++; }

                if (trackHold[i + 1] == "WCL")
                { WCRWCL++; }

                if (trackHold[i + 1] == "BL")
                { WCRBL++; }

                if (trackHold[i + 1] == "Z")
                { WCRZ++; }

                if (trackHold[i + 1] == "BB")
                { WCRBB++; }

                if (trackHold[i + 1] == "TB")
                { WCRTB++; }

                if (trackHold[i + 1] == "RT")
                { WCRRT++; }

            }

            // Left straight pieces

            if (trackHold[i] == "LT")
            {
                if (trackHold[i + 1] == "ST")
                { LTST++; }

                if (trackHold[i + 1] == "CR")
                { LTCR++; }

                if (trackHold[i + 1] == "CL")
                { LTCL++; }

                if (trackHold[i + 1] == "BR")
                { LTBR++; }

                if (trackHold[i + 1] == "U")
                { LTU++; }

                if (trackHold[i + 1] == "WCR")
                { LTWCR++; }

                if (trackHold[i + 1] == "LT")
                { LTLT++; }

                if (trackHold[i + 1] == "WCL")
                { LTWCL++; }

                if (trackHold[i + 1] == "BL")
                { LTBL++; }

                if (trackHold[i + 1] == "Z")
                { LTZ++; }

                if (trackHold[i + 1] == "BB")
                { LTBB++; }

                if (trackHold[i + 1] == "TB")
                { LTTB++; }

                if (trackHold[i + 1] == "RT")
                { LTRT++; }

            }


            // Wide corner left pieces

            if (trackHold[i] == "WCL")
            {
                if (trackHold[i + 1] == "ST")
                { WCLST++; }

                if (trackHold[i + 1] == "CR")
                { WCLCR++; }

                if (trackHold[i + 1] == "CL")
                { WCLCL++; }

                if (trackHold[i + 1] == "BR")
                { WCLBR++; }

                if (trackHold[i + 1] == "U")
                { WCLU++; }

                if (trackHold[i + 1] == "WCR")
                { WCLWCR++; }

                if (trackHold[i + 1] == "LT")
                { WCLLT++; }

                if (trackHold[i + 1] == "WCL")
                { WCLWCL++; }

                if (trackHold[i + 1] == "BL")
                { WCLBL++; }

                if (trackHold[i + 1] == "Z")
                { WCLZ++; }

                if (trackHold[i + 1] == "BB")
                { WCLBB++; }

                if (trackHold[i + 1] == "TB")
                { WCLTB++; }

                if (trackHold[i + 1] == "RT")
                { WCLRT++; }

            }


            // Bend left pieces

            if (trackHold[i] == "BL")
            {
                if (trackHold[i + 1] == "ST")
                { BLST++; }

                if (trackHold[i + 1] == "CR")
                { BLCR++; }

                if (trackHold[i + 1] == "CL")
                { BLCL++; }

                if (trackHold[i + 1] == "BR")
                { BLBR++; }

                if (trackHold[i + 1] == "U")
                { BLU++; }

                if (trackHold[i + 1] == "WCR")
                { BLWCR++; }

                if (trackHold[i + 1] == "LT")
                { BLLT++; }

                if (trackHold[i + 1] == "WCL")
                { BLWCL++; }

                if (trackHold[i + 1] == "BL")
                { BLBL++; }

                if (trackHold[i + 1] == "Z")
                { BLZ++; }

                if (trackHold[i + 1] == "BB")
                { BLBB++; }

                if (trackHold[i + 1] == "TB")
                { BLTB++; }

                if (trackHold[i + 1] == "RT")
                { BLRT++; }

            }


            // Z-Bend Pieces

            if (trackHold[i] == "Z")
            {
                if (trackHold[i + 1] == "ST")
                { ZST++; }

                if (trackHold[i + 1] == "CR")
                { ZCR++; }

                if (trackHold[i + 1] == "CL")
                { ZCL++; }

                if (trackHold[i + 1] == "BR")
                { ZBR++; }

                if (trackHold[i + 1] == "U")
                { ZU++; }

                if (trackHold[i + 1] == "WCR")
                { ZWCR++; }

                if (trackHold[i + 1] == "LT")
                { ZLT++; }

                if (trackHold[i + 1] == "WCL")
                { ZWCL++; }

                if (trackHold[i + 1] == "BL")
                { ZBL++; }

                if (trackHold[i + 1] == "Z")
                { ZZ++; }

                if (trackHold[i + 1] == "BB")
                { ZBB++; }

                if (trackHold[i + 1] == "TB")
                { ZTB++; }

                if (trackHold[i + 1] == "RT")
                { ZRT++; }

            }


            // Bottom S-bend pieces

            if (trackHold[i] == "BB")
            {
                if (trackHold[i + 1] == "ST")
                { BBST++; }

                if (trackHold[i + 1] == "CR")
                { BBCR++; }

                if (trackHold[i + 1] == "CL")
                { BBCL++; }

                if (trackHold[i + 1] == "BR")
                { BBBR++; }

                if (trackHold[i + 1] == "U")
                { BBU++; }

                if (trackHold[i + 1] == "WCR")
                { BBWCR++; }

                if (trackHold[i + 1] == "LT")
                { BBLT++; }

                if (trackHold[i + 1] == "WCL")
                { BBWCL++; }

                if (trackHold[i + 1] == "BL")
                { BBBL++; }

                if (trackHold[i + 1] == "Z")
                { BBZ++; }

                if (trackHold[i + 1] == "BB")
                { BBBB++; }

                if (trackHold[i + 1] == "TB")
                { BBTB++; }

                if (trackHold[i + 1] == "RT")
                { BBRT++; }

            }


            // Top S-bend 

            if (trackHold[i] == "TB")
            {
                if (trackHold[i + 1] == "ST")
                { TBST++; }

                if (trackHold[i + 1] == "CR")
                { TBCR++; }

                if (trackHold[i + 1] == "CL")
                { TBCL++; }

                if (trackHold[i + 1] == "BR")
                { TBBR++; }

                if (trackHold[i + 1] == "U")
                { TBU++; }

                if (trackHold[i + 1] == "WCR")
                { TBWCR++; }

                if (trackHold[i + 1] == "LT")
                { TBLT++; }

                if (trackHold[i + 1] == "WCL")
                { TBWCL++; }

                if (trackHold[i + 1] == "BL")
                { TBBL++; }

                if (trackHold[i + 1] == "Z")
                { TBZ++; }

                if (trackHold[i + 1] == "BB")
                { TBBB++; }

                if (trackHold[i + 1] == "TB")
                { TBTB++; }

                if (trackHold[i + 1] == "RT")
                { TBRT++; }

            }

            // Right straight bend

            if (trackHold[i] == "RT")
            {
                if (trackHold[i + 1] == "ST")
                { RTST++; }

                if (trackHold[i + 1] == "CR")
                { RTCR++; }

                if (trackHold[i + 1] == "CL")
                { RTCL++; }

                if (trackHold[i + 1] == "BR")
                { RTBR++; }

                if (trackHold[i + 1] == "U")
                { RTU++; }

                if (trackHold[i + 1] == "WCR")
                { RTWCR++; }

                if (trackHold[i + 1] == "LT")
                { RTLT++; }

                if (trackHold[i + 1] == "WCL")
                { RTWCL++; }

                if (trackHold[i + 1] == "BL")
                { RTBL++; }

                if (trackHold[i + 1] == "Z")
                { RTZ++; }

                if (trackHold[i + 1] == "BB")
                { RTBB++; }

                if (trackHold[i + 1] == "TB")
                { RTTB++; }

                if (trackHold[i + 1] == "RT")
                { RTRT++; }

            }

        }
    }

    public void racetrackSelectPiece()
    {

        while (numberOfPiecesSpawning < 10)
        {
            // create virtual track classes virtual variables functions
            // ! Surround below in some while or if statements, sort logic out LATER
            // Set amount of track piece to spawn e.g. 20 

            // This part first, possible ignore **marked
             if (nextTrackStringToSpawn == "ST")
             {
                // ! Normalise probabilities to the range of 0-1 for values
                // Create this: List<KeyValuePair<string, double>> stList = new List<KeyValuePair<string, double>>();
                // Add all values to list
                // Remove first prefix to determine e.g. the CR before CRST,
                // (Otherwise would have to choose 3rd and 4th char from string)

                List<KeyValuePair<string, double>> stList = new List<KeyValuePair<string, double>>();

                stTotal = STST + STCR + STCL + STBR + STU + STWCR + STLT + STWCL + STBL + STZ + STBB + STTB + STRT;

                stList.Add(new KeyValuePair<string, double>("ST", (STST/stTotal)));
                stList.Add(new KeyValuePair<string, double>("CR", (STCR/stTotal)));
                stList.Add(new KeyValuePair<string, double>("CL", (STCL/stTotal)));
                stList.Add(new KeyValuePair<string, double>("BR", (STBR/stTotal)));
                stList.Add(new KeyValuePair<string, double>("U", (STU/stTotal)));
                stList.Add(new KeyValuePair<string, double>("WCR", (STWCR/stTotal)));
                stList.Add(new KeyValuePair<string, double>("LT", (STLT/stTotal)));
                stList.Add(new KeyValuePair<string, double>("WCL", (STWCL/stTotal)));
                stList.Add(new KeyValuePair<string, double>("BL", (STBL/stTotal)));
                stList.Add(new KeyValuePair<string, double>("Z", (STZ/stTotal)));
                stList.Add(new KeyValuePair<string, double>("BB", (STBB/stTotal)));
                stList.Add(new KeyValuePair<string, double>("TB", (STTB/stTotal)));
                stList.Add(new KeyValuePair<string, double>("RT", (STRT/stTotal)));

                System.Random r = new System.Random();
                double randomRoll = r.NextDouble();

                double cumulativeTotal = 0.0;

                for (int i = 0; i < stList.Count; i++)
                {
                    cumulativeTotal += stList[i].Value;
                    if (randomRoll < cumulativeTotal)
                    {
                        nextTrackStringToSpawn = stList[i].Key;
                        break;
                    }
                }
                spawnNextPiece();
                numberOfPiecesSpawning++;
                stList = null;
            }

            if (nextTrackStringToSpawn == "CR")
            {
                List<KeyValuePair<string, double>> crList = new List<KeyValuePair<string, double>>();

                crTotal = CRST + CRCR + CRCL + CRBR + CRU + CRWCR + CRLT + CRWCL + CRBL + CRZ + CRBB + CRTB + CRRT;

                crList.Add(new KeyValuePair<string, double>("ST", (CRST / crTotal)));
                crList.Add(new KeyValuePair<string, double>("CR", (CRCR / crTotal)));
                crList.Add(new KeyValuePair<string, double>("CL", (CRCL / crTotal)));
                crList.Add(new KeyValuePair<string, double>("BR", (CRBR / crTotal)));
                crList.Add(new KeyValuePair<string, double>("U", (CRU / crTotal)));
                crList.Add(new KeyValuePair<string, double>("WCR", (CRWCR / crTotal)));
                crList.Add(new KeyValuePair<string, double>("LT", (CRLT / crTotal)));
                crList.Add(new KeyValuePair<string, double>("WCL", (CRWCL / crTotal)));
                crList.Add(new KeyValuePair<string, double>("BL", (CRBL / crTotal)));
                crList.Add(new KeyValuePair<string, double>("Z", (CRZ / crTotal)));
                crList.Add(new KeyValuePair<string, double>("BB", (CRBB / crTotal)));
                crList.Add(new KeyValuePair<string, double>("TB", (CRTB / crTotal)));
                crList.Add(new KeyValuePair<string, double>("RT", (CRRT / crTotal)));

                System.Random r = new System.Random();
                double randomRoll = r.NextDouble();

                double cumulativeTotal = 0.0;

                for (int i = 0; i < crList.Count; i++)
                {
                    cumulativeTotal += crList[i].Value;
                    if (randomRoll < cumulativeTotal)
                    {
                        nextTrackStringToSpawn = crList[i].Key;
                        break;
                    }
                }
                spawnNextPiece();
                numberOfPiecesSpawning++;
                crList = null;
            }

            if (nextTrackStringToSpawn == "CL")
            {
                List<KeyValuePair<string, double>> clList = new List<KeyValuePair<string, double>>();

                clTotal = CLST + CLCR + CLCL + CLBR + CLU + CLWCR + CLLT + CLWCL + CLBL + CLZ + CLBB + CLTB + CLRT;

                clList.Add(new KeyValuePair<string, double>("ST", (CLST/clTotal)));
                clList.Add(new KeyValuePair<string, double>("CR", (CLCR/clTotal)));
                clList.Add(new KeyValuePair<string, double>("CL", (CLCL/clTotal)));
                clList.Add(new KeyValuePair<string, double>("BR", (CLBR/clTotal)));
                clList.Add(new KeyValuePair<string, double>("U", (CLU/clTotal)));
                clList.Add(new KeyValuePair<string, double>("WCR", (CLWCR/clTotal)));
                clList.Add(new KeyValuePair<string, double>("LT", (CLLT/clTotal)));
                clList.Add(new KeyValuePair<string, double>("WCL", (CLWCL/clTotal)));
                clList.Add(new KeyValuePair<string, double>("BL", (CLBL/clTotal)));
                clList.Add(new KeyValuePair<string, double>("Z", (CLZ/clTotal)));
                clList.Add(new KeyValuePair<string, double>("BB", (CLBB/clTotal)));
                clList.Add(new KeyValuePair<string, double>("TB", (CLTB/clTotal)));
                clList.Add(new KeyValuePair<string, double>("RT", (CLRT/clTotal)));

                System.Random r = new System.Random();
                double randomRoll = r.NextDouble();

                double cumulativeTotal = 0.0;

                for (int i = 0; i < clList.Count; i++)
                {
                    cumulativeTotal += clList[i].Value;
                    if (randomRoll < cumulativeTotal)
                    {
                        nextTrackStringToSpawn = clList[i].Key;
                        break;
                    }
                }
                spawnNextPiece();
                numberOfPiecesSpawning++;
                clList = null;
            }

            if (nextTrackStringToSpawn == "BR")
            {
                List<KeyValuePair<string, double>> brList = new List<KeyValuePair<string, double>>();

                brTotal = BRST + BRCR + BRCL + BRBR + BRU + BRWCR + BRLT + BRWCL + BRBL + BRZ + BRBB + BRTB + BRRT;

                brList.Add(new KeyValuePair<string, double>("ST", (BRST/brTotal)));
                brList.Add(new KeyValuePair<string, double>("CR", (BRCR/brTotal)));
                brList.Add(new KeyValuePair<string, double>("CL", (BRCL/brTotal)));
                brList.Add(new KeyValuePair<string, double>("BR", (BRBR/brTotal)));
                brList.Add(new KeyValuePair<string, double>("U", (BRU/brTotal)));
                brList.Add(new KeyValuePair<string, double>("WCR", (BRWCR/brTotal)));
                brList.Add(new KeyValuePair<string, double>("LT", (BRLT/brTotal)));
                brList.Add(new KeyValuePair<string, double>("WCL", (BRWCL/brTotal)));
                brList.Add(new KeyValuePair<string, double>("BL", (BRBL/brTotal)));
                brList.Add(new KeyValuePair<string, double>("Z", (BRZ/brTotal)));
                brList.Add(new KeyValuePair<string, double>("BB", (BRBB/brTotal)));
                brList.Add(new KeyValuePair<string, double>("TB", (BRTB/brTotal)));
                brList.Add(new KeyValuePair<string, double>("RT", (BRRT/brTotal)));

                System.Random r = new System.Random();
                double randomRoll = r.NextDouble();

                double cumulativeTotal = 0.0;

                for (int i = 0; i < brList.Count; i++)
                {
                    cumulativeTotal += brList[i].Value;
                    if (randomRoll < cumulativeTotal)
                    {
                        nextTrackStringToSpawn = brList[i].Key;
                        break;
                    }
                }
                spawnNextPiece();
                numberOfPiecesSpawning++;
                brList = null;

            }

            if (nextTrackStringToSpawn == "U")
            {
                List<KeyValuePair<string, double>> uList = new List<KeyValuePair<string, double>>();

                uTotal = UST + UCR + UCL + UBR + UU + UWCR + ULT + UWCL + UBL + UZ + UBB + UTB + URT;

                uList.Add(new KeyValuePair<string, double>("ST", (UST/uTotal)));
                uList.Add(new KeyValuePair<string, double>("CR", (UCR/uTotal)));
                uList.Add(new KeyValuePair<string, double>("CL", (UCL/uTotal)));
                uList.Add(new KeyValuePair<string, double>("BR", (UBR/uTotal)));
                uList.Add(new KeyValuePair<string, double>("U", (UU/uTotal)));
                uList.Add(new KeyValuePair<string, double>("WCR", (UWCR/uTotal)));
                uList.Add(new KeyValuePair<string, double>("LT", (ULT/uTotal)));
                uList.Add(new KeyValuePair<string, double>("WCL", (UWCL/uTotal)));
                uList.Add(new KeyValuePair<string, double>("BL", (UBL/uTotal)));
                uList.Add(new KeyValuePair<string, double>("Z", (UZ/uTotal)));
                uList.Add(new KeyValuePair<string, double>("BB", (UBB/uTotal)));
                uList.Add(new KeyValuePair<string, double>("TB", (UTB/uTotal)));
                uList.Add(new KeyValuePair<string, double>("RT", (URT/uTotal)));

                System.Random r = new System.Random();
                double randomRoll = r.NextDouble();

                double cumulativeTotal = 0.0;

                for (int i = 0; i < uList.Count; i++)
                {
                    cumulativeTotal += uList[i].Value;
                    if (randomRoll < cumulativeTotal)
                    {
                        nextTrackStringToSpawn = uList[i].Key;
                        break;
                    }
                }
                spawnNextPiece();
                numberOfPiecesSpawning++;
                uList = null;

            }

            if (nextTrackStringToSpawn == "WCR")
            {
                List<KeyValuePair<string, double>> wcrList = new List<KeyValuePair<string, double>>();

                wcrTotal = WCRST + WCRCR + WCRCL + WCRBR + WCRU + WCRWCR + WCRLT + WCRWCL + WCRBL + WCRZ + WCRBB + WCRTB + WCRRT;

                wcrList.Add(new KeyValuePair<string, double>("ST", (WCRST/wcrTotal)));
                wcrList.Add(new KeyValuePair<string, double>("CR", (WCRCR/wcrTotal)));
                wcrList.Add(new KeyValuePair<string, double>("CL", (WCRCL/wcrTotal)));
                wcrList.Add(new KeyValuePair<string, double>("BR", (WCRBR/wcrTotal)));
                wcrList.Add(new KeyValuePair<string, double>("U", (WCRU/wcrTotal)));
                wcrList.Add(new KeyValuePair<string, double>("WCR", (WCRWCR/wcrTotal)));
                wcrList.Add(new KeyValuePair<string, double>("LT", (WCRLT/wcrTotal)));
                wcrList.Add(new KeyValuePair<string, double>("WCL", (WCRWCL/wcrTotal)));
                wcrList.Add(new KeyValuePair<string, double>("BL", (WCRBL/wcrTotal)));
                wcrList.Add(new KeyValuePair<string, double>("Z", (WCRZ/wcrTotal)));
                wcrList.Add(new KeyValuePair<string, double>("BB", (WCRBB/wcrTotal)));
                wcrList.Add(new KeyValuePair<string, double>("TB", (WCRTB/wcrTotal)));
                wcrList.Add(new KeyValuePair<string, double>("RT", (WCRRT/wcrTotal)));

                System.Random r = new System.Random();
                double randomRoll = r.NextDouble();

                double cumulativeTotal = 0.0;

                for (int i = 0; i < wcrList.Count; i++)
                {
                    cumulativeTotal += wcrList[i].Value;
                    if (randomRoll < cumulativeTotal)
                    {
                        nextTrackStringToSpawn = wcrList[i].Key;
                        break;
                    }
                }
                spawnNextPiece();
                numberOfPiecesSpawning++;
                wcrList = null;
            }

            if (nextTrackStringToSpawn == "LT")
            {
                List<KeyValuePair<string, double>> ltList = new List<KeyValuePair<string, double>>();

                ltTotal = LTST + LTCR + LTCL + LTBR + LTU + LTWCR + LTLT + LTWCL + LTBL + LTZ + LTBB + LTTB + LTRT;

                ltList.Add(new KeyValuePair<string, double>("ST", (LTST/ltTotal)));
                ltList.Add(new KeyValuePair<string, double>("CR", (LTCR/ltTotal)));
                ltList.Add(new KeyValuePair<string, double>("CL", (LTCL/ltTotal)));
                ltList.Add(new KeyValuePair<string, double>("BR", (LTBR/ltTotal)));
                ltList.Add(new KeyValuePair<string, double>("U", (LTU/ltTotal)));
                ltList.Add(new KeyValuePair<string, double>("WCR", (LTWCR/ltTotal)));
                ltList.Add(new KeyValuePair<string, double>("LT", (LTLT/ltTotal)));
                ltList.Add(new KeyValuePair<string, double>("WCL", (LTWCL/ltTotal)));
                ltList.Add(new KeyValuePair<string, double>("BL", (LTBL/ltTotal)));
                ltList.Add(new KeyValuePair<string, double>("Z", (LTZ/ltTotal)));
                ltList.Add(new KeyValuePair<string, double>("BB", (LTBB/ltTotal)));
                ltList.Add(new KeyValuePair<string, double>("TB", (LTTB/ltTotal)));
                ltList.Add(new KeyValuePair<string, double>("RT", (LTRT/ltTotal)));

                System.Random r = new System.Random();
                double randomRoll = r.NextDouble();

                double cumulativeTotal = 0.0;

                for (int i = 0; i < ltList.Count; i++)
                {
                    cumulativeTotal += ltList[i].Value;
                    if (randomRoll < cumulativeTotal)
                    {
                        nextTrackStringToSpawn = ltList[i].Key;
                        break;
                    }
                }
                spawnNextPiece();
                numberOfPiecesSpawning++;
                ltList = null;

            }

            if (nextTrackStringToSpawn == "WCL")
            {
                List<KeyValuePair<string, double>> wclList = new List<KeyValuePair<string, double>>();

                wclTotal = WCLST + WCLCR + WCLCL + WCLBR + WCLU + WCLWCR + WCLLT + WCLWCL + WCLBL + WCLZ + WCLBB + WCLTB + WCLRT;

                wclList.Add(new KeyValuePair<string, double>("ST", (WCLST/wclTotal)));
                wclList.Add(new KeyValuePair<string, double>("CR", (WCLCR/wclTotal)));
                wclList.Add(new KeyValuePair<string, double>("CL", (WCLCL/wclTotal)));
                wclList.Add(new KeyValuePair<string, double>("BR", (WCLBR/wclTotal)));
                wclList.Add(new KeyValuePair<string, double>("U", (WCLU/wclTotal)));
                wclList.Add(new KeyValuePair<string, double>("WCR", (WCLWCR/wclTotal)));
                wclList.Add(new KeyValuePair<string, double>("LT", (WCLLT/wclTotal)));
                wclList.Add(new KeyValuePair<string, double>("WCL", (WCLWCL/wclTotal)));
                wclList.Add(new KeyValuePair<string, double>("BL", (WCLBL/wclTotal)));
                wclList.Add(new KeyValuePair<string, double>("Z", (WCLZ/wclTotal)));
                wclList.Add(new KeyValuePair<string, double>("BB", (WCLBB/wclTotal)));
                wclList.Add(new KeyValuePair<string, double>("TB", (WCLTB/wclTotal)));
                wclList.Add(new KeyValuePair<string, double>("RT", (WCLRT/wclTotal)));

                System.Random r = new System.Random();
                double randomRoll = r.NextDouble();

                double cumulativeTotal = 0.0;

                for (int i = 0; i < wclList.Count; i++)
                {
                    cumulativeTotal += wclList[i].Value;
                    if (randomRoll < cumulativeTotal)
                    {
                        nextTrackStringToSpawn = wclList[i].Key;
                        break;
                    }
                }
                spawnNextPiece();
                numberOfPiecesSpawning++;
                wclList = null;

            }

            if (nextTrackStringToSpawn == "BL")
            {
                List<KeyValuePair<string, double>> blList = new List<KeyValuePair<string, double>>();

                blTotal = BLST + BLCR + BLCL + BLBR + BLU + BLWCR + BLLT + BLWCL + BLBL + BLZ + BLBB + BLTB + BLRT;

                blList.Add(new KeyValuePair<string, double>("ST", (BLST/blTotal)));
                blList.Add(new KeyValuePair<string, double>("CR", (BLCR/blTotal)));
                blList.Add(new KeyValuePair<string, double>("CL", (BLCL/blTotal)));
                blList.Add(new KeyValuePair<string, double>("BR", (BLBR/blTotal)));
                blList.Add(new KeyValuePair<string, double>("U", (BLU/blTotal)));
                blList.Add(new KeyValuePair<string, double>("WCR", (BLWCR/blTotal)));
                blList.Add(new KeyValuePair<string, double>("LT", (BLLT/blTotal)));
                blList.Add(new KeyValuePair<string, double>("WCL", (BLWCL/blTotal)));
                blList.Add(new KeyValuePair<string, double>("BL", (BLBL/blTotal)));
                blList.Add(new KeyValuePair<string, double>("Z", (BLZ/blTotal)));
                blList.Add(new KeyValuePair<string, double>("BB", (BLBB/blTotal)));
                blList.Add(new KeyValuePair<string, double>("TB", (BLTB/blTotal)));
                blList.Add(new KeyValuePair<string, double>("RT", (BLRT/blTotal)));

                System.Random r = new System.Random();
                double randomRoll = r.NextDouble();

                double cumulativeTotal = 0.0;

                for (int i = 0; i < blList.Count; i++)
                {
                    cumulativeTotal += blList[i].Value;
                    if (randomRoll < cumulativeTotal)
                    {
                        nextTrackStringToSpawn = blList[i].Key;
                        break;
                    }
                }
                spawnNextPiece();
                numberOfPiecesSpawning++;
                blList = null;
            }

            if (nextTrackStringToSpawn == "Z")
            {
                List<KeyValuePair<string, double>> zList = new List<KeyValuePair<string, double>>();

                zTotal = ZST + ZCR + ZCL + ZBR + ZU + ZWCR + ZLT + ZWCL + ZBL + ZZ + ZBB + ZTB + ZRT;

                zList.Add(new KeyValuePair<string, double>("ST", (ZST / zTotal)));
                zList.Add(new KeyValuePair<string, double>("CR", (ZCR / zTotal)));
                zList.Add(new KeyValuePair<string, double>("CL", (ZCL / zTotal)));
                zList.Add(new KeyValuePair<string, double>("BR", (ZBR / zTotal)));
                zList.Add(new KeyValuePair<string, double>("U", (ZU / zTotal)));
                zList.Add(new KeyValuePair<string, double>("WCR", (ZWCR / zTotal)));
                zList.Add(new KeyValuePair<string, double>("LT", (ZLT / zTotal)));
                zList.Add(new KeyValuePair<string, double>("WCL", (ZWCL / zTotal)));
                zList.Add(new KeyValuePair<string, double>("BL", (ZBL / zTotal)));
                zList.Add(new KeyValuePair<string, double>("Z", (ZZ / zTotal)));
                zList.Add(new KeyValuePair<string, double>("BB", (ZBB / zTotal)));
                zList.Add(new KeyValuePair<string, double>("TB", (ZTB / zTotal)));
                zList.Add(new KeyValuePair<string, double>("RT", (ZRT / zTotal)));

                System.Random r = new System.Random();
                double randomRoll = r.NextDouble();

                double cumulativeTotal = 0.0;

                for (int i = 0; i < zList.Count; i++)
                {
                    cumulativeTotal += zList[i].Value;
                    if (randomRoll < cumulativeTotal)
                    {
                        nextTrackStringToSpawn = zList[i].Key;
                        break;
                    }
                }
                spawnNextPiece();
                numberOfPiecesSpawning++;
                zList = null;
            }

            if (nextTrackStringToSpawn == "BB")
            {
                List<KeyValuePair<string, double>> bbList = new List<KeyValuePair<string, double>>();

                bbTotal = BBST + BBCR + BBCL + BBBR + BBU + BBWCR + BBLT + BBWCL + BBBL + BBZ + BBBB + BBTB + BBRT;

                bbList.Add(new KeyValuePair<string, double>("ST", (BBST / bbTotal)));
                bbList.Add(new KeyValuePair<string, double>("CR", (BBCR / bbTotal)));
                bbList.Add(new KeyValuePair<string, double>("CL", (BBCL / bbTotal)));
                bbList.Add(new KeyValuePair<string, double>("BR", (BBBR / bbTotal)));
                bbList.Add(new KeyValuePair<string, double>("U", (BBU / bbTotal)));
                bbList.Add(new KeyValuePair<string, double>("WCR", (BBWCR / bbTotal)));
                bbList.Add(new KeyValuePair<string, double>("LT", (BBLT / bbTotal)));
                bbList.Add(new KeyValuePair<string, double>("WCL", (BBWCL / bbTotal)));
                bbList.Add(new KeyValuePair<string, double>("BL", (BBBL / bbTotal)));
                bbList.Add(new KeyValuePair<string, double>("Z", (BBZ / bbTotal)));
                bbList.Add(new KeyValuePair<string, double>("BB", (BBBB / bbTotal)));
                bbList.Add(new KeyValuePair<string, double>("TB", (BBTB / bbTotal)));
                bbList.Add(new KeyValuePair<string, double>("RT", (BBRT / bbTotal)));

                System.Random r = new System.Random();
                double randomRoll = r.NextDouble();

                double cumulativeTotal = 0.0;

                for (int i = 0; i < bbList.Count; i++)
                {
                    cumulativeTotal += bbList[i].Value;
                    if (randomRoll < cumulativeTotal)
                    {
                        nextTrackStringToSpawn = bbList[i].Key;
                        break;
                    }
                }
                spawnNextPiece();
                numberOfPiecesSpawning++;
                bbList = null;
            }

            if (nextTrackStringToSpawn == "TB")
            {
                List<KeyValuePair<string, double>> tbList = new List<KeyValuePair<string, double>>();

                tbTotal = TBST + TBCR + TBCL + TBBR + TBU + TBWCR + TBLT + TBWCL + TBBL + TBZ + TBBB + TBTB + TBRT;

                tbList.Add(new KeyValuePair<string, double>("ST", (TBST / tbTotal)));
                tbList.Add(new KeyValuePair<string, double>("CR", (TBCR / tbTotal)));
                tbList.Add(new KeyValuePair<string, double>("CL", (TBCL / tbTotal)));
                tbList.Add(new KeyValuePair<string, double>("BR", (TBBR / tbTotal)));
                tbList.Add(new KeyValuePair<string, double>("U", (TBU / tbTotal)));
                tbList.Add(new KeyValuePair<string, double>("WCR", (TBWCR / tbTotal)));
                tbList.Add(new KeyValuePair<string, double>("LT", (TBLT / tbTotal)));
                tbList.Add(new KeyValuePair<string, double>("WCL", (TBWCL / tbTotal)));
                tbList.Add(new KeyValuePair<string, double>("BL", (TBBL / tbTotal)));
                tbList.Add(new KeyValuePair<string, double>("Z", (TBZ / tbTotal)));
                tbList.Add(new KeyValuePair<string, double>("BB", (TBBB / tbTotal)));
                tbList.Add(new KeyValuePair<string, double>("TB", (TBTB / tbTotal)));
                tbList.Add(new KeyValuePair<string, double>("RT", (TBRT / tbTotal)));

                System.Random r = new System.Random();
                double randomRoll = r.NextDouble();

                double cumulativeTotal = 0.0;

                for (int i = 0; i < tbList.Count; i++)
                {
                    cumulativeTotal += tbList[i].Value;
                    if (randomRoll < cumulativeTotal)
                    {
                        nextTrackStringToSpawn = tbList[i].Key;
                        break;
                    }
                }
                spawnNextPiece();
                numberOfPiecesSpawning++;
                tbList = null;
            }
            if (nextTrackStringToSpawn == "RT")
            {
                List<KeyValuePair<string, double>> rtList = new List<KeyValuePair<string, double>>();

                rtTotal = RTST + RTCR + RTCL + RTBR + RTU + RTWCR + RTLT + RTWCL + RTBL + RTZ + RTBB + RTTB + RTRT;

                rtList.Add(new KeyValuePair<string, double>("ST", (RTST / rtTotal)));
                rtList.Add(new KeyValuePair<string, double>("CR", (RTCR / rtTotal)));
                rtList.Add(new KeyValuePair<string, double>("CL", (RTCL / rtTotal)));
                rtList.Add(new KeyValuePair<string, double>("BR", (RTBR / rtTotal)));
                rtList.Add(new KeyValuePair<string, double>("U", (RTU / rtTotal)));
                rtList.Add(new KeyValuePair<string, double>("WCR", (RTWCR / rtTotal)));
                rtList.Add(new KeyValuePair<string, double>("LT", (RTLT / rtTotal)));
                rtList.Add(new KeyValuePair<string, double>("WCL", (RTWCL / rtTotal)));
                rtList.Add(new KeyValuePair<string, double>("BL", (RTBL / rtTotal)));
                rtList.Add(new KeyValuePair<string, double>("Z", (RTZ / rtTotal)));
                rtList.Add(new KeyValuePair<string, double>("BB", (RTBB / rtTotal)));
                rtList.Add(new KeyValuePair<string, double>("TB", (RTTB / rtTotal)));
                rtList.Add(new KeyValuePair<string, double>("RT", (RTRT / rtTotal)));

                System.Random r = new System.Random();
                double randomRoll = r.NextDouble();

                double cumulativeTotal = 0.0;

                for (int i = 0; i < rtList.Count; i++)
                {
                    cumulativeTotal += rtList[i].Value;
                    if (randomRoll < cumulativeTotal)
                    {
                        nextTrackStringToSpawn = rtList[i].Key;
                        break;
                    }
                }
                spawnNextPiece();
                numberOfPiecesSpawning++;
                rtList = null;

            }

        }
    }
       
          
            // http://www.vcskicks.com/random-element.php
            // https://stackoverflow.com/questions/3655430/selection-based-on-percentage-weighting

            // Seperate dicitonaries for each track piece 
            // e.g. dictionary for STST,STCR.. dictionary for CRST,CRCR... etc
            
            /* 

               Random r = new Random();
               double diceRoll = r.NextDouble();

               double cumulative = 0.0;
               for (int i = 0; i < stList.Count; i++)
                {
                   cumulative += stList[i].Value;
                    if (diceRoll < cumulative)
                     {
                          nextTrackStringToSpawn = stList[i].Key;
                            break;
                     }
                }
                // spawnNextPiece();

            If (nextTrackObjectToSpawn == "CR")
            // {
            // ! Normalise probabilities to the range of 0-1 for values
            // Create this: List<KeyValuePair<string, double>> crList = new List<KeyValuePair<string, double>>();
            // Add all values to list
            // Remove first prefix to determine e.g. the CR before CRST
            // Otherwise would have to choose 3rd and 4th char from string
            // crList.Add(new KeyValuePair<string, double> ("ST", CRST)); etc..    

            Random r = new Random();
               double diceRoll = r.NextDouble();

               double cumulative = 0.0;
               for (int i = 0; i < crList.Count; i++)
                {
                   cumulative += crList[i].Value;
                    if (diceRoll < cumulative)
                     {
                          nextTrackStringToSpawn = crList[i].Key;
                            break;
                     }
                }
                // spawnNextPiece();
              }       

        */

    //if (markovTrackDict.TryGetValue(actualInputTest, out currentCount))
    //{
    //    markovTrackDict[actualInputTest] = currentCount + 1;
    //    //https://stackoverflow.com/questions/7132738/incrementing-a-numerical-value-in-a-dictionary

        //}
        //else
        //{
        //    markovTrackDict.Add(actualInputTest, currentCount);
        //}


        //for (int i = 0; i < 50; i++)
        //{
        //    // if (markovTrackDict.ContainsKey(actualInputTest))
        //    // {
        //    if (markovTrackDict.TryGetValue(actualInputTest,out currentCount))
        //{
        //        markovTrackDict[actualInputTest] = currentCount + 1;
        //        //https://stackoverflow.com/questions/7132738/incrementing-a-numerical-value-in-a-dictionary
        //        // markovTrackDict[i++],actualInputTest
        //    }


        // else
        // {
        //   markovTrackDict.Add(actualInputTest, currentCount);
        //       }


        //if (markovTrackDict[i]
        //markovTrackDict(KeyValuePair <[i][++] >);
        //markovTrackDict(key[i], value++);
        //}
        // }

        //public void DisplayContents(ICollection keyCollection, ICollection valueCollection,int dictionarySize)
        //   {

        //       String[] myKeys = new String[dictionarySize];
        //       String[] myValues = new String[dictionarySize];
        //       keyCollection.CopyTo(myKeys, 0);
        //       valueCollection.CopyTo(myValues, 0);

        //       // Displays the contents of the OrderedDictionary
        //          for (int i = 0; i < maxWordLength; i++)
        //       {
        //           listOfPieces[i] = myValues[i];
        //       }

        //   }

        //   public void addTrackPiecesToDict()
        //   {

        //       ICollection keyCollection = markovTrackPieces.Keys;
        //       ICollection valueCollection = markovTrackPieces.Values;

        //       // increment each variable for how many times it's found in list
        //       //

        //       for (int i = 0; i < maxWordLength; i ++)
        //       {
        //           if (listOfPieces[i] == "ST" && listOfPieces[i+1] == "ST")
        //           {
        //               STST++;
        //           }
        //           if (listOfPieces[i] == "ST" && listOfPieces[i + 1] == "CR")
        //           {
        //               STCR++;
        //           }

        //       }

        //   }


    //public void spawnTrackFromString()
    //{
    //   // GameObject straightTrackPieceObject = (GameObject)Instantiate(Resources.Load(stTrackString));
    //    currentTrackPosition = new Vector3(0,0,0);

    //    straightTrackPieceObject = Resources.Load(stTrackString) as GameObject;
        
    //    Instantiate(straightTrackPieceObject, currentTrackPosition, Quaternion.identity);
    //    currentTrackPosition.y += 1;

    //}

    //void OnCollisionEnter (Collision col)
    //{
    //    Destroy(nextTrackObjectToSpawn);
    //    // Call function to change rotation and position of track piece
    //    // Or spawn a different track piece
    //}

    public void spawnNextPiece()
    {
        
        nextTrackObjectToSpawn = Resources.Load(nextTrackStringToSpawn) as GameObject;
       
        if (nextTrackStringToSpawn == "ST")//
        {
            currentTrackPosition.x += 2;
            Instantiate(nextTrackObjectToSpawn, currentTrackPosition, currentTrackRotation);
            currentTrackPosition.x += 2;
        }

        if (nextTrackStringToSpawn == "CR") //
        {
            
            currentTrackRotation.Set(90,0, 0, 0);
            // currentTrackPosition.x -= 1;
            Instantiate(nextTrackObjectToSpawn, currentTrackPosition, currentTrackRotation);
            currentTrackPosition.y -= 1;
            currentTrackPosition.x += 1;
        }

        if (nextTrackStringToSpawn == "CL") //
        {
            
            //currentTrackPosition.x += 1;
            currentTrackRotation.Set(0,180, 0, 0);
            Instantiate(nextTrackObjectToSpawn, currentTrackPosition, currentTrackRotation);
            currentTrackPosition.y -= 1;
        }

        if (nextTrackStringToSpawn == "BR")
        {
            
            currentTrackRotation.Set(45, 0, 0, 0);
            Instantiate(nextTrackObjectToSpawn, currentTrackPosition, currentTrackRotation);
            currentTrackPosition.y -= 1;
            currentTrackPosition.x += 1;
        }

        if (nextTrackStringToSpawn == "U") //
        {
            
            currentTrackRotation.Set(45, 90, 0, 0);
            Instantiate(nextTrackObjectToSpawn, currentTrackPosition, currentTrackRotation);
            currentTrackPosition.x += 2;
            currentTrackPosition.y -= 1;

        }

        if (nextTrackStringToSpawn == "WCR")//
        {
            
            currentTrackRotation.Set(180, 0, 0, 0);
            Instantiate(nextTrackObjectToSpawn, currentTrackPosition, currentTrackRotation);
            currentTrackPosition.y -= 2;
            currentTrackPosition.x += 1;

        }

        if (nextTrackStringToSpawn == "LT") //
        {
            
            currentTrackRotation.Set(180, 0, 0, 0);
            Instantiate(nextTrackObjectToSpawn, currentTrackPosition, currentTrackRotation);
            currentTrackPosition.y += 1;
            currentTrackPosition.x += 1;
        }

        if (nextTrackStringToSpawn == "WCL") //
        {
            
            currentTrackRotation.Set(-180, 0, 0, 0);
            Instantiate(nextTrackObjectToSpawn, currentTrackPosition, currentTrackRotation);
            currentTrackPosition.y -= 2;
            currentTrackPosition.x += 1;
        }

        if (nextTrackStringToSpawn == "BL") //
        {
           
            currentTrackRotation.Set(180, 90, 0, 0);
            Instantiate(nextTrackObjectToSpawn, currentTrackPosition, currentTrackRotation);
            currentTrackPosition.y += 1;
            currentTrackPosition.x += 1;
        }

        if (nextTrackStringToSpawn == "Z") //
        {
           
            currentTrackRotation.Set(90, 0, 0, 0);
            Instantiate(nextTrackObjectToSpawn, currentTrackPosition, currentTrackRotation);
            currentTrackPosition.y -= 2;
            currentTrackPosition.x += 2;
        }

        if (nextTrackStringToSpawn == "BB") //
        {
            
            currentTrackRotation.Set(90, 0, 0, 0);
            Instantiate(nextTrackObjectToSpawn, currentTrackPosition, currentTrackRotation);
            currentTrackPosition.y -= 1;
            currentTrackPosition.x += 2;
        }

        if (nextTrackStringToSpawn == "TB") //
        {
           
            Instantiate(nextTrackObjectToSpawn, currentTrackPosition, currentTrackRotation);
            currentTrackPosition.y -= 2;
            currentTrackPosition.x += 2;
        }

        if (nextTrackStringToSpawn == "RT") //
        {
            
            currentTrackRotation.Set(180, 0, 0, 0);
            Instantiate(nextTrackObjectToSpawn, currentTrackPosition, currentTrackRotation);
            currentTrackPosition.y -= 1;
            currentTrackPosition.x += 1;
        }

        //currentTrackPosition.x += 10;
    }


    // Update is called once per frame
    void Update () {
		
	}
}
