using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SoundLibrary : MonoBehaviour
{
    public AudioClip[] _sfxList;
    public static Dictionary<string ,AudioClip> sfxLibrary = new Dictionary<string, AudioClip>();
    
    void Awake() {
        _sfxList = Resources.LoadAll("SFX" , typeof(AudioClip)).Cast<AudioClip>().ToArray(); // load all of sfx in resources folder ( thats why this folder is called resources )
        for (int i = 0; i < _sfxList.Length; i++){
            sfxLibrary.Add(_sfxList[i].name ,_sfxList[i]);
        }
    }

}
