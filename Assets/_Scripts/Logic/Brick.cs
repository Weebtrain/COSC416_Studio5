using System.Collections;
using UnityEngine;

public class Brick : MonoBehaviour
{
    private Coroutine destroyRoutine = null;
    private ParticleSystem ps;

    private void Start()
    {
        ps = this.gameObject.GetComponentInChildren<ParticleSystem>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (destroyRoutine != null) return;
        if (!other.gameObject.CompareTag("Ball")) return;
        destroyRoutine = StartCoroutine(DestroyWithDelay());
    }

    private IEnumerator DestroyWithDelay()
    {
        yield return new WaitForSeconds(0.1f); // two physics frames to ensure proper collision
        GameManager.Instance.OnBrickDestroyed(transform.position);
        ps.Play(); 
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
