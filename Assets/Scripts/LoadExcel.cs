  
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
    public Text result_txt;
    public Text output_path;
    StreamWriter writer;
    string path;
    string path_demo = @"C:\Users\HoshinoHiroto\Desktop\aaa.csv";


	public void LoadJSON(){
        Debug.Log("LoadJSON");
        int k = 0;
        ///csv = Resources.Load (OpenFile.path) as TextAsset;
        //try{
        Debug.Log("ReadAllTest1");
        Debug.Log(path_demo);
        Debug.Log(@"" + OpenFile.path);
        Debug.Log(string.Format(@"{0}", OpenFile.path));
        #if UNITY_EDITOR
        csv = File.ReadAllText(string.Format(@"{0}", OpenFile.path));
        #endif

        #if !UNITY_EDITOR && UNITY_STANDALONE_WIN
        csv = File.ReadAllText(string.Format(@"{0}", OpenFile.path));
        //csv = File.ReadAllText(@""+ OpenFile.path);
        #endif
        Debug.Log("ReadAllTest2");
        Debug.Log(csv);
        // } catch(System.ArgumentException e){
        // result_txt.fontSize = 8;
        // result_txt.text = e.ToString();
        // output_path.text = OpenFile.path;
        // }
        Debug.Log("ReadAllTest3");
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
        print(serialisedItemJson);
        try{
        string filePath = "PlayerDataInstance.json";
        path =  Application.persistentDataPath + "/" + filePath;
        print(path);
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

    private static string ToLiteral(string input)
{
    using (var writer = new StringWriter())
    {
        using (var provider = System.CodeDom.Compiler.CodeDomProvider.CreateProvider("CSharp"))
        {
            provider.GenerateCodeFromExpression(new System.CodeDom.CodePrimitiveExpression(input), writer, null);
            return writer.ToString();
        }
    }
}
}