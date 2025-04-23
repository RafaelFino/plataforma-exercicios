#include <iostream>
#include <cstddef>
#include <string>

using namespace std;

//Node class
template <class T>
class Node
{
    Node<T>* _previous;
    Node<T>* _next;
    T _value;
  public:
    Node(T value)
    {
        _value = value;
        _previous = NULL;
        _next = NULL;        
    }

    void Set(T value)
    {
        _value = value;
    }    

    void SetNext(Node<T>* next)
    {
        _next = next;
    }

    void SetPrevious(Node<T>* previous)
    {
        _previous = previous;
    }

    void SetFirst()
    {
        _previous = NULL;
    }

    void SetLast()
    {
        _next = NULL;
    }

    T Get()
    {
        return _value;
    }    

    Node<T>* GetNext()
    {
        return _next;
    }    

    Node<T>* GetPrevious()
    {
        return _previous;
    }
};

//List
template <class T>
class List
{
    int _count;
    Node<T>* _first;
    Node<T>* _last;    
  public:
    List()
    {
        _count = 0;
        _first = NULL;
        _last = NULL;
    }

    void Add(T item)
    {    
        Node<T>* node = new Node<T>(item);
        node->SetLast();
        
        if ( _count == 0 )
        {
            node->SetFirst();            
            _first = node;
            _last = node;
        } 
        else if( _count == 1 )
        {
            node->SetPrevious(_first);
            _first->SetNext(node);
            _last = node;
        } 
        else
        {
            node->SetPrevious(_last);
            _last->SetNext(node);
            _last = node;
        }

        _count++;        
    }      

    void Remove(int index)
    {        
        Node<T>* node = _first;

        if (_count <= 0)
        {
            return;
        }

        if (_count == 1)
        {
            _last = NULL;
            _first = NULL;            
            _count--;
            return;
        }
       
        if (index <= 0)
        {            
            _first = _first->GetNext();
            _first->SetFirst();
            if (_first->GetNext() == NULL)
            {
                _first->SetLast();
            }
        }
        else if(index >= _count) 
        {
            _last = _last->GetPrevious();

            if (_last != NULL)
            {
                _last->SetLast();    
            }
        }
        else
        {
            for(int i = 0; i < index; i++)
            {                          
                node = node->GetNext();             
            }

            Node<T>* next = node->GetNext();
            Node<T>* previous = node->GetPrevious();

            previous->SetNext(next);
            next->SetPrevious(previous);     
        }

        _count--;

        if (_count == 0) 
        {
            _last = NULL;
            _first = NULL;
        }
    }

    T Pop()
    {
        T ret;   

        if (_count > 0) 
        {
            ret = _last->Get();
            
            _last = _last->GetPrevious();
            if (_last != NULL)
            {
                _last->SetLast();    
            } 
            else 
            {
                _last = NULL;
                _first = NULL;
            }
            
            _count--;
        }
        return ret;
    }

    int Count()
    {
        return _count;
    }      

    bool IsEmpty()
    {
        return _count == 0;
    }

    T operator[](int index)
    {
        Node<T>* node = _first;
        
        for(int i = 0; i < index; i++)
        {            
            if (node->GetNext() == NULL)
            {
                return node->Get();
            }

            node = node->GetNext();
        }

        return node->Get();
    }  
};

int main()
{
    cout << "Start" << endl;

    List<int> l;
    int qty = 100000;

    cout << "Add " << qty << " items" << endl;
    for(int i = 0; i < qty; i++)
    {
        l.Add(i);
    }    

    cout << "Remove from middle..." << endl;
    while(l.Count() > qty/2)
    {
        l.Remove(l.Count()/2);
    }

    cout << "Test remove greater than index" << endl;
    l.Remove(1000);

    cout << "Test remove smaller than zero" << endl;
    l.Remove(-3);

    cout << "Test remove ramdom number" << endl;
    l.Remove(33);

    cout << "count:" << l.Count() << endl;  
    for(int i = 0; i < 5; i++)
    {
        cout << l[i] << endl;
    }

    cout << "Removing first 3 items ..." << endl;
    l.Remove(0);
    l.Remove(0);
    l.Remove(0);

    cout << "count:" << l.Count() << endl;  
    for(int i = 0; i < 5; i++)
    {
        cout << l[i] << endl;
    }

    cout << "Add " << qty << " items again" << endl;
    for(int i = 0; i < 1000; i++)
    {
        l.Add(i);
    }     

    int count = 0;

    cout << l.Count() << " items now, running pop util ending..." << endl;
    while(!l.IsEmpty())
    {
        l.Pop();
        count++;
    }

    cout << "count:" << l.Count() << endl; 
    cout << "removed:" << count << endl;  
}