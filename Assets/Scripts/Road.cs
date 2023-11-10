using UnityEngine;

public class Road : MonoBehaviour
{
    public GameObject roadPrefab;
    public Vector3 lastPosition;
    public float offset = 0.7f;

    private int roadCount = 0;

    public void RoadBuild()
    {
        InvokeRepeating("CreateRoad", 1f, .2f);
    }
    public void CreateRoad()
    {
        Vector3 spawnPosition = Vector3.zero;
        float chance = Random.Range(0, 100);
        if (chance < 50)
        {
            spawnPosition = new Vector3(lastPosition.x + offset, lastPosition.y, lastPosition.z + offset);
        }
        else { spawnPosition = new Vector3(lastPosition.x - offset, lastPosition.y, lastPosition.z + offset); }

        GameObject newRoad = Instantiate(roadPrefab, spawnPosition, Quaternion.Euler(0, 45, 0));

        lastPosition = newRoad.transform.position;
        roadCount++;

        if (roadCount % 5 == 0)
        {
            newRoad.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
