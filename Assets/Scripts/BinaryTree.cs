using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinaryTree : MonoBehaviour {

    public GameObject treeNode;
    private GameObject rootNode;
    private TreeNode rootNodeScript;

    private Vector2 mousePos;
    private Vector3 screenPos;
    public Camera camera;
    public float speed;

    private int degs = 0;

	// Use this for initialization
	void Start () {
        camera = Camera.main;
        initRoot();
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("up"))
        {
            rootNode.transform.Translate(Vector3.right * 1.0f);
            //rootNode.transform.localPosition += new Vector3(1, 0, 0);

            rootNodeScript = rootNode.GetComponent<TreeNode>();
            if (rootNodeScript != null)
            {
                //rootNodeScript.updatePosition(new Vector3(0, 1, 0));
            }
        }

        if (Input.GetKeyDown("left"))
        {
            rootNodeScript = rootNode.GetComponent<TreeNode>();
            if (rootNodeScript != null)
            {
                degs += 1;
                //rootNodeScript.updateRotation(rootNode.transform.position, new Vector3(-3f, 0, 0));
            }
        }

        if (Input.GetKeyDown("right"))
        {
            rootNodeScript = rootNode.GetComponent<TreeNode>();
            if (rootNodeScript != null)
            {
                degs -= 1;
                //rootNodeScript.updateRotation(rootNode.transform.position, new Vector3(3f, 0, 0));
            }
        }


        if (Input.GetKeyUp(KeyCode.Z))
        {
            Debug.Log("DOT");
        }

        if (Input.GetKeyUp(KeyCode.M))
        {
            Debug.Log("DASH");
        }

        
        


    }

    void initRoot()
    {

        rootNode = Instantiate(treeNode);
        TreeNode.setParent(rootNode);

        rootNode.name = "Root";
        rootNode.transform.SetParent(transform);

        Vector3 pos = transform.position;
        pos.z += 29;
        pos.y += 0;
        pos.x += 12;
        transform.position = pos;

        if (rootNode != null)
        {
            rootNodeScript = rootNode.GetComponent<TreeNode>();
            if (rootNodeScript != null)
            {

                rootNodeScript.setValue('*');
                rootNodeScript.setIndex(32);
                
            }
        }

        initTree();
    }

    void initTree()
    {
        rootNodeScript.insert(16,   'E');
       rootNodeScript.insert(48,   'T');

       
      rootNodeScript.insert(8,    'I');
      rootNodeScript.insert(24,   'A');
      rootNodeScript.insert(40,   'N');
      rootNodeScript.insert(56,   'M');

        
      rootNodeScript.insert(4,    'S');
      rootNodeScript.insert(12,   'U');
      rootNodeScript.insert(20,   'R');
      rootNodeScript.insert(28,   'W');
      rootNodeScript.insert(36,   'D');
      rootNodeScript.insert(44,   'K');
      rootNodeScript.insert(52,   'G');
      rootNodeScript.insert(60,   'O');
        
      rootNodeScript.insert(2,    'H');
      rootNodeScript.insert(6,    'V');
      rootNodeScript.insert(10,   'F');
      rootNodeScript.insert(14,   'Ü');
      rootNodeScript.insert(18,   'L');
      rootNodeScript.insert(22,   'Ä');
      rootNodeScript.insert(26,   'P');
      rootNodeScript.insert(30,   'J');
      rootNodeScript.insert(34,   'B');
      rootNodeScript.insert(38,   'X');
      rootNodeScript.insert(42,   'C');
      rootNodeScript.insert(46,   'Y');
      rootNodeScript.insert(50,   'Z');
      rootNodeScript.insert(54,   'Q');
      rootNodeScript.insert(58,   'Ö');
      rootNodeScript.insert(62,   '-');

      rootNodeScript.insert(1,    '5');
      rootNodeScript.insert(3,    '4');
      rootNodeScript.insert(5,    'Ś');
      rootNodeScript.insert(7,    '3');
      rootNodeScript.insert(9,    'É');
      rootNodeScript.insert(11,   '-');
      rootNodeScript.insert(13,   'Ð');
      rootNodeScript.insert(15,   '2');
      rootNodeScript.insert(17,   '&');
      rootNodeScript.insert(19,   'É');
      rootNodeScript.insert(21,   '+');
      rootNodeScript.insert(23,   '-');
      rootNodeScript.insert(25,   '-');
      rootNodeScript.insert(27,   'À');
      rootNodeScript.insert(29,   'ĵ');
      rootNodeScript.insert(31,   '1');
      rootNodeScript.insert(33,    '6');
      rootNodeScript.insert(35,   '=');
      rootNodeScript.insert(37,   '/');
      rootNodeScript.insert(39,   '-');
      rootNodeScript.insert(41,   'Ç');
      rootNodeScript.insert(43,   '-');
      rootNodeScript.insert(45,   '(');
      rootNodeScript.insert(47,   '-');
      rootNodeScript.insert(49,    '7');
      rootNodeScript.insert(51,   '-');
      rootNodeScript.insert(53,   'Ğ');
      rootNodeScript.insert(55,   'Ñ');
      rootNodeScript.insert(57,    '8');
      rootNodeScript.insert(59,   '-');
      rootNodeScript.insert(61,   '9');
      rootNodeScript.insert(63,   '0');
      

    }
}
