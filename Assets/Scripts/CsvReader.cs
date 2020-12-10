using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class CsvReader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReadCsv(){

        // using (var reader = new StreamReader(@"parts.csv", Encoding.UTF8))
        //     {
        //         var partsList = new List<string[]>();
        //         // 1行目はスキップ.
        //         reader.ReadLine();
                    
        //         while (reader.Peek() > -1)
        //         {
        //             var readText = reader.ReadLine();
        //             if (readText == null)
        //             {
        //                 continue;
        //             }
        //             var splitTexts = readText.Split(',');
        //             if (splitTexts.Length < 3)
        //             {
        //                 continue;
        //             }
        //             var newParts = new Parts
        //             {
        //                 PartsNo = splitTexts[0],
        //                 PartsName = splitTexts[1],
        //                 Description = splitTexts[2],
        //             };
        //             partsList.Add(newParts);
        //         }
        //     }
    }
}
