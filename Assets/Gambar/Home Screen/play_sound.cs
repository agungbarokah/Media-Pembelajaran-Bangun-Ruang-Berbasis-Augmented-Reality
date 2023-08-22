using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class play_sound : MonoBehaviour
{
    public AudioSource background_musik;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnMouseDown()
    {
        background_musik.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
