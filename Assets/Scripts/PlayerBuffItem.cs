using UnityEngine;

public class PlayerBuffItem : Item
{
    public GameObject buffPrefab;
    public override void onBeingPickup(PlayerCharacter player)
    {
        var buff = Instantiate(buffPrefab);
        buff.GetComponent<IPlayerBuff>().Setup(player);
    }
}