using UnityEngine;

/// <summary>
/// This class defines the features of the cube class.
/// </summary>
public class CubeBase : MonoBehaviour
{
        [SerializeField] protected float rotateSpeed;
        [SerializeField] protected Camera mainCamera;

        /// <summary>
        /// This function sets the rotation speed and main camera.
        /// </summary>
        protected virtual void Start()
        {
            rotateSpeed = 10f;
            mainCamera = Camera.main;
        }

        /// <summary>
        /// This function checks mouse button clicks.
        /// </summary>
        protected virtual void Update()
        {
            // check if left mouse button is down
            if (Input.GetMouseButton(0))
            {
                Rotate();
            }
        }

        /// <summary>
        /// This function checks and rotates selected target cube.
        /// </summary>
        protected virtual void Rotate()
        {
            // grabs mouse click location
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(ray, out hit))
            {
                // checks if raycast target matches current object
                if (hit.collider.gameObject == gameObject)
                {
                    // grabs direction of mouse drag
                    var mouseX = Input.GetAxis("Mouse X");
                    var mouseY = Input.GetAxis("Mouse Y");
            
                    // updates cube rotation with mouse drag direction
                    transform.Rotate(Vector3.up, -mouseX * rotateSpeed);
                    transform.Rotate(Vector3.right, mouseY * rotateSpeed);
                }
            }
        }

        // getters and setters for cube rotation
        protected virtual float RotateSpeed 
        {
            get { return rotateSpeed; }
            set { rotateSpeed = value; }
        }

        // getters and setters for main camera
        protected virtual Camera MainCamera
        {
            get { return mainCamera; }
            set { mainCamera = value; }
        }
}

