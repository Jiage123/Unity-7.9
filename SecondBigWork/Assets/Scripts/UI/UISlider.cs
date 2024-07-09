using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISlider : MonoBehaviour
{
    Slider slider;
    public AudioSource au;
    public Toggle toggle;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        au = au.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        au.volume = slider.value;
        au.mute = toggle.isOn;
    }
}
