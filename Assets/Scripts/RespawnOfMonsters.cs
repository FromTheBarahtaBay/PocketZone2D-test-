using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RespawnOfMonsters : MonoBehaviour
{
    [SerializeField] private GameObject _monsterToRespawn;
    private Tilemap _areaForRespawn;
    GameObject[] monsterForSpawn;

    private void Awake()
    {
        _areaForRespawn = GameObject.FindGameObjectWithTag("RespawnArea").GetComponent<Tilemap>();
        monsterForSpawn = new GameObject[3];
    }

    private void Start()
    {
        if (!_monsterToRespawn || !_areaForRespawn) return;

        List<Vector3Int> existTiles = new List<Vector3Int>();

        foreach (var e in _areaForRespawn.cellBounds.allPositionsWithin)
            if (_areaForRespawn.HasTile(e)) existTiles.Add(e);

        for (int i = 0; i < monsterForSpawn.Length; i++)
        {
            int random = Random.Range(0, existTiles.Count-1);
            monsterForSpawn[i] = Instantiate(_monsterToRespawn, _areaForRespawn.CellToWorld(existTiles[random]), transform.rotation);
        }
            
        print("SpawnIsComplited!");        
    }
}