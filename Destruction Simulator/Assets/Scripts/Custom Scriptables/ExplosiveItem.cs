using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "ExplosiveItem", menuName ="Explosions/basicExplosiveItem")]
public class ExplosiveItem : ScriptableObject
{
    public enum ExplosionType{TimeBomb ,Missile ,Cannon};

    public ExplosionType itemType;
    public string itemName = "Defulat Bomb";
    public Sprite itemIcon = null;
}