using System;

namespace MusicPlayerProject
{
    //class node represents an instance of a song in the track list

    class Node<T> where T : IComparable<T>
    {
        private T name;
        private T path;
        public Node<T> next, prev = null;

        //constuctor to create a new node/track
        public Node(T name, T path)
        {
            this.name = name;
            this.path = path;
        }
        //assessor methods
        public T getName()
        {
            return name;
        }
        public T getPath()
        {
            return path;
        }
    }
}

