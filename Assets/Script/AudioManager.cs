using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioS;
    public AudioClip sound1;

    private static AudioManager s_instance=null;

    // Start is called before the first frame update
    void Start()
    {
        if(s_instance)
        {
            DestroyImmediate(this.gameObject);
            return;
        }

        s_instance= this;
        DontDestroyOnLoad(this.gameObject);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound()
    {
        audioS.PlayOneShot(sound1);
    }
}
