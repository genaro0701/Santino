using System.Collections;
using UnityEngine;

public class Disolve : MonoBehaviour
{
    [SerializeField] private SpriteRenderer material;
    [SerializeField] private float delay = .1f;

    public IEnumerator Disolved()
    {
        float fade = 1f;

        yield return new WaitForSeconds(delay);

        do
        {
            yield return new WaitForSeconds(delay);
            fade -= Time.deltaTime;
            material.material.SetFloat("_Fade", fade);
        }
        while (fade > 0f);

        Destroy(gameObject);
    }

}
