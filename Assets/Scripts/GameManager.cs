using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class allows camera switches between cubes.
/// </summary>
public class GameManager : MonoBehaviour
{
    // singleton of the class
    private static GameManager _instance;
    
    // data types to keep track of cubes
    [SerializeField] private GameObject[] cubes;
    [SerializeField] private List<Transform> cubeTransform;
    private int _currentCubeIndex;
    
    private Camera _camera;

    /// <summary>
    /// This function prevents duplicate instances of this class.
    /// </summary>
    private void Awake()
    {
        // checks if a duplicate instance exists
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    
    /// <summary>
    /// This function keeps track of all the cubes on the screen.
    /// </summary>
    private void Start()
    {
        _camera = Camera.main;
        
        // grabs all cubes on the screen
        cubes = GameObject.FindGameObjectsWithTag("Cube");

        // grabs all transforms of NPC players
        foreach (var cube in cubes)
        {
            cubeTransform.Add(cube.transform);
        }
    }

    /// <summary>
    /// This function checks for button presses.
    /// </summary>
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            CameraSwitch();
        }
    }

    /// <summary>
    /// This function switches camera to another cube.
    /// </summary>
    private void CameraSwitch()
    {
        // gets random instance of cube from list
        _currentCubeIndex = (_currentCubeIndex + 1) % cubeTransform.Count;
        
        // updates camera to position of cube with offset.
        _camera.transform.position = new Vector3(cubeTransform[_currentCubeIndex].position.x,
            cubeTransform[_currentCubeIndex].position.y, -5);
    }
}
