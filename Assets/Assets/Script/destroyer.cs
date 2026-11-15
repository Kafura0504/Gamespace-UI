using System.Collections;
using UnityEngine;

public class destroyer : MonoBehaviour
{
    public float time;
    private AudioSource aud;
    void Awake()
    {
        aud = GetComponent<AudioSource>();
        aud.pitch = UnityEngine.Random.Range(0.9f,1.1f);

        Destroy(gameObject, time);
    }
}