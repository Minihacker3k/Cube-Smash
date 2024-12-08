using UnityEngine;

public class AddHitWhenHit : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.GetComponent<Hit>() == true)
        {
            if (GetComponent<Hit>() == null)
            {
                gameObject.AddComponent<Hit>();
                MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
                meshRenderer.material.color = Color.red;
            }
        }
        if (collision.transform.CompareTag("FLYINGCUBE"))
        {
            if (GetComponent<Hit>() == null)
            {
                gameObject.AddComponent<Hit>();
                MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
                meshRenderer.material.color = Color.red;

            }
        }
    }
}
