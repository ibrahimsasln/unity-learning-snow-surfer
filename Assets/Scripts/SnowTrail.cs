using UnityEngine;

public class SnowTrail : MonoBehaviour
{
    [SerializeField] ParticleSystem snowTrailParticles;
    void OnCollisionEnter2D(Collision2D collision) 
    {
        int layerIndex = LayerMask.NameToLayer("Floor");

        if (collision.gameObject.layer == layerIndex)
        {
            snowTrailParticles.Play();
        }
        
    }
    void OnCollisionExit2D(Collision2D collision) 
    {
        int layerIndex = LayerMask.NameToLayer("Floor");

        if (collision.gameObject.layer == layerIndex)
        {
            snowTrailParticles.Stop();
        }
        
    }
}
