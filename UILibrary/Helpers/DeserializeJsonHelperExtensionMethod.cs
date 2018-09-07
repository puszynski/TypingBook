using System;
using System.Collections.Generic;
using System.Text;

namespace UILibrary.Helpers
{
    public static class DeserializeJsonHelperExtensionMethod
    {
        public static string HelloFromExtensionMethod(this IDeserializeJsonHelper deserializeParam) // this klasa/interface parametry => dodajemy metody rozszeżające, można je wywoływać jak normalną metodą danej klasy/interfacu 
        {
            var exampleOfTheAnonimazeType = new
            {
                Name = "MVC",
                Categroy = "Without"
            };

            var exampleOfTheArrayOfTheAnonimazeType = new[]
            {
                new { Name = "Test01", Age = 10 },
                new { Name = "Test02", Age = 12 }
            };

            var result = new StringBuilder();
            foreach (var item in exampleOfTheArrayOfTheAnonimazeType)
            {
                result.Append(item.Name).Append(" ");
            }

            return "Hi from extension method!";
        }
    }
}
