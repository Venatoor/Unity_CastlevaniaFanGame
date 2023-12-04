using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum NodeState
{
    FAILURE, RUNNING, SUCCESS,
}

public abstract class Node 
{
    public NodeState state;
    public Node parent;
    protected List<Node> children = new List<Node>();

    private Dictionary<string, object> dataContext = new Dictionary<string, object>();

    public Node()
    {
        parent = null;
    }

    public virtual NodeState Evaluate() => NodeState.FAILURE;

    public Node(List<Node> children)
    {
        foreach ( Node child in children )
        {
            
            Attach(child);
        }
    }

    private void Attach(Node node)
    {
        Debug.Log("Success");
        node.parent = this;
        children.Add(node);
    }


    public void SetData(string key, object value)
    {
        dataContext[key] = value;
    }


    public object GetData(string key)
    {
        object value = null;
        if ( dataContext.TryGetValue(key, out value))
        {
            return value;
        }

        Node node = this.parent;
        while (node != null)
        {
            value = node.GetData(key);
            if ( value != null)
            {
                return value;
            }
            node = node.parent;
        }
        return null;
    }


    public bool ClearData(string key)
    {
        if ( dataContext.ContainsKey(key))
        {
            dataContext.Remove(key);
            return true;
        }

        Node node = this.parent;
        while (node != null)
        {
            bool cleared = node.ClearData(key);
            if (cleared)
            {
                return true;
            }

            node = node.parent;
        }
        return false;
    }
}
