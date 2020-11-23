using System;
using System.Collections;
using System.Collections.Generic;
using CardGames;
using UnityEngine;
using Object = UnityEngine.Object;

[Serializable]
public class GameObjectPool
{
    [SerializeField] private Transform _container;
    [SerializeField] private GameObject _prefab;
    private Queue<GameObject> _pool;

    public void Pool(GameObject gameObject)
    {
        gameObject.SetActive(false);
        gameObject.transform.SetParent(_container);
        _pool.Enqueue(gameObject);
    }

    public GameObject UnPool()
    {
        if (_pool.Count > 0)
            return _pool.Dequeue();
        else
            return Object.Instantiate(_prefab);
    }

    public void Init() => _pool = new Queue<GameObject>();

}

public class HandUI : MonoBehaviour
{
    private struct PoolPair
    {
        public CardUI Card;
        public GameObject Go;

    }
    
    [SerializeField] private RectTransform _container;
    [SerializeField] private GameObjectPool _goPool;

    private List<PoolPair> _pairs;

    private void Awake()
    {
        Init();
    }

    void Init()
    {
        _pairs = new List<PoolPair>();
        _goPool.Init();
    }
    
    void ResizePairs(int count)
    {
        for (var i = _pairs.Count; i < count; i++)
        {
            var go = _goPool.UnPool();
            go.transform.SetParent(_container);
            var pair = new PoolPair()
            {
                Card = go.GetComponent<CardUI>(),
                Go = go
            };
            go.SetActive(true);
            _pairs.Add(pair);
        }
        while(count < _pairs.Count)
        {
            var i = _pairs.Count-1;
            var pair = _pairs[i];
            _pairs.RemoveAt(i);
            pair.Go.SetActive(false);
            _goPool.Pool(pair.Go);
            //Prepare GC
            pair.Card = null;
            pair.Go = null;
        }
    }
    
    public void Display(IList<ICardInstance> hand)
    {
        ResizePairs(hand.Count);
        for (var i = 0; i < hand.Count; i++)
        {
            _pairs[i].Card.SetCard(hand[i]);
        }
    }
    
    
}
