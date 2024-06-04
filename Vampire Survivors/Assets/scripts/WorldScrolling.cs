using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldScrolling : MonoBehaviour{
    [SerializeField] Transform PlayerTransform;
    Vector2Int currentTilePosition = new Vector2Int(0,0);
    [SerializeField] Vector2Int PlayerTilePosition;
    Vector2Int onTileGridPlayerPosition;
    [SerializeField] float tileSize = 20f;
    GameObject[,] terrainTiles;

    [SerializeField] int terrainTileHorizontalCount;
    [SerializeField] int terrainTileVerticalCount;

    [SerializeField] int fieldOfVisionHeight = 3;
    [SerializeField] int fieldOfVisionWidth = 3;

    private void Awake(){
        terrainTiles = new GameObject[terrainTileHorizontalCount, terrainTileVerticalCount];
    }

    private void Start(){
        UpdateTilesOnScreen();
    }

    private void Update(){
        PlayerTilePosition.x = (int)(PlayerTransform.position.x/tileSize);
        PlayerTilePosition.y = (int)(PlayerTransform.position.y/tileSize);

        PlayerTilePosition.x -= PlayerTransform.position.x < 0 ? 1 : 0;
        PlayerTilePosition.y -= PlayerTransform.position.y < 0 ? 1 : 0;
        
        if(currentTilePosition != PlayerTilePosition){
            currentTilePosition = PlayerTilePosition;

            onTileGridPlayerPosition.x = CalculatePositionOnAxis(onTileGridPlayerPosition.x, true);
            onTileGridPlayerPosition.y = CalculatePositionOnAxis(onTileGridPlayerPosition.y, false);
            UpdateTilesOnScreen();
        }
    }

    private void UpdateTilesOnScreen(){
        for(int pov_x = -(fieldOfVisionWidth/2) ; pov_x <= fieldOfVisionWidth/2 ; pov_x++){
            for(int pov_y = -(fieldOfVisionHeight/2) ; pov_y <= fieldOfVisionHeight/2 ; pov_y++){
                int tileToUpdate_x = CalculatePositionOnAxis(PlayerTilePosition.x + pov_x, true);
                int tileToUpdate_y = CalculatePositionOnAxis(PlayerTilePosition.y + pov_y, false);

                GameObject tile = terrainTiles[tileToUpdate_x, tileToUpdate_y];
                tile.transform.position = CalculateTilePosition(PlayerTilePosition.x + pov_x, PlayerTilePosition.y + pov_y);
            }
        }
    }

    private Vector3 CalculateTilePosition(int x, int y){
        return new Vector3(x * tileSize, y * tileSize, 0f);
    }

    private int CalculatePositionOnAxis(float currentValue, bool horizontal){
        if(horizontal){
            if(currentValue >= 0){
                currentValue = currentValue % terrainTileHorizontalCount;
            }
            else{
                currentValue += 1;
                currentValue = terrainTileHorizontalCount -1 
                + currentValue % terrainTileHorizontalCount;
            }
        }
        else{
            if(currentValue >= 0){
                currentValue = currentValue % terrainTileVerticalCount;
            }
            else{
                currentValue += 1;
                currentValue = terrainTileVerticalCount - 1
                + currentValue % terrainTileVerticalCount;
            }
        }

        return (int)currentValue;
        
    }

    public void Add(GameObject tileGameObject, Vector2Int tilePosition){
        terrainTiles[tilePosition.x, tilePosition.y] = tileGameObject;
    }
}