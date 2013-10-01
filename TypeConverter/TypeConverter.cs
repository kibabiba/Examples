using System.Reflection;

namespace TypeConverter
{
    public class TypeConverter<T, TU>
        where TU : class, new()
        where T : class
    {
        public TU Convert(T inputClass)
        {
            if (inputClass == null) 
                return null;

            var resultClass = new TU();
            var properties = resultClass.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var property in properties)
            {
                if (!property.CanWrite)
                    continue;

                var currentProperty = inputClass.GetType().GetProperty(property.Name);
                if (currentProperty == null) 
                    continue;

                var newValue = currentProperty.GetValue(inputClass, null);
                property.SetValue(resultClass, newValue, null);
            }
            return resultClass;
        }
    }
}
