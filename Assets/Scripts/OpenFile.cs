using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using SFB;

public class OpenFile : MonoBehaviour
{
    public static string path;
    public Text filepath;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnFileOpen(){

        #if UNITY_EDITOR
         path = EditorUtility.OpenFilePanel("Open csv", "", "CSV");
         Debug.Log(path);
        #endif

        #if !UNITY_EDITOR && UNITY_STANDALONE_WIN
        var extensions = new [] {
        new ExtensionFilter("Open CSV", "csv")
        };
        WriteResult(StandaloneFileBrowser.OpenFilePanel("Open File", "", extensions, true));
        #endif
        filepath.text = path;
    }

    public void WriteResult(string[] paths) {
        if (paths.Length == 0) {
            return;
        }

        path = "";
        foreach (var p in paths) {
            path += p;//ここに\nがあったのを消した。
        }
    }
    
}
