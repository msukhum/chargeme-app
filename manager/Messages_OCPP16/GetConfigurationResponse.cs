﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace manager.Messages_OCPP16
{
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.3.1.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class GetConfigurationResponse
    {
        [Newtonsoft.Json.JsonProperty("configurationKey", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.Required]
        public System.Collections.Generic.ICollection<ConfigurationKey> ConfigurationKey { get; set; } = new System.Collections.ObjectModel.Collection<ConfigurationKey>();

        [Newtonsoft.Json.JsonProperty("unknownKey", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(50)]
        public System.Collections.Generic.ICollection<string> UnknownKey { get; set; } = new System.Collections.ObjectModel.Collection<string>();
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.3.1.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class ConfigurationKey
    {
        [Newtonsoft.Json.JsonProperty("key", Required = Newtonsoft.Json.Required.Always)]
        [System.ComponentModel.DataAnnotations.StringLength(50)]
        public string Key { get; set; }

        [Newtonsoft.Json.JsonProperty("readonly", Required = Newtonsoft.Json.Required.Always)]
        public Boolean Readonly { get; set; }

        [Newtonsoft.Json.JsonProperty("value", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [System.ComponentModel.DataAnnotations.StringLength(500)]
        public string Value { get; set; }
    }
}
