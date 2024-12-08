using UnityEngine;

public class Grab : MonoBehaviour
{
    public Transform rayStartPoint;  // Startpunkt für den Ray
    public Transform stayPoint;      // Punkt, zu dem das Objekt gezogen wird
    public float raycastDistance = 10f;  // Reichweite des Raycasts
    public float force = 10f;        // Kraft, die auf das Objekt angewendet wird

    public GameObject grabbedObject;  // Gegriffenes Objekt
    public Rigidbody grabbedRigidbody; // Rigidbody des gegriffenen Objekts
    public Transform throwPoint;

    public bool grabLocked = false;
    public bool shot = false;


    private void Update()
    {
        
        if(!shot)
        {
            if (Input.GetKey(KeyCode.R)) // Wenn "R" gedrückt wird
            {
                RaycastHit hit;

                Ray ray = new Ray(rayStartPoint.position, rayStartPoint.forward);


                // Raycast ausführen
                if (Physics.Raycast(ray, out hit, raycastDistance))
                {
                    Debug.Log("Ray shot");
                    Debug.Log(hit.collider.gameObject.name);
                    Debug.DrawLine(rayStartPoint.position, hit.collider.transform.position);
                    // Prüfen, ob das Objekt "grabable" ist und einen Rigidbody hat
                    if (hit.collider.TryGetComponent<Grabable>(out Grabable grabable) && hit.collider.TryGetComponent<Rigidbody>(out Rigidbody rb))
                    {
                        grabbedObject = hit.collider.gameObject;
                        grabbedRigidbody = grabbedObject.GetComponent<Rigidbody>();

                        grabLocked = true;


                    }
                }
            }
        }

        if (grabLocked)
        {
            // Wenn ein Objekt gehalten wird, ziehe es zum Zielpunkt
            Vector3 pullDirection = (stayPoint.position - grabbedObject.transform.position).normalized;
            grabbedRigidbody.AddForce(pullDirection * force, ForceMode.Force);
            Vector3 throwDirection = (throwPoint.transform.position - grabbedObject.transform.position).normalized;

            if (Input.GetMouseButtonDown(0))
            {
                grabLocked = false;
                shot = true;
                grabbedRigidbody.AddForce(-throwDirection * 44, ForceMode.Impulse);
                Invoke("SetShotOff", 0.1f);
            }
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            Debug.Log("Reset");
            grabbedObject = null;
            
            grabbedRigidbody = null;
            grabLocked = false;
        }
    }

    void SetShotOff()
    {
        shot = false;
    }


}
