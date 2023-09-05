using System.Reflection;

namespace Drona.AyushmanBharat.Infrastructure.Utilities
{
    public static class ObjectExtension
    {
        public static T Cast<T>(this Object myobj)
        {
            Type objectType = myobj.GetType();
            Type target = typeof(T);
            var x = Activator.CreateInstance(target, false);
            var z = from source in objectType.GetMembers().ToList()
                    where source.MemberType == MemberTypes.Property
                    select source;
            var d = from source in target.GetMembers().ToList()
                    where source.MemberType == MemberTypes.Property
                    select source;
            List<MemberInfo> members = d.Where(memberInfo => d.Select(c => c.Name)
               .ToList().Contains(memberInfo.Name)).ToList();
            PropertyInfo propertyInfo;
            object value;
            foreach (var memberInfo in members)
            {
                propertyInfo = typeof(T).GetProperty(memberInfo.Name);

                if (myobj.GetType().GetProperty(memberInfo.Name) == null)
                    value =  GetDefault(propertyInfo.PropertyType);
                else
                    value = myobj.GetType().GetProperty(memberInfo.Name).GetValue(myobj, null);
                
                propertyInfo.SetValue(x, value, null);
            }
            return (T)x;
        }

        private static object GetDefault(Type type)
        {
            if (type.IsValueType)
            {
                return Activator.CreateInstance(type);
            }
            return null;
        }
    }
}
