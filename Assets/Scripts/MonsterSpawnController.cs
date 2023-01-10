using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawnController : MonoBehaviour {

    public bool Respawn = true;
    public int NumeroDeMonstros;
    public GameObject[] MonstersPrefabs;

    public List<GameObject> monsterList = new List<GameObject>();

    void Start() {
        CriarMonstros();
    }

    void Update() {
        DestruirMonstrosMortos();

        if (Respawn) {
            CriarMonstros();
        }
    }

    void DestruirMonstrosMortos() {
        for (int i = monsterList.Count - 1; i >= 0; i--) {
            GameObject monster = monsterList[i];
            MonsterManager monsterManager = monster.GetComponent<MonsterManager>();

            if (monsterManager.currentHealth <= 0) {
                monsterList.RemoveAt(i);
                Destroy(monster);
            }
        }
    }

    void CriarMonstros() {
        while (NumeroDeMonstros > monsterList.Count) {
            int i = Random.Range(0, MonstersPrefabs.Length);
            monsterList.Add(Instantiate(MonstersPrefabs[i], this.transform.position, this.transform.rotation));
        }
    }
}
