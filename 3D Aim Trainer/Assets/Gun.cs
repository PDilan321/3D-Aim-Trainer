using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gun : MonoBehaviour
{
    //public AddScore _AddScore;
    AudioSource GunShot; // Referencing the gun shot audio
    public GameObject MuzzlePrefab; // Referencing the actual muzzle flash animation
    public GameObject MuzzlePosition; // Referencing the muzzle flash position
    public Camera FpsCam;

    public Vector3 originalPosition;
    public Vector3 aimingPosition;
    public float adsSpeed = 0;
    public string BulletHit;

    //public float xMinRange = -40.0f;
    //public float xMaxRange = 40.0f;
    //public float yMinRange = 6.0f;
    //public float yMaxRange = 55.0f;
    //public float zRange = 16.63f;

    public float xMinRange = -41.56f;
    public float xMaxRange = 40.8f;
    public float yMinRange = 30.3f;
    public float yMaxRange = 73.7f;
    public float zRange = 16.63f;

    public GameObject CubeToSpawn;
    public GameObject CubeToSpawn1; 
    public GameObject CubeToSpawn2;

    public int Score;
    public Text TextScore;

    public float scoreAmount;
    public float IncreasePerSecond = 1f;

    public GameObject Cube;
    public GameObject Cube1;
    public GameObject Cube2;

    public AddScore _AddScore;
    public TimerController _TimeController; // Making a reference to the TimerController script

    void Start()
    {
        GunShot = GetComponent<AudioSource>();
        GunShot.volume = PlayerPrefs.GetFloat("Sound");
    }
    // Update is called once per frame
    void Update()
    {
        if (_TimeController.TheGameIsFrozen == true)
        {

        }
        else
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot(); // Shoots a bullet
                GunShot.Play(); // Plays GunShot (audio)
                var flash = Instantiate(MuzzlePrefab, MuzzlePosition.transform);

            }
            if (Input.GetMouseButton(1) || Input.GetKey(KeyCode.Joystick1Button6))
            {
                transform.localPosition = Vector3.Slerp(transform.localPosition, aimingPosition, Time.deltaTime * adsSpeed); // slerp function is used to smoothly transition from one place to another
                FpsCam.fieldOfView = 37f;

            }
            else
            {
                transform.localPosition = Vector3.Slerp(transform.localPosition, originalPosition, adsSpeed * Time.deltaTime); // Moving back to the original position if not pressed
                FpsCam.fieldOfView = 57f;
            }
           
        }
    }
    public void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(FpsCam.transform.position, FpsCam.transform.forward, out hit)) // Shoots a ray when the left click on the mouse is pressed
        {
            if (hit.transform.name == "Tile") // Checking whatever the ray has hit has the name "Cube"
            {
                //GameObject WhatToMove = CubeToSpawn; // Create a gameobject and make equal to the CubeToSpawn which is originally coded in the inspector
                //MakeThingToSpawn(WhatToMove); // Calling the funcion 'MakeThingToSpawn' and passing in the game object created above
                //WhereHit(WhatToMove, hit.point); // Calling the function 'WhereHit' and passing in the game object 'WhatToMove' and the hitpoint as parameters
                BonusScore(CubeToSpawn.transform.position, hit.point);
                MakeThingToSpawn(CubeToSpawn);

            }
            if (hit.transform.name == "Tile (1)")
            {
                //GameObject WhatToMove = CubeToSpawn1;
                //MakeThingToSpawn(WhatToMove);
                //Debug.Log(hit.point);
                //_AddScore.AddScoreForTileGame();
                //WhereHit(Cube1, hit.point);
                BonusScore(CubeToSpawn1.transform.position, hit.point);
                MakeThingToSpawn(CubeToSpawn1);
            }
            if (hit.transform.name == "Tile (2)")
            {

                //Debug.Log(hit.point);
                //_AddScore.AddScoreForTileGame();
                //WhereHit(Cube2, hit.point);
                BonusScore(CubeToSpawn2.transform.position, hit.point);
                MakeThingToSpawn(CubeToSpawn2);
            }
            _AddScore.ShotRegistered += 1;

        }

        // If bullet == the target, produce a sound, check where the bullet hit the target, calculate score, add to total, increment total hit, check whether total hit % 3 == 0. If so then spawn another

    }
    void MakeThingToSpawn(GameObject WhatToMove)
    {
        Vector3 spawnPosition;

        // get a random position between the specified ranges
        spawnPosition.x = Random.Range(xMinRange, xMaxRange);
        spawnPosition.y = Random.Range(yMinRange, yMaxRange);
        spawnPosition.z = zRange;

        // actually spawn the game object
        WhatToMove.transform.position = new Vector3(spawnPosition.x, spawnPosition.y, spawnPosition.z);
    }
    void BonusScore(Vector3 WhichCube, Vector3 HitPoint)
    {
        Vector2 newWhichCube = new Vector2(WhichCube.x, WhichCube.y); // Creating 2D Vectors with the x and y coords
        Vector2 newHitPoint = new Vector2(HitPoint.x, HitPoint.y);
        Debug.Log(newWhichCube);
        Debug.Log(newHitPoint);
        var Dis = Vector2.Distance(newWhichCube, newHitPoint);
        Debug.Log(Dis);
        if (Dis < 5)
        {
            _AddScore.Score += 2;
            _AddScore.AccurateTargetHit += 1;
            
            Debug.Log("Nice!");
        }
        _AddScore.AddScoreForTileGame();
        _AddScore.TargetHit += 1;
    }
    

}