using System.Collections;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(Queue());
    }

    private IEnumerator Queue()
    {
        yield return new WaitForSeconds(.2f);
        BasicObjectPooling.Instance.Queue(gameObject, eObjectPoolType.Explosion);
    }
}
