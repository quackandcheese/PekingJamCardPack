using UnityEditor;
using System;
using System.Collections.Generic;

public class CsprojPostprocessor: AssetPostprocessor {


    private static Dictionary<string, string> ModBundleMap = new Dictionary<string, string>(){
        {"PekingJamCardPack","assets"}
    };


    public static string OnGeneratedCSProject(string path, string content) {
        foreach(var mod in ModBundleMap.Keys){
            if(path.EndsWith($"{mod}.csproj")){
                string newContent = "";
                bool Added = false;
                var lines = content.Split('\n');
                foreach(var line in lines){
                    if(!Added && line.Contains("<Compile Include=")){
                        newContent += $"     <EmbeddedResource Include=\"Assets\\AssetBundles\\{ModBundleMap[mod]}\" />\n";
                        Added = true;
                    }
                    newContent += line + "\n";
                }
                return newContent;
            }
        }
        return content;
    }
}