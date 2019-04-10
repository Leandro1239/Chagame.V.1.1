using UnityEngine;

public class CameraSegue : MonoBehaviour
{
    public GameObject Player;
    public float CamVel = 0.25f;
    Vector3 UltimaPos;
    Vector3 VelAtual;
    
    void Start()
    {
        UltimaPos = Player.transform.position;
    }

    void FixedUpdate()
    {
        
            Vector3 NovaCam = Vector3.SmoothDamp(transform.position, Player.transform.position, ref VelAtual, CamVel);

            transform.position = new Vector3(NovaCam.x, NovaCam.y, transform.position.z);

            //UltimaPos = Player.transform.position;
        
    }
}
