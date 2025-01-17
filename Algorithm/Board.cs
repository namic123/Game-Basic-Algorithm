using System;
using System.Collections.Generic;

namespace Algorithm
{
    // O(1) - 상수시간
    class MyLinkedListNode<T>
    {
        public T Data;
        public MyLinkedListNode<T> Next;
        public MyLinkedListNode<T> Prev;
    }

    class MyLinkedList<T>
    {
        public MyLinkedListNode<T> Head = null; // 리스트의 첫 번째 인덱스
        public MyLinkedListNode<T> Tail = null; // 리스트의 마지막 인덱스 
        public int Count = 0;

        public MyLinkedListNode<T> AddLast(T data)
        {
            MyLinkedListNode<T> newRoom = new MyLinkedListNode<T>();
            newRoom.Data = data;

            // 만약 방이 아예 없었다면, 새로 추가한 첫번째 방이 Head
            if (Head == null)
                Head = newRoom;
            
            // 끝에 데이터가 존재한다면, 끝 값의 next에 데이터를 넣는다
            // 즉 마지막 방과 새로 추가되는 방을 연결 
            if (Tail != null)
            {
                Tail.Next = newRoom;
                newRoom.Prev = Tail;
            }
            // 새로 추가되는 방을 마지막 방으로 지정
            Tail = newRoom;
            Count++;
            return newRoom;
        }
        // O(1) - 상수시간
        public void Remove(MyLinkedListNode<T> room)
        {
            // 기존의 첫번째 방의 다음 방을 첫 번째 방으로 지정
            if (Head == room)
                Head = Head.Next;
            // 기존의 마지막 방의 이전 방을 마지막 방으로 지정
            if (Tail == room)
                Tail = Tail.Prev;
            // 현재 자신 노드의 이전 방이 null 이 아니라면, 자신 노드의 Next를 이전 방의 Next로 지정
            if(room.Prev != null)
                room.Prev.Next = room.Next;
            // 현재 자신 노드의 다음 방이 null이 아니라면, 자신 노드의 Prev를 다음 방의 Prev로 지정
            if(room.Next != null)
                room.Next.Prev = room.Prev;
            
            Count--;
        }
    }
    
    class Board
    {
        public int[] _data = new int[25];
        public MyLinkedList<int> _data3 = new MyLinkedList<int>();
        public void Initialize()
        {
            _data3.AddLast(101);
            _data3.AddLast(102);
            MyLinkedListNode<int> node = _data3.AddLast(103);
            _data3.AddLast(104);
            _data3.AddLast(105);

            _data3.Remove(node);
        }
    }
}