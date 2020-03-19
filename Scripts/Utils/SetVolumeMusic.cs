using UnityEngine;
using UnityEngine.Audio;

namespace UI.Volume
{
    public class SetVolumeMusic : MonoBehaviour
    {
        public AudioMixer songMixer;
    
        public void SetLevelSong (float sliderValue)
        {
            songMixer.SetFloat("SongVol", Mathf.Log10(sliderValue) * 20);
        }
    }
}
