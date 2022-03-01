using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtensionsSample : MonoBehaviour
{
    public List<Transform> listOfThisObjectsChildren => transform.GetChildren();
    public Transform[] arrayOfThisObjectsChildren => transform.GetChildrenArray();

    public List<Renderer> rendererListOfThisObjectsChildren => transform.GetRenderers();
    public Renderer[] rendererArrayOfThisObjectsChildren => transform.GetRenderersArray();

    [Space(10)]

    [SerializeField] private string Caution = "The following lists are just to show that GetChildren extension works";

    [Space(10)]
    [SerializeField] private List<Transform> listOfChildren;
    [SerializeField] private Transform[] arrayOfChildren;
    [SerializeField] private List<Renderer> listRenderersOfChildren;
    [SerializeField] private Renderer[] arrayRendererOfChildren;
    
    public RangeString RandomString;
    public RangeInt IntegerRange;
    public RangeFloat FloatRange;
    public RangeColor ColorRange;

    private void Start()
    {
        listOfChildren = listOfThisObjectsChildren;
        arrayOfChildren = arrayOfThisObjectsChildren;
        listRenderersOfChildren = rendererListOfThisObjectsChildren;
        arrayRendererOfChildren = rendererArrayOfThisObjectsChildren;

        Debug.Log($"<color=red>Children of {this.gameObject.name} count from List </color><color=white>{listOfThisObjectsChildren.Count}</color>\n" +
        $"<color=green>Children {this.gameObject.name} count from Array </color><color=white>{arrayOfThisObjectsChildren.Length}</color>"); 
        Debug.Log($"<color=blue>Renderers {this.gameObject.name} count from List </color><color=white>{rendererListOfThisObjectsChildren.Count}</color>\n" + 
        $"<color=cyan>Renderers {this.gameObject.name} count from Array </color><color=white>{rendererArrayOfThisObjectsChildren.Length}</color>");
    }
    
    [ContextMenu("Random Generator")]
    private void RangeTest()
    {
        Debug.Log(IntegerRange.RandomInRange());
        Debug.Log(FloatRange.RandomInRange());
        Debug.Log(ColorRange.RandomInRange());
        Debug.Log(RandomString.RandomInRange());
    }

    [ContextMenu("Change Color From List")]
    private void ChangeColor()
    {
        foreach (Renderer item in rendererListOfThisObjectsChildren)
        {
            item.material.color = Color.red;
        }
    }

    [ContextMenu("Change Color From Array")]
    private void ChangeColor2()
    {
        foreach (Renderer item in rendererArrayOfThisObjectsChildren)
        {
            item.material.color = Color.green;
        }
    }

    [ContextMenu("Shufle List")]
    private void ShuffleList()
    {
        listOfChildren.Shuffle();
    }

    [ContextMenu("Random Item")]
    private void RandomItem()
    {
        Transform t = listOfChildren.RandomItem();
        t.GetComponent<Renderer>().material.color = Color.white;
        Debug.Log($"{listOfChildren.RandomItem().name}<color=orange> this item selected by random</color>");
    }

    [ContextMenu("Remove Random Item")]
    private void RemoveRandomItem()
    {
        Transform t;
        t = listOfChildren.RemoveRandom();
        Destroy(t.gameObject);
        Debug.Log($"{t.name}<color=black> this item selected and removed by random</color>");
    }

}
