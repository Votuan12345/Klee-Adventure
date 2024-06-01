using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private Transform characterPos;
    [SerializeField] private List<GameObject> characters;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;

    private void Awake()
    {
        if(characters != null && characters.Count > 0)
        {
            int index = Prefs.characterSelectionIndex;
            GameObject player = Instantiate(characters[index], characterPos.position, Quaternion.identity);
            virtualCamera.Follow = player.transform;
        }
    }

}
