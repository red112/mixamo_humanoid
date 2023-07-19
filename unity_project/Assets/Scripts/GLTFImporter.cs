using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Single thread
using Siccity.GLTFUtility;

public class GLTFImporter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadGLTF()
    {
        string file_path = "C:\\Study\\GLTF_Samples\\Duck.glb";
        GameObject result = Importer.LoadFromFile(file_path);

        result.transform.SetParent(this.transform);
    }

}
