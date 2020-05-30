using System;
using System.IO;
using System.Windows.Forms;

namespace MusicPlayerProject
{
    /* Class TrackLinkedList represents a custom doubly linked list object created to incorporate a merge sort 
     * and binary search for better organisation and encapsulation. It is filled with objects of type node upon
     * user request (when the user adds songs to the media player).
    */
    class TrackLinkedList<T> where T : IComparable<T>
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
            try
            {
                if (name != null)
                {
                    //create new object to add to list
                    Node<T> newSong = new Node<T>(name, path);
                    //call method to set tail new node
                    SetTailNode();
                    //use tails 'next' attribute to create new node
                    //also set new objects 'previous' attribute to tail node
                    //this ensures the list is doubly linked
                    if (head != null)
                    {
                        tail.next = newSong;
                        newSong.prev = tail;
                    }
                    //case if list is empty
                    else
                    {
                        head = newSong;
                    }
                }
                //catch errors
            } catch (IOException e){
                MessageBox.Show ("Error: " + e);
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
            while (temp != null)
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
                return left;
            }
            else
            {
                right.next = SortedMerge(left, right.next);
                return right;
            }
        }

        //method to merge sort the linked list
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

        //alternative MergeSort method optimised for the linked list structure
        public Node<T> OptimisedMergeSort(Node<T> head)
        {
            int blockSize = 1, blockCount;
            do
            {
                //Maintain two lists pointing to two blocks, left and right
                Node<T> left = head, right = head, tail = null;
                head = null; //Start a new list
                blockCount = 0;

                //Walk through entire list in blocks of size blockCount
                while (left != null)
                {
                    blockCount++;

                    //Advance right to start of next block, measure size of left list while doing so
                    int leftSize = 0, rightSize = blockSize;
                    for (; leftSize < blockSize && right != null; ++leftSize)
                        right = right.next;

                    //Merge two list until their individual ends
                    bool leftEmpty = leftSize == 0, rightEmpty = rightSize == 0 || right == null;
                    while (!leftEmpty || !rightEmpty)
                    {
                        Node<T> smaller;
                        //Using <= instead of < gives us sort stability
                        if (rightEmpty || (!leftEmpty && left.getName().CompareTo(right.getName()) <= 0))
                        {
                            smaller = left; left = left.next; --leftSize;
                            leftEmpty = leftSize == 0;
                        }
                        else
                        {
                            smaller = right; right = right.next; --rightSize;
                            rightEmpty = rightSize == 0 || right == null;
                        }
                        //Update new list
                        if (tail != null)
                            tail.next = smaller;
                        else
                            head = smaller;
                        tail = smaller;
                    }
                    //right now points to next block for left
                    left = right;
                }
                //terminate new list, take care of case when input list is null
                if (tail != null)
                    tail.next = null;
                //Lg n iterations
                blockSize <<= 1;
            } while (blockCount > 1);
            return head;
        }//end optimised mergeSort


        //method to clear the entire linked list of all nodes
        public void Clear()
        {
            if (head != null)
            {
                Remove(head.getName());
            }
        }

        //method to remove a node from the list given the name - uses binary search to find the node
        public void Remove(T name)
        {
            //insert binary search method to find the node
            BinarySearch(name);
        }

        public Node<T> BinarySearch(T target)
        {
            //bool found = false;
            //int pointer = 0;
            if (head == null)
            {
                MessageBox.Show("Error: the track list is empty");
                return null;
            }
            Node<T> start = head, end = null;
            while (start != end || end != null)
            {
                Node<T> middle = GetMiddle(start);
                //pointer++;
                if ((middle.getName().CompareTo(target)) == 0)
                {
                    return middle;
                }
                else if ((middle.getName().CompareTo(target)) < 0) //if less than
                {
                    end = middle.prev;
                }
                else if ((middle.getName().CompareTo(target)) > 0) //if more than
                {
                    start = middle.next;
                }
                //else
                //{
                //    middle = middle.next;
                //}
            }
            return null;
        }

        private Node<T> GetMiddleNode(Node<T> start, Node<T> end)
        {
            if (start == null)
            {
                return null;
            }
            Node<T> fast = start, slow = start;
            while (fast != end && fast.next != end)
            {
                fast = fast.next.next;
                slow = slow.next;
            }
            return slow;
        }
    }
}
