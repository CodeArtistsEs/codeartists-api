using System;
using Newtonsoft.Json;

namespace codeartistsapi.Helpers
{
    [JsonObject(MemberSerialization.OptIn)]
    public class JsonResponse<TData, TError>
    {
        [JsonProperty("ok")]
        public bool Ok { get; }
        [JsonProperty("data")]
        public TData Data { get; }
        [JsonProperty("error")]
        public TError Error { get; }

        public JsonResponse(TData data)
        {
            Data = data;
            Ok = true;
        }

        public JsonResponse(TError error)
        {
            Error = error;
            Ok = false;
        }

        public bool ShouldSerializeData()
        {
            return Ok;
        }

        public bool ShouldSerializeError()
        {
            return !Ok;
        }
    }
}