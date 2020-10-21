using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Explosive : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] private float delay;
    [SerializeField] private LayerMask bombMask;
    
    
    IEnumerator Start()
    {
        yield return new WaitForSeconds(delay);
        Boom();
    }

    private void Boom()
    {
        RayCast(Vector2.down * radius);
        RayCast(Vector2.up * radius);
        RayCast(Vector2.left * radius);
        RayCast(Vector2.right * radius);
        Destroy(gameObject);
    }
    private void RayCast(Vector2 dir)
    {
        
        var hits = Physics2D.RaycastAll(transform.position, dir, 1f,bombMask);
        foreach (var hit in hits)
        {
            Debug.Log(hit.collider.name);
            if (hit.collider.CompareTag("Destroyed") || hit.collider.CompareTag("Player"))
            {   
              
                Destroy(hit.collider.gameObject);
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
