using System.CodeDom.Compiler;
using UnityEngine;

public class DestructibleGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _chunkPrefab;
    [SerializeField] private float _spacing = 0.25f;

    //  Use a string array to draw our asteroid
    //  X is a chunk, ' ' is empty space
    private string[] _asteroidPattern =
    {
        "    XXXX    ",
        "   XXXXXXX  ",
        "  XXXXXXXXX ",
        "  XXXXXXXXX ",
        "  XXXXXXXXX ",
        "   XXXXXXX  ",
        "    XXXXX   ",


    };
    private void Start()
    {
        GenerateObject();

    }
    private void GenerateObject()
    {
        int height = _asteroidPattern.Length;
        int width = _asteroidPattern[0].Length;  //  Length of first line of text pattern

        float offsetX = (width * _spacing) / 2f - (_spacing / 2f);
        float offsetY = (height * _spacing) / 2f - (_spacing / 2f);

        //  Loop through the rows (Y Axis reading our text pattern top to bottom)
        for (int y = 0; y < height; y++)
        {
            //  Loop through the columns
            for (int x = 0; x < width; x++)
            {
                char character = _asteroidPattern[y][x];
                //  if we find an X...chunk!
                if (character == 'X')
                {
                    float posX = transform.position.x + (x * _spacing) - offsetX;
                    // because text draws from top to bottom, we need to subtract Y spacing
                    float posY = transform.position.y - (y * _spacing) + offsetY;
                    Vector2 spawnPos = new Vector2(posX, posY);
                    GameObject newChunk = Instantiate(_chunkPrefab, spawnPos, Quaternion.identity);
                    newChunk.transform.SetParent(this.transform);  //  Make the chunk a child of the generator for organization
                }
            }

        }
    }
}
