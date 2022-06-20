using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _cost;

    public int Cost => _cost;

    public UnityAction CoinTaked;


}
