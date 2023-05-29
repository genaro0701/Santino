using UnityEngine;
using DG.Tweening;
using System.Collections;

public class Collectibles : MonoBehaviour
{
    [SerializeField] ParticleSystem itemCollect;
    [SerializeField] private eObjectPoolType poolType;
    [SerializeField] private float location = 5f;
    [SerializeField] private float duration =1f;

    private void Start() 
    {
        transform.DOLocalMoveY(gameObject.transform.position.y + location, duration).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
       
        //check if the player collided with the collectibles
        if (other.CompareTag("Player"))
        { 
            itemCollect.Play();
            Managers.Instance.audioManager.Play("ItemCollect");

            //check if the tag of this game object is Coconut oil
            if (poolType == eObjectPoolType.Niyog)
            {
                //Kunin yung kung ilan yung nasa database tapos lagay sa inventory
                PlayerPrefasManager.Instance.Niyog = 1;
                Managers.Instance.inventoryManager.AddToInventory(0, PlayerPrefasManager.Instance.Niyog);
            }
            //check if the tag of this game object is Gensing
            else if (poolType == eObjectPoolType.Ugat)
            {
                //Kunin yung kung ilan yung nasa database tapos lagay sa inventory
                PlayerPrefasManager.Instance.Ugat = 1;
                Managers.Instance.inventoryManager.AddToInventory(1, PlayerPrefasManager.Instance.Ugat);
            }
            //check if the tag of this game object is Baging
            else if (poolType == eObjectPoolType.Baging)
            {
                //Kunin yung kung ilan yung nasa database tapos lagay sa inventory
                PlayerPrefasManager.Instance.Baging = 1;
                Managers.Instance.inventoryManager.AddToInventory(2, PlayerPrefasManager.Instance.Baging);
            }
            //check if the tag of this game object is Pilak
            else if (poolType == eObjectPoolType.Tanso)
            {
                //Kunin yung kung ilan yung nasa database tapos lagay sa inventory
                PlayerPrefasManager.Instance.Tanso = 1;
                Managers.Instance.inventoryManager.AddToInventory(3, PlayerPrefasManager.Instance.Tanso);
            }
            //check if the tag of this game object is Langis
            else if (poolType == eObjectPoolType.Langis)
            {
                //Kunin yung kung ilan yung nasa database tapos lagay sa inventory
                PlayerPrefasManager.Instance.Langis = 1;
                Managers.Instance.inventoryManager.AddToInventory(4, PlayerPrefasManager.Instance.Langis);
                Managers.Instance.uiManager.Langis();
            }
            else if (poolType == eObjectPoolType.Page)
            {
                //Kunin yung kung ilan yung nasa database tapos lagay sa inventory
                PlayerPrefasManager.Instance.Page = 1;
                Managers.Instance.inventoryManager.AddToInventory(6, PlayerPrefasManager.Instance.Page);
                Managers.Instance.uiManager.Page();
            }

            StartCoroutine(Queue());
        }
    }

    private IEnumerator Queue()
    {
        yield return new WaitForSeconds(.1f);
        BasicObjectPooling.Instance.Queue(gameObject, poolType);
    }
}
