using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClue : MonoBehaviour
{
    [SerializeField] private Clue _clue;
    [SerializeField] private bool _isClue;

    private StickCollisionHandler _stick;

    private void Awake()
    {
        _stick = FindObjectOfType<StickCollisionHandler>();
    }

    private void Update()
    {
        if (_isClue == true)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                _clue.Close();
            }
        }
    }

    private void OnEnable()
    {
        if (_isClue == true)
        {
            _stick.StickGetted += _clue.Open;
        }
    }

    private void OnDisable()
    {
        if (_isClue == true)
        {
            _stick.StickGetted -= _clue.Open;
        }
    }
}
