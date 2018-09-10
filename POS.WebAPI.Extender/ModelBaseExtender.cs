using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace POS.WebAPI.Extender
{
    public static class ModelBaseExtender
    {
        public static string SerializeObject<TEntity>(this TEntity inputObject) where TEntity : class
        {
            return JsonConvert.SerializeObject(inputObject, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
        }
    }
}
