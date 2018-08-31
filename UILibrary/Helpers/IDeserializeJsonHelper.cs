using System;
using System.Collections.Generic;
using System.Text;

namespace UILibrary.Helpers
{
    public interface IDeserializeJsonHelper
    {
        T DeserializeJsonData<T>(string url) where T : new();
    }
}
