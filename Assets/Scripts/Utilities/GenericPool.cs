
using System;
using System.Collections.Generic;

public class GenericPool<T> where T : class
{
    private List<PooledItem<T>> pooledItems=new List<PooledItem<T>>();



    public T GetItem()
    {
        PooledItem<T> item = pooledItems.Find(item=>!item.isUsed);
        if(item!=null)
        {
            item.isUsed = true;
            return item.controller;
        }
        return CreatePooledItem();
    }

    public void ReturnToPool(T returnItem)
    {
        PooledItem<T> item= pooledItems.Find(item=>item.controller== returnItem);
        if(item!=null)
        {
            item.isUsed= false;
        }
    }


    private T CreatePooledItem()
    {
        PooledItem<T> newItem= new PooledItem<T>();
        newItem.isUsed = true;
        newItem.controller = CreateItem();
        pooledItems.Add(newItem);
        return newItem.controller;
    }

    public virtual T CreateItem()
    {
        throw new NotImplementedException("child does not contain implementation");
    }

    public class PooledItem<T>
    {
        public T controller;
        public bool isUsed;
    }
}

