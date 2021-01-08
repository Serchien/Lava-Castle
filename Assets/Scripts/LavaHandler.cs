using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class LavaHandler : MonoBehaviour
{
    [SerializeField] Tile lavaTile = null;
    Tilemap lavaGrid;

    [SerializeField] float speedInterval = 2;
    [SerializeField] int ascensionHeight = 1;

    [Header("Bounds of Lava")]
    [SerializeField] int maxYPosition = 6;
    [SerializeField] int minXPosition = -2;
    [SerializeField] int maxXPosition = 20;


    [SerializeField] int currentHeight = 1;

    [SerializeField] Transform lavaLight = null;



    // Start is called before the first frame update
    void Start()
    {
        lavaGrid = GetComponent<Tilemap>();

        //lavaGrid.BoxFill(new Vector3Int(0, 0, 0), lavaTile, minXPosition, 0, maxXPosition, 50);

        StartCoroutine(LavaAscension());
    }

    IEnumerator LavaAscension()
    {

        //Debug.Log("hello !?");
        while(currentHeight < maxYPosition)
        {
            yield return new WaitForSeconds(speedInterval);

            lavaGrid.size = new Vector3Int(24, currentHeight + ascensionHeight, 0);
            //lavaGrid.size = new Vector3Int(24, 10, 0);
            lavaGrid.BoxFill(new Vector3Int(0, currentHeight, 0), lavaTile, minXPosition, currentHeight, maxXPosition, currentHeight + ascensionHeight - 1);
            //lavaGrid.BoxFill(new Vector3Int(0,2,0), lavaTile, minXPosition, 2, maxXPosition, 4);
            lavaLight.position = new Vector2(0, lavaLight.position.y + ascensionHeight);
            currentHeight += ascensionHeight;

        }


    }

    void StartInterval()
    {
        StartCoroutine(LavaAscension());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
