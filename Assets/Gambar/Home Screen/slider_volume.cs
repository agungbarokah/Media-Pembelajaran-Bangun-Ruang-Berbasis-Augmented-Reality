using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class slider_volume : MonoBehaviour
{
    public Slider sliderVolume;
    // Start is called before the first frame update
    void Start()
    {
        sliderVolume.value = sound_manager.Instance.music.volume;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Slidervolume()
    {
        sound_manager.Instance.music.volume = sliderVolume.value;
    }
}
