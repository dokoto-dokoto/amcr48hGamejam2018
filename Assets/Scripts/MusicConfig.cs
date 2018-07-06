using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicConfig : MonoBehaviour {

	public static float _bgmVolume = 1;
	public static float _seVolume = 1;

    [SerializeField]
    private AudioMixer audioMixer;

    public Text _bgm;
    public Text _se;

    public Slider bgmSlider;
    public Slider seSlider;

    private void Start()
    {
        _bgm.text = 80.ToString();
        _se.text = 80.ToString();
    }

    public void SetMaster(float volume)
    {
        audioMixer.SetFloat("MasterVol", volume);
    }

    public void SetBGM(float volume)
    {
        audioMixer.SetFloat("BGMVol", volume);
    }

    public void SetSE(float volume)
    {
        audioMixer.SetFloat("SEVol", volume);
    }

    public void ChangeVolume_BGM()
    {
        _bgmVolume = bgmSlider.value;
        _bgm.text = ((int)(bgmSlider.value - bgmSlider.minValue) * 2).ToString();
    }

    public void ChangeVolume_SE()
    {
        _seVolume = seSlider.value;
        _se.text = ((int)(seSlider.value - seSlider.minValue) * 2).ToString();
    }
}
