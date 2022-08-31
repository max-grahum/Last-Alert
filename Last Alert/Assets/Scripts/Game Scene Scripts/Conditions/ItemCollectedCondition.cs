using UnityEngine;

public class ItemCollectedCondition : Condition {

    //Allow multiple types of the same object if needed
    public GameObject[] itemWanted;

    private void OnTriggerEnter(Collider other) {
        foreach (GameObject item in itemWanted) {
            if (item == other.gameObject) {
                completed = true;
            }
        }
    }
}
