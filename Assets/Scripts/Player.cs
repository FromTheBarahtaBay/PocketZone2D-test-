using UnityEngine;

public class Player : MonoBehaviour
{
    public void SavePlayer()
    {
        SaveLoadManager.SaveData(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveLoadManager.LoadData();
        Vector3 pos;
        pos.x = data.position[0];
        pos.y = data.position[1];
        pos.z = data.position[2];
        transform.position = pos;
    }
}
