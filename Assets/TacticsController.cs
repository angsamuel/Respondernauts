using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TacticsController : MonoBehaviour {
    public GameObject tile;
    public GameObject exit;
    public Camera cam;

    //pixels per unit and scale, needed for camera 
    public float ppuScale = 1f;
    public int ppu = 32;

    public Color baseColor;

    //Level Infos
    public int levelHeight;
    public int levelWidth;
    float offsetX;
    float offsetY;
    List<Vector2> coords;

    //camera zoom boundaries
    private float cameraCurrentZoom;
    private float cameraZoomMax;
    public float cameraZoomMin = 0;
    //used to view currentCameraZoom without changing it
    public float czm;

    //cuts camera semsitivity, should be adjustable in the future
    public float originalCameraSpeedCutBy = 10f;
    public float cameraSpeedCutBy;

    //number of rows and columns in the level grid
    private int mapRows;
    private int mapCols;


    //Storage
    GameObject[] tileGrid;
    GameObject[] environmentGrid;

    void Awake()
    {
        coords = new List<Vector2>();
        tileGrid = new GameObject[0];
        environmentGrid = new GameObject[0];

    }

    // Use this for initialization
    void Start () {
        GenerateLevel();
        //calculate maximum camera zoom //Orthographic size = ((Vert Resolution)/(PPUScale * PPU)) * 0.5
        cameraCurrentZoom = ((Screen.height) / (ppuScale * 32)) * 0.5000f;
        cameraZoomMax = cameraCurrentZoom / 2;
        cameraCurrentZoom = cameraZoomMax;
        Camera.main.orthographicSize = cameraCurrentZoom;

        //make the camera less sensitive as we zoom in
        cameraSpeedCutBy = originalCameraSpeedCutBy * (cameraCurrentZoom / cameraZoomMax);

        //czm is for viewing only
        czm = cameraCurrentZoom;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxisRaw("Jump") != 0)
        {
            GenerateLevel();
        }
	}



    void GenerateLevel()
    {
        for(int i = 0; i < tileGrid.Length; i++)
        {
            Destroy(tileGrid[i]);
        }
        tileGrid = new GameObject[levelWidth * levelHeight];
        // baseColor = Color.Lerp(baseDark, baseLight, Random.Range(0.0f, 1.0f));
        float r = Random.Range(.0f, .1f);
        float g = Random.Range(.0f, .1f);
        float b = Random.Range(.0f, .1f);
        float a = 1.80f;
        baseColor = new Color(r, b, g, a);

        //determine offset
        offsetX = levelWidth / 2f;
        offsetY = levelHeight / 2f;
        if (levelWidth % 2 == 1)
        {
            offsetX -= .5f;
        }
        if (levelHeight % 2 == 1)
        {
            offsetY -= .5f;
        }

        tileGrid = new GameObject[levelWidth * levelHeight];
        for (int y = 0; y < levelHeight; y++)
        {
            for (int x = 0; x < levelWidth; x++)
            {
                GameObject spawnedTile = Instantiate(tile, new Vector3(x - offsetX, y - offsetY, 100), Quaternion.identity) as GameObject;

                spawnedTile.GetComponent<SpriteRenderer>().color = baseColor;

                
                float change = Random.Range(-0.01f, 0.01f);
                float red = spawnedTile.GetComponent<SpriteRenderer>().color.r + change;
                float green = spawnedTile.GetComponent<SpriteRenderer>().color.g + change;// + Random.Range(0.05f, 0.1f);
                float blue = spawnedTile.GetComponent<SpriteRenderer>().color.b + change;// + Random.Range(0.05f, 0.1f);
                float alpha = spawnedTile.GetComponent<SpriteRenderer>().color.a;
                spawnedTile.GetComponent<SpriteRenderer>().color = Color.Lerp(new Color(red, green, blue, alpha), Color.white, .1f);
                
                 cam.backgroundColor = new Color(baseColor.r, baseColor.g, baseColor.b);
                tileGrid[y * levelWidth + x] = spawnedTile;
            }
        }

    }


    public int GetLevelHeight()
    {
        return levelHeight;
    }
    public int GetLevelWidth()
    {
        return levelWidth;
    }
}
