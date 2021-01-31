using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBoxEndGame : MonoBehaviour
{

    [SerializeField] CharacterStateController _character = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Carillon")
        {
            _character.ChangeState(ECharacterState.INTERACTION);
        }
    }
}
