using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public Transform room;

    [Range(-15,15)]
    public float minModX, minModY, maxModX, maxModY;

    public float velocidadCamara;


    private static CameraController instance;

    private void Awake()
    {
        if (instance == null) 
        { 
            instance = this; 
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var minPosY = room.GetComponent<BoxCollider2D>().bounds.min.y + minModY;
        var minPosX = room.GetComponent<BoxCollider2D>().bounds.min.x + minModX;
        var maxPosY = room.GetComponent<BoxCollider2D>().bounds.max.y + maxModY;
        var maxPosX = room.GetComponent<BoxCollider2D>().bounds.max.x + maxModX;
        
        Vector3 posicionAcotada = new Vector3(
            Mathf.Clamp(player.position.x, minPosX, maxPosX),
            Mathf.Clamp(player.position.y, minPosY, maxPosY),
            Mathf.Clamp(player.position.z, -10f, -10f)
            );
        Vector3 cambioSuave = Vector3.Lerp(transform.position, posicionAcotada, velocidadCamara * Time.deltaTime);
        transform.position = cambioSuave;
    }
}
