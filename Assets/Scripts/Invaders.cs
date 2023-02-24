
using UnityEngine;
using UnityEngine.UIElements;

public class Invaders : MonoBehaviour
{
    public Invader[] Prefabs;

    public int rows = 5;

    public int cols = 11;

    private void Awake()
    {
        for (int row = 0; row < rows; row++ )
        {
            float width = 2.0f * (cols - 1);
            float height = 2.0f * (rows - 1);
            Vector2 centering = new Vector2(-width / 2, -height / 2);
            Vector3 rowPos = new Vector3(centering.x, centering.y + (row * 2.0f), 0.0f);

            for (int col = 0; col < cols; col++)
            {
                Invader Invader = Instantiate(Prefabs[row], transform);

                Vector3 pos = rowPos;
                pos.x += col * 2.0f;
                Invader.transform.localPosition = pos;
            }
        }
    }
}
