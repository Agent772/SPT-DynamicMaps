using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace DynamicMaps.Immersion
{
    #region Variables and Declerations
    internal class ImmersionMarkerRequirementsDef
        {
            [JsonRequired]
            public string Map { get; set; }

            [JsonRequired]
            public string PlayerPosition { get; set; }

            [JsonRequired]
            public string EnemyPosition { get; set; }

            [JsonRequired]
            public string DoorMarker { get; set; }

            [JsonRequired]
            public string QuestMarker { get; set; }

            [JsonRequired]
            public string ExtractionMarker { get; set; }

            [JsonRequired]
            public string AirdropMarker { get; set; }

            [JsonRequired]
            public string BTRMarker { get; set; }

            [JsonRequired]
            public int CorpseMarker { get; set; }

            [JsonRequired]
            public int BackpackMarker { get; set; }
        }

        internal class ImmersionMapRequirementsDef
        {
            [JsonRequired]
            public string MapID { get; set; }
            [JsonRequired]
            public ImmersionMarkerRequirementsDef RequiredItems { get; set; }
        }

        internal class ImmersionSettings
        {
            [JsonRequired]
            public List<ImmersionMapRequirementsDef> Requirements { get; set; }

            private string ConfigFile = Path.Combine(Plugin.Path, "config", "config.json");

            public bool Loaded { get; set; }
 

            public void Init()
            {
                try
                {
                    JsonConvert.DeserializeObject<ImmersionSettings>(File.ReadAllText(ConfigFile));
                    Loaded = true;
                }
                catch (Exception e)
                {
                    Plugin.Log.LogError($"Loading MapsRequirementsConfigDef failed from json at path: {ConfigFile}");
                    Plugin.Log.LogError($"Exception given was: {e.Message}");
                    Plugin.Log.LogError($"{e.StackTrace}");
                }
            }
        }
    # endregion
}