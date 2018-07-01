using System;
using System.Collections.Generic;

namespace Data_Structures {
    public class BinaryTreeNode {
        public string Data;
        public BinaryTreeNode Left;
        public BinaryTreeNode Right;

        public BinaryTreeNode(string data) {
            Data = data;
        }
    }
    
    public class BinaryTree {
        public BinaryTreeNode Root;

        public bool AddNode(string data) {
            BinaryTreeNode newNode = new BinaryTreeNode(data);

            if (Root == null) {
                Root = newNode;
            } else {
                BinaryTreeNode current = Root;

                while (true) {
                    if (String.CompareOrdinal(data,current.Data) < 0) {
                        if (current.Left == null) {
                            current.Left = newNode;
                            return true;
                        }
                        
                        current = current.Left;
                    } else {
                        if (current.Right == null) {
                            current.Right = newNode;
                            return true;
                        }

                        current = current.Right;
                    }
                }
            }

            return false;
        }

        public List<string> PreOrder() {
            List<string> dataList = new List<string>();
            List<BinaryTreeNode> stack = new List<BinaryTreeNode>();
            BinaryTreeNode current = null;

            if (Root != null) {
                stack.Add(Root);

                while(stack.Count > 0) {
                    current = stack[0];
                    stack.RemoveAt(0);                    
                    dataList.Add(current.Data);

                    if (current.Right != null) {
                        stack.Insert(0, current.Right);
                    }

                    if (current.Left != null) {
                        stack.Insert(0, current.Left);
                    }
                                        
                }
                
            }

            return dataList;
        }

        public List<string> InOrder() {
            return null;
        }

        public List<string> PostOrder() {
            return null;
        }
    }
}