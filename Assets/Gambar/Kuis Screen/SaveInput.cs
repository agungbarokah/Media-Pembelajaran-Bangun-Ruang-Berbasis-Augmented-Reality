using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveInput : MonoBehaviour
{
    public InputField input_nama, input_kelas;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void simpan_input()
    {
        PlayerPrefs.SetString("nama", input_nama.text);
        PlayerPrefs.SetString("kelas", input_kelas.text);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
