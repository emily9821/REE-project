using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JJH
{
    public class JJHManager : MonoBehaviour
    {
        public static JJHManager Inst { get; private set; }
        public OrderManager order
        {
            get
            {
                if (_order == null)
                {
                    _order = GetComponentInChildren<OrderManager>();
                }
                return _order;
            }
            set { _order = value; }
        }
        public PlayerManager player
        {
            get; set;
        }

        private OrderManager _order;

        // Start is called before the first frame update
        void Start()
        {
            DontDestroyOnLoad(gameObject);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
