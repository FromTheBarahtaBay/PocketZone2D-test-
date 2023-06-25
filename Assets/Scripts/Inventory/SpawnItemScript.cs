using UnityEngine;

public class SpawnItemScript : MonoBehaviour
{
    public GameObject _item;
    private Transform _player;

    
    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void SpawnDroppedItem()
    {
        Vector2 playerPosition = new Vector2(_player.position.x + Random.Range(-2f, 2f), _player.position.y + Random.Range(-1f, 1f));
        Instantiate(_item, playerPosition, Quaternion.identity);
    }
    
}
