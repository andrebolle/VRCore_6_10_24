using UnityEngine;

public static class GridUtility
{
    /// <summary>
    /// Creates a grid of GameObjects based on the provided prefab, and returns an array of the created GameObjects.
    /// </summary>
    /// <param name="prefab">The prefab to instantiate in the grid.</param>
    /// <param name="rows">Number of rows in the grid.</param>
    /// <param name="columns">Number of columns in the grid.</param>
    /// <param name="spacing">The distance between each object in the grid.</param>
    /// <param name="parentTransform">The transform used to position and rotate the grid.</param>
    /// <returns>An array of the created GameObjects.</returns>
    public static GameObject[] CreatePrefabGrid(GameObject prefab, int rows, int columns, float spacing, Transform parentTransform)
    {
        // Check if the prefab has a renderer to calculate its size
        Renderer prefabRenderer = prefab.GetComponent<Renderer>();
        if (prefabRenderer == null)
        {
            Debug.LogWarning("The provided prefab does not have a Renderer component, so the size cannot be determined.");
        }
        else
        {
            // Get the size of the prefab
            Vector3 prefabSize = prefabRenderer.bounds.size;

            // Check if the spacing is sufficient to prevent overlap
            if (spacing <= prefabSize.x || spacing <= prefabSize.y)
            {
                Debug.LogWarning($"The provided spacing ({spacing}) may cause prefabs to overlap. " +
                 $"Prefab width: {prefabSize.x}, Prefab height: {prefabSize.y}. " +
                 "Consider increasing the spacing value.");
            }

        }

        // Initialize an array to hold the instantiated GameObjects.
        GameObject[] gridObjects = new GameObject[rows * columns];

        // Calculate the total width and height of the grid.
        float totalWidth = (columns - 1) * spacing;
        float totalHeight = (rows - 1) * spacing;

        float halfGridWidth = -totalWidth / 2f;
        float halfGridHeight = -totalHeight / 2f;

        // Loop through each row and column to instantiate prefabs in a grid.
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                // Calculate the local position for the current prefab in the grid based on the row and column.
                Vector3 localPosition = new Vector3(
                    halfGridWidth + col * spacing,  // X position based on column and spacing
                    halfGridHeight + row * spacing, // Y position based on row and spacing
                    0f                              // Z position (assuming flat grid)
                );

                // Transform the local position to world space, respecting the parent transform's position and rotation.
                Vector3 worldPosition = parentTransform.TransformPoint(localPosition);

                // Instantiate the prefab at the calculated world position.
                GameObject obj = Object.Instantiate(prefab, worldPosition, parentTransform.rotation);

                // Set the prefab's rotation to match the parent transform's rotation.
                obj.transform.rotation = parentTransform.rotation;

                // Set the prefab's parent to the provided parentTransform to keep hierarchy organized.
                obj.transform.SetParent(parentTransform);

                // Store the instantiated prefab in the array.
                gridObjects[row * columns + col] = obj;
            }
        }

        // Return the array of instantiated GameObjects.
        return gridObjects;
    }
}
