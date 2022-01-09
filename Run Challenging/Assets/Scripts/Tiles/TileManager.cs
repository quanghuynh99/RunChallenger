using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    //midi 
    public GameObject[] awardPrefabs;





    private List<GameObject> activeTiles;
    public GameObject[] tilePrefabs;

    public float tileLength = 30;
    public int numberOfTiles = 3;
    public int totalNumOfTiles = 8;

    public float zSpawn = 0;

    private Transform playerTransform;

    private int previousIndex;

    void Start()
    {
        activeTiles = new List<GameObject>();
        for (int i = 0; i < numberOfTiles; i++)
        {
            if(i==0)
                SpawnTile();
            else
                SpawnTile(Random.Range(0, totalNumOfTiles));
        }

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

    }
    void Update()
    {
        if(playerTransform.position.z - 30 >= zSpawn - (numberOfTiles * tileLength))
        {
            int index = Random.Range(0, totalNumOfTiles);
            while(index == previousIndex)
                index = Random.Range(0, totalNumOfTiles);

            DeleteTile();
            SpawnTile(index);
        }
            
    }

    public void SpawnTile(int index = 0)
    {
        GameObject tile = tilePrefabs[index];
        if (tile.activeInHierarchy)
            tile = tilePrefabs[index + 8];

        if(tile.activeInHierarchy)
            tile = tilePrefabs[index + 16];

        tile.transform.position = Vector3.forward * zSpawn;
        tile.transform.rotation = Quaternion.identity;
        tile.SetActive(true);

        activeTiles.Add(tile);
        zSpawn += tileLength;
        previousIndex = index;
    }

    private void DeleteTile()
    {
        activeTiles[0].SetActive(false);
        activeTiles.RemoveAt(0);
        PlayerManager.score += 3;
    }
    /// ramdom midi file 
	public void SpwanAward(int awardIndex)
    {
        const string path = "Assets/Audio/Midi Road.mid";
        float TimeNoteOn;
        float Z;
        MidiFile midiFile = new MidiFile(path);
        foreach (var track in midiFile.Tracks)
        {
            foreach (var midiEvent in track.MidiEvents)
            {
                if (midiEvent.MidiEventType == MidiEventType.NoteOn)
                {
                    TimeNoteOn = midiEvent.Time;
                    Z = midiEvent.Time * 0.12f;
                    Instantiate(awardPrefabs[awardIndex], transform.position = new Vector3(Random.Range(0, 2), 1.23f, Z), awardPrefabs[awardIndex].transform.rotation);
                }
            }
        }

    }
}
