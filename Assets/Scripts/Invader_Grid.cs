using UnityEngine;

public class Invaders : MonoBehaviour
{
    public Invader[] prefabs = new Invader[5];
    private Vector3 initialPosition;
    public int rows = 5;
    public int columns = 11;

    private void Awake()
    {
        initialPosition = transform.position;

        CreateInvaderGrid();
    }

    private void CreateInvaderGrid()
    {
        for (int i = 0; i < rows; i++)
        {
            float width = 2f * (columns - 1);
            float height = 2f * (rows - 1);

            Vector2 centerOffset = new Vector2(-width * 0.5f, -height * 0.5f);
            Vector3 rowPosition = new Vector3(centerOffset.x, (2f * i) + centerOffset.y, 0f);

            for (int j = 0; j < columns; j++)
            {
                // Create a new invader and parent it to this transform
                Invader invader = Instantiate(prefabs[i], transform);

                // Calculate and set the position of the invader in the row
                Vector3 position = rowPosition;
                position.x += 2f * j;
                invader.transform.localPosition = position;
            }
        }
    }
}