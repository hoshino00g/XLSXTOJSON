  
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System.Net;
using System.Text;
using System.Linq;
using System;
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
    int lineCount;

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
        lineCount = 0;
        while (reader.ReadLine() != null)
       {
           lineCount++;
       }
        jsonObject.boothlist = new Item[lineCount - 1];
        StringReader reader2 = new StringReader(csv);
		while (reader2.Peek() > -1) {
			string line = reader2.ReadLine ();
            // Debug.Log(line + "OPOP");
          //  if(line.IndexOf("小間番号,出展会社名,出展会社名カナ,表示名,表示名カナ") == -1){
			csvDatas.Add (line.Split (','));//指定された文字列の要素で区切られた部分文字列を格納する文字列配列を返します
          //  Debug.Log("fjasfjdkasjdfklasjfOPOP");
          //  }
        }
       // csvDatas.Sort((a,b) => int.Parse(a[0]) - int.Parse(b[0]));

        for(int lineCount2 = 1; lineCount2 <= csvDatas.Count　- 1; lineCount2++){
               // if(lineCount2 + 1 <= lineCount){
                Item boothitem = new Item();
                boothitem.boothNo =  csvDatas[lineCount2][0];
                boothitem.boothName = csvDatas[lineCount2 ][1];
                boothitem.boothNameKana = csvDatas[lineCount2 ][2];
                boothitem.boothDisplayName = csvDatas[lineCount2 ][3];
                boothitem.boothDisplayNameKana = csvDatas[lineCount2 ][4];
                boothitem.boothSpawnName = csvDatas[lineCount2 ][0]  + "_SpawnPoint";
                // if(lineCount2 != 0){
                jsonObject.boothlist[lineCount2 - 1] = boothitem;
                Debug.Log(lineCount2 + "ああああああ" +boothitem.boothNo);
                // }else{
                // lineCount2++;
                // }
        }

        //jsonObject.boothlist.Sort((a,b) => int.Parse(a[0]) - int.Parse(b[0]));
        IComparer wordComp = new WordComparer();
       // Item[] lists = jsonObject.boothlist;
        //lists.Sort((a,b) => a.boothNo - b.boothNo);
        Array.Sort(jsonObject.boothlist, wordComp);
        string serialisedItemJson = JsonUtility.ToJson(jsonObject);
        Debug.Log(serialisedItemJson);
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

    // static int ComArr(){

    // }

}

public class WordComparer: IComparer {
  public int Compare(object x, object y) {
      Item x_i = (Item)x;
      Item y_i = (Item)y;

      Debug.Log(x_i.boothNo);
      Debug.Log(x);
      Debug.Log(y_i.boothNo);
      Debug.Log(y);
      int x_num = int.Parse(x_i.boothNo);
      int y_num = int.Parse(y_i.boothNo);


    return x_num - y_num;
  }
}