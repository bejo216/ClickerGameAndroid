using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TreeDatabase", menuName = "Scriptable Objects/TreeDatabase")]
public class TreeDatabase : ScriptableObject
{
    public List<Tree> trees;

    public Tree getTreeByID(int id)
    {
        return trees.Find(tree => tree.treeID == id);
    }








}
