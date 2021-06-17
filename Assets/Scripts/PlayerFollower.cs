using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    public Transform playerTransform;
    [SerializeField] public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        //offset = this.transform.position - playerTransform.position;
        //Debug.Log(offset);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = playerTransform.position + offset;
    }
}
