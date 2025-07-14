using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEffect : MonoBehaviour
{
    public AudioClip effectClip;
    public bool soundExistence;
    public float disappearsTime = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        if (soundExistence)
        {
            GetComponent<AudioSource>().PlayOneShot(effectClip);
        }

        Destroy(gameObject, disappearsTime);
    }

}
