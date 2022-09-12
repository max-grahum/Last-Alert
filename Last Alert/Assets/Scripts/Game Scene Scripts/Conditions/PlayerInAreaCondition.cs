using UnityEngine;

public class PlayerInAreaCondition : Condition {

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            completed = true;
        }
    }

    public override void ResetCondition() {
        completed = false;
    }
}