using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip destroyBlockSnd;
    public AudioClip placeBlockSnd;


    void PlayDestroySnd()
    {
        GetComponent<AudioSource>().PlayOneShot(destroyBlockSnd);
    }
    void PlayPlaceSnd()
    {
        GetComponent<AudioSource>().PlayOneShot(placeBlockSnd);
    }

    void OnEnable()
    {
        VoxelChunk.OnEventDestroy += PlayDestroySnd;
        VoxelChunk.OnEventPlace += PlayPlaceSnd;
    }

     void OnDisable()
    {
        VoxelChunk.OnEventDestroy -= PlayDestroySnd;
        VoxelChunk.OnEventPlace -= PlayPlaceSnd;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
