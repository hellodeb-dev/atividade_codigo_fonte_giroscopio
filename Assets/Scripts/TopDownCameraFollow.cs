using UnityEngine;

public class TopDownCameraFollow : MonoBehaviour
{
    public Transform target;
    public float height = 20f;
    public float smooth = 5f;

    private Vector3 offset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offset = transform.position - target.position;
        offset.y = height;
    }

    // Update is called once per frame
    void Update()
    {
        if (!target) return;

        Vector3 desirePosition = target.position + offset;
        desirePosition.y = height;

        transform.position = Vector3.Lerp(transform.position, desirePosition, Time.deltaTime * smooth);
    }
}
