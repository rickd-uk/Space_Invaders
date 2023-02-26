
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Invaders : MonoBehaviour
{
    public Invader[] Prefabs;

    public int rows = 5;

    public int cols = 11;

    public AnimationCurve speed;

    public Projectile MissilePrefab;

    public int amountKilled { get; private set; }

    public int totalInvaders => rows * cols;

    public int amountAlive => totalInvaders - amountKilled;

    public float percentKilled => (float)amountKilled / (float)totalInvaders;

    public float missileAttackRate = 1.0f;


    private Vector3 direction = Vector2.right;

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

                Invader.killed += InvaderKilled;

                Vector3 pos = rowPos;
                pos.x += col * 2.0f;
                Invader.transform.localPosition = pos;
            }
        }
    }

    private void Start()
    {
        InvokeRepeating(nameof(MissileAttack), missileAttackRate, missileAttackRate);
    }

    private void Update()
    {
        transform.position += direction * speed.Evaluate(percentKilled) * Time.deltaTime;
      

        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

        foreach (Transform invader in transform)
        {
            if (!invader.gameObject.activeInHierarchy) continue;

            if (direction == Vector3.right && invader.position.x >= rightEdge.x - 1.0f)
            {
                AdvanceRow();
            } else if (direction == Vector3.left && invader.position.x <= leftEdge.x + 1.0f)
            {
                AdvanceRow();
            }
           
        }
    }

    private void AdvanceRow()
    {
        direction.x *= -1.0f;

        Vector3 position = transform.position;
        position.y -= 1.0f;
        transform.position = position;
    }

    private void MissileAttack()
    {
        foreach (Transform Invader in transform)
        {
            if (!Invader.gameObject.activeInHierarchy) continue;

            if (Random.value < (1.0f / (float)amountAlive))
            {
                Instantiate(MissilePrefab, Invader.position, Quaternion.identity);
                break;
            }
            
        }

    }



    private void InvaderKilled()
    {
        amountKilled++;

    }
}
