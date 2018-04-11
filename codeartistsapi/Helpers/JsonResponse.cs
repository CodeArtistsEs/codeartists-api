using System;
using System.Collections;
using System.Collections.Generic;
using codeartistsapi.Models;
using Newtonsoft.Json;

namespace codeartistsapi.Helpers
{
    [JsonObject(MemberSerialization.OptIn)]
    public class JsonResponse
    {
        [JsonProperty("ok")] public bool Ok { get; set; }

        [JsonProperty("error")] public object Error { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class JsonResponse<TError> : JsonResponse
    {
        public new TError Error => (TError) base.Error;
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class JsonDataResponse : JsonResponse
    {
        [JsonProperty("data")] public object Data { get; set; }
  
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class JsonDataResponse<TError, TData> : JsonDataResponse
    {
        public new TData Data => (TData) base.Data;
        public new TError Error => (TError) base.Error;
    }
}