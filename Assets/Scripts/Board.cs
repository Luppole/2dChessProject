using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] public int _width, _height;
 
    [SerializeField] private Grid _tilePrefab;
 
    [SerializeField] private Transform _cam;
 
    private Dictionary<Vector2, Grid> _tiles;
    
    void Start() {
        GenerateGrid();
    }
 
    void GenerateGrid() {
        
        _tiles = new Dictionary<Vector2, Grid>();
        for (int x = 0; x < _width; x+=2) {
            for (int y = 0; y < _height; y+=2) {
                var spawnedTile = Instantiate(_tilePrefab, new Vector3(x, y), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";
 
                var isOffset = (x % 4 == 0 && y % 4 != 0) || (x % 4 != 0 && y % 4 == 0);
                spawnedTile.Init(isOffset);
 
 
                _tiles[new Vector2(x, y)] = spawnedTile;
            }
        }
 
        _cam.transform.position = new Vector3((float)_width/2 -1f, (float)_height / 2 - 1f,-10);
    }
 
    public Grid GetTileAtPosition(Vector2 pos) {
        if (_tiles.TryGetValue(pos, out var tile)) return tile;
        return null;
    }
}