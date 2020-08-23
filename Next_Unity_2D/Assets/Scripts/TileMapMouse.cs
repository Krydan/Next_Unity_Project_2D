﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapMouse : MonoBehaviour {

    //Tilemaps
    private Tilemap tilemapGround;
    private Tilemap tilemapHighlight;

    //Tiles
    public TileBase highlightGroundTile;
    public TileBase groundTile;

    //Other
    Vector3Int prevGridPos;
    bool highlightPlaced;

    private void Start() {
        tilemapGround = GameObject.Find("TileMap_GroundPieces").GetComponent<Tilemap>();
        tilemapHighlight = GameObject.Find("TileMap_GroundPiecesHighlight").GetComponent<Tilemap>();
    }

    // Update is called once per frame
    void Update() {

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int gridPos = tilemapGround.WorldToCell(mousePos);
        highlightPlaced = tilemapHighlight.HasTile(gridPos);

        //Removing HL from previously hovered tile
        if (prevGridPos != null && prevGridPos != gridPos) {
            tilemapHighlight.SetTile(prevGridPos, null);
        }

        //Adding HL tile to currently hovered tile if current hover has tile and there's no HL placed.
        if (tilemapGround.HasTile(gridPos) && highlightPlaced == false) {
            tilemapHighlight.SetTile(gridPos, highlightGroundTile);
            prevGridPos = gridPos;
        } 
    }
}