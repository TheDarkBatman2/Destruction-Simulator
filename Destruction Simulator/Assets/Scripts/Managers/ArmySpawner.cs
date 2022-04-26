using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmySpawner : MonoBehaviour
{
    public Formation formation;
    public LevelWavesSetup armySetup;
    public Formation formationManager;
    private void Start() {
        StartWave();
    }
    public void StartWave(){
        foreach (LevelWavesSetup.EnemiesInArmy enemy in armySetup.wavesSetup[References.Instance.curStage-1].enemies){
            StartCoroutine(SpawnEnemy(enemy));
        }
    }

    private IEnumerator SpawnEnemy(LevelWavesSetup.EnemiesInArmy enemy){
        yield return new WaitForSeconds(enemy.spawnDelay); // spawn delay of enemy

        for (int i = 1; i <= enemy.count; i++){
            // Instantiate enemy
            Transform _tr = formationManager.formationTransforms[Random.Range(0, formationManager.formationTransforms.Length)];
            GameObject instEnemy = Instantiate(enemy.prefab, _tr.position, Quaternion.identity); // random transform in the formation
            // Get enemy behaviour using its parent class
            EnemyBehaviour _eb = instEnemy.GetComponent<EnemyBehaviour>();
            if (_eb){
                print(_eb.gameObject.name);
                _eb.targetTransform = _tr;
            }

            // Spawnrate
            yield return new WaitForSeconds(enemy.spawnRate/(i * 0.5f));
        }
    }

}
