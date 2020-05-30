using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MusicPlayerProject
{
    /* Class TrackLinkedList represents a custom doubly linked list object created to incorporate a merge sort 
     * and binary search for better organisation and encapsulation. It is filled with objects of type node upon
     * user request (when the user adds songs to the media player).
    */
    class TrackLinkedList<T> where T : IComparable<T>//, IEnumerable<T>
    {
        //head and tail nodes attributes of track list
        Node<T> head, tail;
        //default constructor
        public TrackLinkedList()
        {
            this.head = null;
            this.tail = null;
        }

        //assessor methods for head and tail
        public Node<T> getHead()
        {
            return head;
        }
        public Node<T> getTail()
        {
            return tail;
        }

        //method to add a node object to the end of the list while maintaining correct head and tail values
        public void AddLastNode(T name, T path)
        {
            if (name != null)
            {
                //create new object to add to list
                Node<T> newSong = new Node<T>(name, path);
                if (head != null)
                {
                    //use tails 'next' attribute to create new node
                    //also set new objects 'previous' attribute to tail node
                    //this ensures the list is doubly linked
                    tail.next = newSong;
                    newSong.prev = tail;
                    SetTailNode();
                }
                //case if list is empty
                else
                {
                    head = newSong;
                    //call method to set tail new node
                    SetTailNode();
                }
            }
            else
            {
                return;
            }
        }

        //method to get the length of the linkedList as an int
        public int GetLengthOfList()
        {
            Node<T> temp = head;
            int count = 0;
            while (temp != null)
            {
                count++;
                temp = temp.next;
            }
            return count;
        }

        //method to maintain the tail (last) node in the list as correct when adding nodes
        public void SetTailNode()
        {
            Node<T> temp = head;
            while (temp.next != null)
            {
                temp = temp.next;
            }
            tail = temp;
        }

        //method to get the middle of the list
        private Node<T> GetMiddle(Node<T> head)
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
        private Node<T> SortedMerge(Node<T> left, Node<T> right)
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
            if ((left.getName() as IComparable).CompareTo(right.getName()) < 0)
            {
                left.next = SortedMerge(left.next, right);
                left.next.prev = left;
                left.prev = null;
                return left;
            }
            else
            {
                right.next = SortedMerge(left, right.next);
                right.next.prev = right;
                right.prev = null;
                return right;
            }
        }

        //method to merge sort the linked list, split and putting back together
        public Node<T> MergeSort(Node<T> head)
        {
            //if head is null
            if (head == null || head.next == null)
            {
                return head;
            }
            //get middle of the list
            Node<T> middle = GetMiddle(head);
            Node<T> middleNext = middle.next;
            //set next of middle node to null
            middle.next = null;
            //apply merge sort on left list
            Node<T> left = MergeSort(head);
            //apply merge sort in right list
            Node<T> right = MergeSort(middleNext);
            //merge left and right lists together
            return SortedMerge(left, right);
        }

        //method to remove a node from the list given the name - uses binary search to find the node
        public void Remove(T name)
        {
            //use binary search method to find the node with input name
            Node<T> target = BinarySearch(name);
            if (target == null)
            {
                return;
            }
            else
            {
                Node<T> next = target.next;
                Node<T> prev = target.prev;
                //link the surrounding nodes together
                prev.next = next;
                next.prev = prev;
                //delete the unlinked node
                target = null;
            }
        }

        public Node<T> BinarySearch(T target)
        {
            //bool found = false;
            //int pointer = 0;
            if (head == null)
            {
                MessageBox.Show("Error: The track list is empty");
                return null;
            }
            //else if (head.getName().CompareTo(target) == 0)
            //{
            //    return head;
            //}
            Node<T> start = head, end = tail;
            //recursive search function
            while ((end != null) || (!(start.getName().CompareTo(end.getName()) == 0)))
            {
                //find the middle of the list
                Node<T> middle = GetMiddleNode(start, end);
                //pointer++;
                if (middle.getName().CompareTo(target) == 0)
                {
                    return middle;
                }
                else if (middle.getName().CompareTo(target) < 0) //if middle less than target
                {//set end of list to be serached as before the mid point
                    start = middle.next;
                }
                else if (middle.getName().CompareTo(target) > 0) //if middle more than target
                {//set the start of the list to after the mid point
                    end = middle;
                }
            }
            return null;
        }

        //method to find the middle of the list, must traverse the list so does not have good time complexity
        private Node<T> GetMiddleNode(Node<T> start, Node<T> end)
        {
            if (start == null)
            {
                return null;
            }
            Node<T> fast = start, slow = start;
            while ((!(fast.getName().CompareTo(end.getName()) == 0)) && (!(fast.next.getName().CompareTo(end.getName()) == 0)))
            {
                fast = fast.next.next;
                slow = slow.next;
            }
            return slow;
        }

        public Node<T> CheckForDuplicate(T name)
        {
            Node<T> temp = head;
            if ((temp != null) && (temp.getName().CompareTo(name) == 0))
            {
                return temp;
            }
            while (temp.next != null)
            {
                temp = temp.next;
                if (temp.getName().CompareTo(name) == 0)
                {
                    return temp;
                }
            }
            return null;
        }

        //public IEnumerator<T> GetEnumerator()
        //{
        //    Node<T> current = head;
        //    while (current != null)
        //    {
        //        yield return current.getName();
        //        current = current.next;
        //    }
        //    //return new LinkedListEnumerator<T>(this);
        //}

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    return this.GetEnumerator();
        //}
    }
}
