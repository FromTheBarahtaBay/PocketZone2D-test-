using UnityEngine;

public class DestroyObjectAfterAnimation : MonoBehaviour
{
    public void DestroyObjectAfterAnim()
    {
        Transform _objectToDestroy = GetComponent<Transform>();
        GetComponent<CircleCollider2D>().radius = 0f;
        Destroy(_objectToDestroy.gameObject, 9);
        print($"Враг повержен!");
    }
}
