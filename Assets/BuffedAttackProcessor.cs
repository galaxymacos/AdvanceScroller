using UnityEngine;

public class BuffedAttackProcessor : MonoBehaviour
{
    private PlayerCharacter playerCharacter;

    private void Awake()
    {
        playerCharacter = GetComponent<PlayerCharacter>();
        SwordPrincessAttackMessagingComponent.onBuffedAttack += ShootLightningSword;
    }

    public Transform lightningSwordSpawnPosition;
    public GameObject lightningSwordPrefab;
    public void ShootLightningSword()
    {
        print("Shoot lightning sword");
        var lightningSword = Instantiate(lightningSwordPrefab, lightningSwordSpawnPosition.position, Quaternion.identity);
        var newProjectileComponent = lightningSword.GetComponent<NewProjectile>();
        newProjectileComponent.Setup(playerCharacter,20);
    }
}
