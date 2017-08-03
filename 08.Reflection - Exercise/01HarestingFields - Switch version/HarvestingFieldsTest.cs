namespace _01HarestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            Type harvestingFieldsType = typeof(HarvestingFields);
            FieldInfo[] harvestingFields = harvestingFieldsType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            FieldInfo[] gatherdFields;
            string requestedAccMod;
            while ((requestedAccMod = Console.ReadLine()) != "HARVEST")
            {
                switch (requestedAccMod)
                {
                    case "private":
                        gatherdFields = harvestingFields.Where(f => f.IsPrivate).ToArray();
                        break;
                    case "protected":
                        gatherdFields = harvestingFields.Where(f => f.IsFamily).ToArray();
                        break;
                    case "public":
                        gatherdFields = harvestingFields.Where(f => f.IsPublic).ToArray();
                        break;
                    case "all":
                        gatherdFields = harvestingFields;
                        break;
                    default:
                        gatherdFields = null;
                        break;
                }

                string[] result = gatherdFields.Select(f => 
                       $"{f.Attributes.ToString().ToLower()} {f.FieldType.Name} {f.Name}")
                       .ToArray();
                Console.WriteLine(string.Join(Environment.NewLine, result).Replace("family", "protected"));
            }
        }
    }
}
