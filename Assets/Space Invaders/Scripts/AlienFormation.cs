////using UnityEngine;

/////// <summary>
/////// AlienFormation is responsible for managing and controlling a group of alien GameObjects 
/////// arranged in a grid. It handles the initialization, positioning, and optional movement 
/////// of the alien formation.
/////// </summary>
////public class AlienFormation : MonoBehaviour
////{
////    // The prefab for an alien GameObject, which will be instantiated as part of the formation.
////    public GameObject alienPrefab;

////    // Number of rows and columns in the alien formation (grid size).
////    public int rows = 5;          // Default: 5 rows of aliens.
////    public int columns = 11;      // Default: 11 columns of aliens.

////    // Spacing between each alien in the grid (controls how spread out they are).
////    public float spacing = 2f;

////    // Reference to the Quad transform to determine positioning and scaling.
////    public Transform quadTransform;

////    // Array to hold the references to all alien GameObjects instantiated in the formation.
////    private GameObject[] aliens;

////    // Start is called before the first frame update
////    void Start()
////    {
////        // Call the method to create the alien formation when the game starts
////        CreateAlienFormation();
////    }

////    // Method to create and position the alien formation based on the quad size
////    void CreateAlienFormation()
////    {
////        // Get the quad's Renderer to determine its bounds.
////        Renderer quadRenderer = quadTransform.GetComponent<Renderer>();

////        if (quadRenderer == null)
////        {
////            Debug.LogError("Quad transform does not have a Renderer component.");
////            return;
////        }

////        // Get the size of the quad in local space.
////        Vector3 quadSize = quadRenderer.bounds.size;

////        // Initialize the aliens array to hold the total number of aliens (rows * columns).
////        aliens = new GameObject[rows * columns];

////        // Calculate the total width and height of the formation.
////        float totalWidth = (columns - 1) * spacing;
////        float totalHeight = (rows - 1) * spacing;

////        // Ensure the formation fits inside the quad
////        if (totalWidth > quadSize.x || totalHeight > quadSize.y)
////        {
////            Debug.LogError("The alien formation is larger than the quad. Reduce rows, columns, or spacing.");
////            return;
////        }

////        // Calculate offsets to center the formation within the quad's local space.
////        float offsetX = -quadSize.x / 2f + (quadSize.x - totalWidth) / 2f;
////        float offsetY = -quadSize.y / 2f + (quadSize.y - totalHeight) / 2f;

////        // Loop through each row and column to instantiate aliens in a grid.
////        for (int row = 0; row < rows; row++)
////        {
////            for (int col = 0; col < columns; col++)
////            {
////                // Calculate the local position for the current alien in the grid based on the row and column.
////                Vector3 localPosition = new Vector3(
////                    offsetX + col * spacing,    // X position based on column and spacing
////                    offsetY + row * spacing,    // Y position based on row and spacing
////                    0f                          // Z position relative to the quad's plane
////                );

////                // Transform the local position to world space, respecting the quad's rotation and position.
////                Vector3 worldPosition = quadTransform.TransformPoint(localPosition);

////                // Instantiate an alien prefab at the calculated world position.
////                GameObject alien = Instantiate(alienPrefab, worldPosition, quadTransform.rotation);

////                // Optionally, align the alien's rotation with the quad's rotation.
////                alien.transform.rotation = quadTransform.rotation;

////                // Store the alien in the aliens array (row * columns + col is the unique index).
////                aliens[row * columns + col] = alien;

////                // Set the alien's parent to the AlienFormation GameObject to keep the hierarchy organized.
////                alien.transform.SetParent(transform);
////            }
////        }





////        // Output to the console the number of aliens created for debugging.
////        Debug.Log("Alien formation initialized with " + aliens.Length + " aliens.");
////    }
////}

//using UnityEngine;

///// <summary>
///// AlienFormation is responsible for managing and controlling a group of alien GameObjects 
///// arranged in a grid. It handles the initialization, positioning, and optional movement 
///// of the alien formation.
///// </summary>
//public class AlienFormation : MonoBehaviour
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

//    // Start is called before the first frame update
//    void Start()
//    {
//        // Call the method to create the alien formation when the game starts
//        CreateAlienFormation();
//    }

//    // Method to create and position the alien formation
//    void CreateAlienFormation()
//    {
//        // Initialize the aliens array to hold the total number of aliens (rows * columns).
//        aliens = new GameObject[rows * columns];

//        // Calculate the total width and height of the formation.
//        // (columns - 1) is used because the number of spaces between aliens is 
//        // always one less than the number of aliens in a row. The same applies to rows.
//        // | S | S | S | S |    S = Space, | = Alien
//        float totalWidth = (columns - 1) * spacing;
//        float totalHeight = (rows - 1) * spacing;

//        // Calculate offsets to center the formation around the origin of the quad's local space.
//        float offsetX = -totalWidth / 2f;
//        float offsetY = -totalHeight / 2f;

//        // Loop through each row and column to instantiate aliens in a grid.
//        for (int row = 0; row < rows; row++)
//        {
//            for (int col = 0; col < columns; col++)
//            {
//                // Calculate the local position for the current alien in the grid based on the row and column.
//                Vector3 localPosition = new Vector3(
//                    offsetX + col * spacing,    // X position based on column and spacing
//                    offsetY + row * spacing,    // Y position based on row and spacing
//                    0f                          // Z position relative to the quad's plane
//                );

//                // Transform the local position to world space, respecting the quad's rotation and position.
//                Vector3 worldPosition = quadTransform.TransformPoint(localPosition);

//                // Instantiate an alien prefab at the calculated world position.
//                GameObject alien = Instantiate(alienPrefab, worldPosition, quadTransform.rotation);

//                // Optionally, align the alien's rotation with the quad's rotation.
//                alien.transform.rotation = quadTransform.rotation;

//                // Store the alien in the aliens array (row * columns + col is the unique index).
//                aliens[row * columns + col] = alien;

//                // Set the alien's parent to the AlienFormation GameObject to keep the hierarchy organized.
//                alien.transform.SetParent(transform);
//            }
//        }

//        // Output to the console the number of aliens created for debugging.
//        Debug.Log("Alien formation initialized with " + aliens.Length + " aliens.");
//    }
//}

using UnityEngine;

public class AlienFormation : MonoBehaviour
{
    // The prefab for an alien GameObject, which will be instantiated as part of the formation.
    public GameObject alienPrefab;

    // Number of rows and columns in the alien formation (grid size).
    public int rows = 5;          // Default: 5 rows of aliens.
    public int columns = 11;      // Default: 11 columns of aliens.

    // Spacing between each alien in the grid (controls how spread out they are).
    public float spacing = 2f;

    // Reference to the Quad transform to determine positioning and orientation only.
    public Transform quadTransform;

    // Array to hold the references to all alien GameObjects instantiated in the formation.
    private GameObject[] aliens;

    // Start is called before the first frame update
    void Start()
    {
        // Create the alien formation using the GridUtility method
        CreateAlienFormation();
    }

    // Method to create and position the alien formation using the utility
    void CreateAlienFormation()
    {
        // Use the GridUtility method to create a grid of aliens and store the result in the aliens array.
        aliens = GridUtility.CreatePrefabGrid(alienPrefab, rows, columns, spacing, quadTransform);

        // Output to the console the number of aliens created for debugging.
        Debug.Log("Hello! Alien formation initialized with " + aliens.Length + " aliens.");
    }
}
