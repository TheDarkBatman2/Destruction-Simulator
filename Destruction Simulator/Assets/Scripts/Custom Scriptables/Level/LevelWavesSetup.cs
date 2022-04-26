using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "BaseLevelWavesSetup", menuName ="Enemy/LevelWavesSetup")]
public class LevelWavesSetup : ScriptableObject
{
    [System.Serializable]
    public struct EnemiesInArmy{
        public GameObject prefab;
        public int count;
        public float spawnRate;
        public float spawnDelay;
    }
    [System.Serializable]
    public class ArmyInfo{
        public string waveName = "Basic Wave";
        public EnemiesInArmy[] enemies;
    }
    [Header("Waves are index based")]
    [SerializeField] public ArmyInfo[] wavesSetup;
}
