using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerProject
{
    class Node<T> where T : IComparable<T>
    {
        public T name;
        public T path;
        public Node<T> next, prev;

        //constuctor to create a new node/track
        public Node(T name, T path)
        {
            this.name = name;
            this.path = path;
        }

        //method to get the middle of the list
        private Node<T> getMiddle(Node<T> head)
        {
            //base case
            if (head == null || head.next == null)
            {
                return head;
            }
            Node<T> slow = head;
            Node<T> fast = head;
            //move fast by 2 and slow by 1 
            while (fast.next != null && fast.next.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
            }
            return slow;
        }

        //method used by merge sort method to compare strings
        private Node<T> sortedMerge(Node<T> left, Node<T> right)
        {
            //base cases
            if (left == null)
            {
                return right;
            }
            if (right == null)
            {
                return left;
            }
            //pick left or right and recur
            if ((left.name as IComparable).CompareTo(right.name) < 0)
            {
                left.next = sortedMerge(left.next, right);
                return left;
            }
            else
            {
                right.next = sortedMerge(left, right.next);
                return right;
            }
        }

        //method to merge sort the linked list
        public Node<T> mergeSort(Node<T> head)
        {
            //if head is null
            if (head == null || head.next == null)
            {
                return head;
            }
            //get middle of the list
            Node<T> middle = getMiddle(head);
            Node<T> middleNext = middle.next;
            //set next of middle node to null
            middle.next = null;
            //apply merge sort on left list
            Node<T> left = mergeSort(head);
            //apply merge sort in right list
            Node<T> right = mergeSort(middleNext);
            //merge left and right lists together
            return sortedMerge(left, right);
        }
    }
}
