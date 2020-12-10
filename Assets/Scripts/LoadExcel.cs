  
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System.Net;
using System.Text;
// using Newtonsoft.Json;

public class LoadExcel : MonoBehaviour
{   
    string csv;
    public List<string[]> csvDatas;
    StringReader reader;
    string csvFileName = "【VAS2021】出展者一覧と入稿ファイル名1124";
    string listname = "boothlist";
    string item1 = "";


	public void LoadJSON(){
        int k = 0;
        ///csv = Resources.Load (OpenFile.path) as TextAsset;
        csv = File.ReadAllText (OpenFile.path);
        print(OpenFile.path);
        print(csv);
		reader = new StringReader (csv);
		csvDatas = new List<string[]> ();
        JsonObject jsonObject = new JsonObject();
        var lineCount = 0;
        while (reader.ReadLine() != null)
       {
           lineCount++;
       }
        jsonObject.boothlist = new Item[lineCount];
        StringReader reader2 = new StringReader(csv);
        var lineCount2 = 0;
        print("KOKOKOKOKOKOK");
        print(reader.Peek ());
		while (reader2.Peek () > -1) {
			string line = reader2.ReadLine ();
			csvDatas.Add (line.Split (','));
               // if(lineCount2 + 1 <= lineCount){
                Item boothitem = new Item();
                boothitem.boothNo =  csvDatas[lineCount2][0];
                boothitem.boothName = csvDatas[lineCount2 ][1];
                boothitem.boothNameKana = csvDatas[lineCount2 ][2];
                boothitem.boothDisplayName = csvDatas[lineCount2 ][3];
                boothitem.boothDisplayNameKana = csvDatas[lineCount2 ][4];
                boothitem.boothSpawnName = "boothSpawnName" + csvDatas[lineCount2 ][0];
                if(lineCount2 != 0){
                jsonObject.boothlist[lineCount2 - 1] = boothitem;
                lineCount2++;
                }else{
                lineCount2++;
                }

        }
        string serialisedItemJson = JsonUtility.ToJson(jsonObject);
        print(serialisedItemJson);
        string filePath = "PlayerDataInstance.json";
        var path =  Application.dataPath + "/" + filePath;
        print(path);
        var writer = new StreamWriter (path, true); // 上書き
        writer.WriteLine (serialisedItemJson);
        writer.Flush ();
        writer.Close ();
    }
}