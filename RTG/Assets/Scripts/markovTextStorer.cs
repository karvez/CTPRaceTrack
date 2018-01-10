using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class markovTextStorer : MonoBehaviour
{

    public Dictionary<string, int> SegmentDataStorage;

    private string TrackSegmentData = "AB:AA:B:BAB:AA";
    private char currentChar;
    //private string currentString;
    //private string nextString;
    private char nextChar;
    private string currentCharConvertedToString;
    private string nextCharConvertedToString;
    private string pairedString;
    private string addingToDictionary;


    // Use this for initialization
    void Start()
    {
        SegmentDataStorage = new Dictionary<string, int>();
    }

    void doThisShit()
    {
        //StringBuilder sb = new StringBuilder();
        //List<string> markovTextListStore = new List<string>();
        //bool hasFirstValue = false;

        for (int i = 0; i < TrackSegmentData.Length - 1; i++)
        {

            //foreach (char c in TrackSegmentData)
            //{
            //    if (c != ',')
            //    {
            //        sb.Append(c);
            //    }
            //    else if (c == ':' && !hasFirstValue)
            //    {
            //        markovTextListStore.Add(sb.ToString().Trim());
            //        //sb.Clear();
            //        hasFirstValue = true;
            //    }
            //    else if (c == ':' && hasFirstValue)
            //    {
            //    }

            currentChar = TrackSegmentData[i];
            nextChar = TrackSegmentData[i + 1];
            currentCharConvertedToString = currentChar.ToString();
            nextCharConvertedToString = nextChar.ToString();
            pairedString = currentCharConvertedToString + nextCharConvertedToString;

            if (SegmentDataStorage.ContainsKey(pairedString))
            {
                SegmentDataStorage[pairedString] += 1;
            }

            if (!SegmentDataStorage.ContainsKey(pairedString))
            {
                SegmentDataStorage.Add(pairedString, 1);
            }
        }

        foreach (KeyValuePair<string, int> kvp in SegmentDataStorage)
        {
            Debug.Log(kvp.Key);
            Debug.Log(kvp.Value);
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            doThisShit();
        }

    }
}