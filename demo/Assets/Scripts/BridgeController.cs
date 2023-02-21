using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class BridgeController : MonoBehaviour
{
    public GameObject tracker1;
    public GameObject tracker2;
    public float amplitude = 0.1f;
    public float frequency = 1f;
    public float minSpeed = 1f;
    public float maxSpeed = 5f;

    private SteamVR_TrackedObject trackedObj1;
    private SteamVR_TrackedObject trackedObj2;

    private float length;
    private float timeOffset;

    void Start()
    {
        trackedObj1 = tracker1.GetComponent<SteamVR_TrackedObject>();
        trackedObj2 = tracker2.GetComponent<SteamVR_TrackedObject>();

        length = Vector3.Distance(tracker1.transform.position, tracker2.transform.position);
        timeOffset = Random.Range(0f, 1000f);
    }

    void Update()
    {
        var speed = Mathf.Lerp(minSpeed, maxSpeed, (transform.position.y + length / 2) / length);

        var delta = (Time.time + timeOffset) * speed;
        var angle = Mathf.Sin(delta * frequency) * amplitude;

        transform.localRotation = Quaternion.Euler(0f, 0f, angle);
    }
}
