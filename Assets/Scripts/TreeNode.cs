using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TreeNode : MonoBehaviour {

    public static GameObject parent;
    public GameObject rightOrb;
    public GameObject leftOrb;

    public GameObject smallTreeNodePrefab;

    public char value = '*';
    public int index = 0;
    public int depth = 0;

    // dispay component for char
    public TextMeshPro orbText;
    
    // LEFT child node instance vars
    GameObject leftNode;
    GameObject leftJoin;
    Vector3 leftNodePosition;
    Vector3 leftStartPosition;
    Vector3 leftEndPosition;

    // RIGHT child node instance vars
    GameObject rightNode;
    GameObject rightJoin;
    Vector3 rightNodePosition;
    Vector3 rightStartPosition;
    Vector3 rightEndPosition;

    // positioning of child nodes
    private float horizontalOffset = 20;
    private int verticalOffset = -7;

    


    // Use this for initialization
    void Start () {
        
    }

    // Update is called once per frame
    void Update () {
        
    }

    public void insert (int i, char v, int d = 0)
    {
        // step depth
        d++;

        // check against this value
        if (i < index)
        {
            if (leftNode == null)
            {
                if (depth == 4)
                {
                    leftNode = Instantiate(smallTreeNodePrefab, parent.transform, true) as GameObject;// , transform, false);
                    
                }
                else
                {
                    leftNode = Instantiate(leftOrb, parent.transform, true) as GameObject; //b, transform, false);
                    Debug.Log(v);
                }
                leftNode.name = "left-node-" + v;
                setChildValues(leftNode, i, v, d);
                positionLeftNode();
                
            }
            else
            {   
                insertToChild(leftNode, i, v, d);
            }
        }
        else if (i > index) { 
            
            if (rightNode == null){

                if (depth == 4)
                {
                    rightNode = Instantiate(smallTreeNodePrefab, parent.transform, true) as GameObject;
                }
                else
                {
                    
                    rightNode = Instantiate(rightOrb, parent.transform, true) as GameObject;
                    
                }

                rightNode.name = "right-node-" + v;
                setChildValues(rightNode, i, v, d);
                positionRightNode();
            }
            else
            {
               
                insertToChild(rightNode, i, v, d);
                
            }

            
        }
    }

    public void setValue (char v)
    {
        value = v;
        orbText.SetText("" + v);
    }

    public void setIndex (int i)
    {
        index = i;
    }

   

    public void setDepth (int d)
    {
        depth = d;
        horizontalOffset = (Mathf.Round((80/(Mathf.Pow(2,d+2f))) * 100.0f) / 100f);
    }

    private void setChildValues(GameObject node, int i, char v, int d)
    {
        if (node != null)
        {
            var nodeScript = node.GetComponent<TreeNode>();
            if (nodeScript != null)
            {
                nodeScript.setValue(v);
                nodeScript.setIndex(i);
                nodeScript.setDepth(d);
                
            }
        }
    }

    private void insertToChild(GameObject node, int i, char v, int d)
    {
        if (node != null)
        {
            var nodeScript = node.GetComponent<TreeNode>();
            if (nodeScript != null)
            {
                nodeScript.insert(i, v, d);
            }
        }

    }

    private void positionLeftNode()
    {
       

        leftNode.transform.position = transform.position;
        leftNode.transform.position += new Vector3(-horizontalOffset, verticalOffset, 0);
        
        
        // create the left join positions
        leftStartPosition = Vector3.MoveTowards(transform.position, leftNode.transform.position, 1.3f);
        leftEndPosition = Vector3.MoveTowards(leftNode.transform.position, transform.position, 1.3f);



        leftJoin = new GameObject("leftJoin");
        leftJoin.transform.SetParent(parent.transform, true);
        LineRenderer leftLine = leftJoin.AddComponent<LineRenderer>();

        leftLine.material = new Material(Shader.Find("Sprites/Default"));
        leftLine.widthMultiplier = 0.3f;
        leftLine.positionCount = 2;
        leftLine.useWorldSpace = false;
        // A simple 2 color gradient with a fixed alpha of 1.0f.
        float alpha = 1.0f;
        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(new Color(0.2F, 0.3F, 0.4F, 0.5F), 0.0f), new GradientColorKey(new Color(0.5F, 0.8F, 0.9F, 0.5F), 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
            );

        leftLine.colorGradient = gradient;

        leftLine.SetPosition(0, leftStartPosition);
        leftLine.SetPosition(1, leftEndPosition);
        
    }

    private void positionRightNode()
    {
       
        rightNode.transform.position = transform.position;
        rightNode.transform.position += new Vector3(horizontalOffset, verticalOffset, 0);

        
        // create the left join positions
        rightStartPosition = Vector3.MoveTowards(transform.position, rightNode.transform.position, 1.3f);
        rightEndPosition = Vector3.MoveTowards(rightNode.transform.position, transform.position, 1.3f);

        
        rightJoin = new GameObject("rightJoin");
        rightJoin.transform.SetParent(parent.transform, true);
        LineRenderer rightLine = rightJoin.AddComponent<LineRenderer>();

        rightLine.material = new Material(Shader.Find("Sprites/Default"));
        rightLine.widthMultiplier = 0.3f;
        rightLine.positionCount = 2;
        rightLine.useWorldSpace = false;

        // Create a gradient
        float alpha = 1.0f;
        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(new Color(0.2F, 0.3F, 0.4F, 0.5F), 0.0f), new GradientColorKey(new Color(0.5F, 0.8F, 0.9F, 0.5F), 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
            );

        rightLine.colorGradient = gradient;

        rightLine.SetPosition(0, rightStartPosition);
        rightLine.SetPosition(1, rightEndPosition);
        
    }

    public static void setParent(GameObject p)
    {
        parent = p;
    }
    
    

}
