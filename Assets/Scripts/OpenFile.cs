using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using SFB;

public class OpenFile : MonoBehaviour
{
    public static string path;
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
        path = StandaloneFileBrowser.OpenFilePanel("Open File", "", extensions, true);
        #endif
    }
}
