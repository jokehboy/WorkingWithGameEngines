using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip destroyBlockSnd;
    public AudioClip placeBlockSnd;
    public AudioClip pickupSnd;

    public AudioClip placeGrass;
    public AudioClip destGrass;

    public AudioClip placeDirt;
    public AudioClip destDirt;

    public AudioClip placeSand;
    public AudioClip destSand;

    public AudioClip placeStone;
    public AudioClip destStone;


    void PlayDestroySnd()
    {
        GetComponent<AudioSource>().PlayOneShot(destroyBlockSnd);
    }
    void PlayPlaceSnd()
    {
        GetComponent<AudioSource>().PlayOneShot(placeBlockSnd);
    }

    void PlayPickUpNoise()
    {
        GetComponent<AudioSource>().PlayOneShot(pickupSnd);

    }

    void PlayGrassPlace()
    {
        GetComponent<AudioSource>().PlayOneShot(placeGrass);
    }
    void PlayGrassDestroy()
    {
        GetComponent<AudioSource>().PlayOneShot(destGrass);
    }
    void PlayDirtPlace()
    {
        GetComponent<AudioSource>().PlayOneShot(placeDirt);
    }
    void PlayDirtDestroy()
    {
        GetComponent<AudioSource>().PlayOneShot(destDirt);
    }
    void PlaySandPlace()
    {
        GetComponent<AudioSource>().PlayOneShot(placeSand);
    }
    void PlaySandDestroy()
    {
        GetComponent<AudioSource>().PlayOneShot(destSand);
    }
    void PlayStonePlace()
    {
        GetComponent<AudioSource>().PlayOneShot(placeStone);
    }
    void PlayStoneDestroy()
    {
        GetComponent<AudioSource>().PlayOneShot(destStone);
    }

    void OnEnable()
    {
        VoxelChunk.OnEventDestroy += PlayDestroySnd;
        VoxelChunk.OnEventPlace += PlayPlaceSnd;
        BlockDropping.OnEventPick += PlayPickUpNoise;
        VoxelChunk.OnEventGrassPlaced += PlayGrassPlace;
        VoxelChunk.OnEventGrassDestroyed += PlayGrassDestroy;
        VoxelChunk.OnEventDirtPlaced += PlayDirtPlace;
        VoxelChunk.OnEventDirtDestroyed += PlayDirtDestroy;
        VoxelChunk.OnEventSandPlaced += PlaySandPlace;
        VoxelChunk.OnEventSandDestroyed += PlaySandDestroy;
        VoxelChunk.OnEventStonePlaced += PlayStonePlace;
        VoxelChunk.OnEventStoneDestroyed += PlayStoneDestroy;
        
        
    }

     void OnDisable()
    {
        VoxelChunk.OnEventDestroy -= PlayDestroySnd;
        VoxelChunk.OnEventPlace -= PlayPlaceSnd;
        BlockDropping.OnEventPick -= PlayPickUpNoise;
        VoxelChunk.OnEventGrassPlaced -= PlayGrassPlace;
        VoxelChunk.OnEventGrassDestroyed -= PlayGrassDestroy;
        VoxelChunk.OnEventDirtPlaced -= PlayDirtPlace;
        VoxelChunk.OnEventDirtDestroyed -= PlayDirtDestroy;
        VoxelChunk.OnEventSandPlaced -= PlaySandPlace;
        VoxelChunk.OnEventSandDestroyed -= PlaySandDestroy;
        VoxelChunk.OnEventStonePlaced -= PlayStonePlace;
        VoxelChunk.OnEventStoneDestroyed -= PlayStoneDestroy;
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
