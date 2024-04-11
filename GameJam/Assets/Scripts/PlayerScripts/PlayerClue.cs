using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClue : MonoBehaviour
{
    [SerializeField] Clue _clue;

    private StickCollisionHandler _stick;

    private void Awake()
    {
        _stick = FindObjectOfType<StickCollisionHandler>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _clue.Close();
        }
    }

    private void OnEnable()
    {
        _stick.StickGetted += _clue.Open;
    }

    private void OnDisable()
    {
        _stick.StickGetted -= _clue.Open;
    }
}
