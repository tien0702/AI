using SimpleJSON;
using System;
using System.Reflection;
using UnityEngine;

namespace TT
{
    [System.Serializable]
    public class NodeInfo
    {
        public string ClassName;
        public string ClassInfoName;
    }

    public class NodeType
    {
        public Type ClassType;
        public object ClassInfoData;
    }

    public class NodeUtils
    {
        public static NodeType[] GetNodeTypes(JSONArray array)
        {
            NodeType[] result = new NodeType[array.Count];
            for (int i = 0; i < array.Count; ++i)
            {
                result[i] = GetNodeType(array[i]);
            }
            return result;
        }

        public static NodeType GetNodeType(JSONNode json)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            NodeInfo nodeInfo = GetNodeInfo(json);

            NodeType nodeType = new NodeType();
            nodeType.ClassType = assembly.GetType(nodeInfo.ClassName);


            if (nodeInfo.ClassInfoName != null && !nodeInfo.ClassInfoName.Equals(string.Empty))
            {
                nodeType.ClassInfoData = JsonUtility.FromJson(json["data"].ToString()
                    , assembly.GetType(nodeInfo.ClassInfoName));
            }

            return nodeType;
        }

        private static NodeInfo GetNodeInfo(JSONNode json)
        {
            NodeInfo info = JsonUtility.FromJson<NodeInfo>(json.ToString());
            if (info == null)
            {
                Debug.LogWarning("Data is null");
                return null;
            }

            return info;
        }

        /*public static NodeInfo[] GetNodeInfos(string rawData)
        {
            JSONNode json = JSONObject.Parse(rawData);
            if(!json.IsArray)
            {
                Debug.Log("RawData is not array");
                return null;
            }

            NodeInfo[] infos = new NodeInfo[json.Count];
            for(int i = 0; i < json.Count; ++i)
            {
                infos[i] = GetNodeInfo(json[i]);
            }

            return infos;
        }*/

        /*public static NodeType GetNodeType(NodeInfo info)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            NodeType nodeType = new NodeType();
            nodeType.ClassType = assembly.GetType(info.ClassName);
            string componentData = info.data;
            if (componentData != null && !info.ClassInfoName.Equals(string.Empty))
            {
                nodeType.ClassInfoData = JsonUtility.FromJson(componentData, assembly.GetType(info.ClassInfoName));
            }

            return nodeType;
        }

        public static NodeType[] GetNodeTypes(NodeInfo[] infos)
        {
            NodeType[] nodeTypes = new NodeType[infos.Length];
            for(int i = 0; i < infos.Length; ++i)
            {
                nodeTypes[i] = GetNodeType(infos[i]);
            }

            return nodeTypes;
        }*/
    }
}
