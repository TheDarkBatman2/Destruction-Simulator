using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "ExplosiveItem", menuName ="Explosions/basicExplosiveItem")]
public class ExplosiveItem : ScriptableObject
{
    public enum ExplosionType{TimeBomb ,Missile ,Cannon};

    [Header("Explosion")]
    [InspectorName("Explosion Type")] public ExplosionType itemType;
    public float explosionForce = 1f;
    public GameObject explosionVfx;

    [Header("Audio")]
    public AudioClip audioClip;
    [Range(0f , 1f)] public float audioVolume = 0.4f;

    [Header("Camera Shake")]
    [InspectorName("Strength")] public float cameraShakeStrength;
    [InspectorName("Time Scale") ,Range(0f ,10f)] public float cameraShakeTimeScale;

    [Header("Item Stats")]
    public string itemName = "Defulat Bomb";
    public Sprite itemIcon = null;
    [TextArea] public string description = "";


    
}