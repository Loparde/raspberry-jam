using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public static CameraMovement Instance;
    [SerializeField] private float speed;
    private List<Vector2> goalPositions = new List<Vector2>();

    public void AddGoalDirecion(Vector2 direction)
    {
        goalPositions[0] += direction;
    }

    public void AddGoalPosition(Vector2 position)
    {
        goalPositions.Add(position);
    }

    public void SetGoalList(List<Vector2> positions)
    {
        goalPositions = positions;
    }

    public void AddGoalList(List<Vector2> positions)
    {
        goalPositions.AddRange(positions);
    }

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("CameraMovement instance exists twice. Call CameraMovement.Instance only in Start()");
        }
        Instance = this;
    }

    private void Update()
    {
        if (goalPositions.Count <= 0)
            return;


        Vector3 direction = new Vector3(goalPositions[0].x, goalPositions[0].y, 0) - new Vector3(transform.position.x, transform.position.y, 0);

        if (!(direction.x < 0.01f && direction.x > -0.01f) || !(direction.y < 0.01f && direction.y > -0.01f))
            transform.position += direction.normalized * speed * Time.deltaTime;
        else
            goalPositions.RemoveAt(0);
    }
}
