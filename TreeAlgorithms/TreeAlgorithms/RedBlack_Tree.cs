﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeAlgorithms
{
    class RedBlack_Tree<T>
    {

        class AVL_Node : Node<T>
        {
            public AVL_Node(T value) : base(value)
            {
            }
        }
    }
}
