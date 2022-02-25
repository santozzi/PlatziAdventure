using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZone : MonoBehaviour
{
    private PlayerController thePlayer;
    private CameraFollow theCamera;
    private Vector3 posicion;
    public string placeName;

    // Start is called before the first frame update
    void Start()
    {
        posicion = Vector3.zero;

        thePlayer = FindObjectOfType<PlayerController>();
        theCamera = FindObjectOfType<CameraFollow>();

        if (!thePlayer.nextPlaceName.Equals(placeName)) {
            return;
        }

        posicion.x = this.transform.position.x;
        posicion.y = this.transform.position.y;
        thePlayer.transform.position = posicion;
        
        theCamera.transform.position = new Vector3(
              this.transform.position.x,
              this.transform.position.y,
              theCamera.transform.position.z
             
            );
        print($"the camera la pos z es: {theCamera.transform.position.z}");
        print($"the player la pos z es: {thePlayer.transform.position.z}");
    }


}
