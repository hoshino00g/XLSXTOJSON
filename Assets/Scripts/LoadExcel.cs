  
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
    

 
    public Text result_txt;
    public Text output_path;
    StreamWriter writer;
    string path;
    string path_demo = "C:\\Users\\HoshinoHiroto\\Desktop\\aaa.csv";

    public void Start(){
    }

	public void LoadJSON(){
        string path_k = OpenFile.path.Replace(@"/", @"\");
        #if UNITY_EDITOR
        csv = File.ReadAllText(OpenFile.path);
        #endif

        #if !UNITY_EDITOR && UNITY_STANDALONE_WIN
        csv = File.ReadAllText(OpenFile.path);
        #endif

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
                boothitem.boothSpawnName = csvDatas[lineCount2 ][0]  + "_SpawnPoint";
                if(lineCount2 != 0){
                jsonObject.boothlist[lineCount2 - 1] = boothitem;
                lineCount2++;
                }else{
                lineCount2++;
                }

        }
        string serialisedItemJson = JsonUtility.ToJson(jsonObject);
        try{
        string filePath = "PlayerDataInstance.json";
        path =  Application.persistentDataPath + "/" + filePath;
        writer = new StreamWriter (path, true); // 上書き
        writer.WriteLine (serialisedItemJson);
        writer.Flush ();
        writer.Close ();
        }
        catch(System.ArgumentException e){
        result_txt.text = e.ToString();
        output_path.text = path;
        }
      
        result_txt.text = "Succeed!!";
        output_path.text = path;
     

    }
}