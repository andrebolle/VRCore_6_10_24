//using UnityEngine;

//public class AlienFormAndMove : MonoBehaviour
//{
//    // The prefab for an alien GameObject, which will be instantiated as part of the formation.
//    public GameObject alienPrefab;

//    // Number of rows and columns in the alien formation (grid size).
//    public int rows = 5;          // Default: 5 rows of aliens.
//    public int columns = 11;      // Default: 11 columns of aliens.

//    // Spacing between each alien in the grid (controls how spread out they are).
//    public float spacing = 2f;

//    // Reference to the Quad transform to determine positioning and orientation only.
//    public Transform quadTransform;

//    // Array to hold the references to all alien GameObjects instantiated in the formation.
//    private GameObject[] aliens;

//    // Movement properties
//    public float speed = 5f;              // Speed of horizontal movement.
//    public float dropDistance = 0.5f;     // Distance to drop when hitting the screen edge.
//    public float screenLeftBoundary = -8f; // Left screen boundary.
//    public float screenRightBoundary = 8f; // Right screen boundary.
//    private int direction = 1;            // Direction: 1 for right, -1 for left.

//    // Start is called before the first frame update
//    void Start()
//    {
//        // Create the alien formation using the GridUtility method
//        CreateAlienFormation();
//    }

//    void Update()
//    {
//        // Handle the movement of the alien formation
//        MoveFormation();

//        // Check for edge collisions and handle direction change and row drop
//        if (ReachedRightBoundary() || ReachedLeftBoundary())
//        {
//            ReverseDirection();
//            DropFormation();
//        }
//    }

//    // Method to create and position the alien formation using the utility
//    void CreateAlienFormation()
//    {
//        // Use the GridUtility method to create a grid of aliens and store the result in the aliens array.
//        aliens = GridUtility.CreatePrefabGrid(alienPrefab, rows, columns, spacing, quadTransform);

//        // Output to the console the number of aliens created for debugging.
//        Debug.Log("Alien formation initialized with " + aliens.Length + " aliens.");
//    }

//    // Move the alien formation horizontally
//    void MoveFormation()
//    {
//        // Move the entire formation by updating its position
//        transform.position += new Vector3(speed * Time.deltaTime * direction, 0, 0);
//    }

//    // Check if the formation has reached the right boundary
//    bool ReachedRightBoundary()
//    {
//        // Check if the rightmost alien has reached the screen's right boundary
//        return GetRightmostAlienPosition() >= screenRightBoundary;
//    }

//    // Check if the formation has reached the left boundary
//    bool ReachedLeftBoundary()
//    {
//        // Check if the leftmost alien has reached the screen's left boundary
//        return GetLeftmostAlienPosition() <= screenLeftBoundary;
//    }

//    // Reverse the direction of horizontal movement
//    void ReverseDirection()
//    {
//        direction *= -1; // Flip the movement direction
//    }

//    // Drop the alien formation down by a certain distance
//    void DropFormation()
//    {
//        // Move the entire formation down by the specified drop distance
//        transform.position += new Vector3(0, -dropDistance, 0);
//    }

//    // Get the X position of the rightmost alien in the formation
//    float GetRightmostAlienPosition()
//    {
//        // Logic to find the rightmost alien's X position in the array
//        float rightmostPosition = float.MinValue;
//        foreach (GameObject alien in aliens)
//        {
//            if (alien != null)
//            {
//                rightmostPosition = Mathf.Max(rightmostPosition, alien.transform.position.x);
//            }
//        }
//        return rightmostPosition;
//    }

//    // Get the X position of the leftmost alien in the formation
//    float GetLeftmostAlienPosition()
//    {
//        // Logic to find the leftmost alien's X position in the array
//        float leftmostPosition = float.MaxValue;
//        foreach (GameObject alien in aliens)
//        {
//            if (alien != null)
//            {
//                leftmostPosition = Mathf.Min(leftmostPosition, alien.transform.position.x);
//            }
//        }
//        return leftmostPosition;
//    }
//}

using UnityEngine;

public class AlienFormAndMove : MonoBehaviour
{
    public GameObject alienPrefab;
    public int rows = 5;
    public int columns = 11;
    public float spacing = 2f;
    public Transform quadTransform;
    private GameObject[] aliens;

    public float speed = 5f;
    public float dropDistance = 0.5f;
    public float screenLeftBoundary = -8f;
    public float screenRightBoundary = 8f;
    private int direction = 1;

    void Start()
    {
        CreateAlienFormation();
    }

    void Update()
    {
        // Move each alien individually
        MoveAliensIndividually();

        // Check for edge collisions and handle direction change and row drop
        if (ReachedRightBoundary() || ReachedLeftBoundary())
        {
            ReverseDirection();
            DropAliens();
        }
    }

    void CreateAlienFormation()
    {
        aliens = GridUtility.CreatePrefabGrid(alienPrefab, rows, columns, spacing, quadTransform);
        Debug.Log("Alien formation initialized with " + aliens.Length + " aliens.");
    }

    // Move each alien individually
    void MoveAliensIndividually()
    {
        foreach (GameObject alien in aliens)
        {
            if (alien != null)
            {
                // Move each alien horizontally
                alien.transform.position += new Vector3(speed * Time.deltaTime * direction, 0, 0);
            }
        }
    }

    bool ReachedRightBoundary()
    {
        // Check if the rightmost alien has reached the screen's right boundary
        return GetRightmostAlienPosition() >= screenRightBoundary;
    }

    bool ReachedLeftBoundary()
    {
        // Check if the leftmost alien has reached the screen's left boundary
        return GetLeftmostAlienPosition() <= screenLeftBoundary;
    }

    void ReverseDirection()
    {
        direction *= -1; // Flip the movement direction
    }

    void DropAliens()
    {
        foreach (GameObject alien in aliens)
        {
            if (alien != null)
            {
                // Move each alien down by the specified drop distance
                alien.transform.position += new Vector3(0, -dropDistance, 0);
            }
        }
    }

    float GetRightmostAlienPosition()
    {
        float rightmostPosition = float.MinValue;
        foreach (GameObject alien in aliens)
        {
            if (alien != null)
            {
                rightmostPosition = Mathf.Max(rightmostPosition, alien.transform.position.x);
            }
        }
        return rightmostPosition;
    }

    float GetLeftmostAlienPosition()
    {
        float leftmostPosition = float.MaxValue;
        foreach (GameObject alien in aliens)
        {
            if (alien != null)
            {
                leftmostPosition = Mathf.Min(leftmostPosition, alien.transform.position.x);
            }
        }
        return leftmostPosition;
    }
}
