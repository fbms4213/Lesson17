#define Debug
// #undef Debug


using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Lesson17_ReflectionAndAttribute;

#nullable disable



//// Pre-defined attributes
//// Custom attributes


// [Obsolete]
// [CallerMemberName]
// [Conditional]
// [CallerArgumentExpression]




[Obsolete("Köhnəlmiş class-di")]
class Student : INotifyPropertyChanged
{
    [Obsolete("Köhnəlmiş property-di", true)]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }

    private int myVar;

    public int MyProperty
    {
        get { return myVar; }
        set
        {

            myVar = value;
            NotifyPropertyChanged();
        }
    }


    public Student()
    {
        Console.WriteLine("Student Constructor");
    }

    public event PropertyChangedEventHandler PropertyChanged;


    private void NotifyPropertyChanged(string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

struct Location
{
    public double Longitude { get; set; }
    public double Latitude { get; set; }

    [Conditional("Debug")]
    public void Print()
    {
        Console.WriteLine($"Longitude: {Longitude}");
        Console.WriteLine($"Latitude: {Latitude}");
    }
}






[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
class ColumnNameAttribute : Attribute
{
    public string Name { get; set; }

    public ColumnNameAttribute(string name)
    {
        Name = name;
    }
}


class Car
{
    [ColumnName("Identification")]
    public int Id { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
}






class Program
{
    static void Write(object obj, [CallerArgumentExpression("obj")] string msj = null)
    {
        Console.WriteLine($"Expression {msj}");
    }


    static void Main()
    {
        #region Pre-defined attribute

        //// Obsolete
        // Student s = new();
        // // s.Id = 10;




        //// Conditional
        // Location loc = new();
        // loc.Print();




        // Write(new object());
        // Write("Hello World");
        // Write(42 + 42 + 42);
        // Write(() => { });
        // 
        // int i = 10;
        // Write(i);

        #endregion




        #region Reflection
        // Assembly assembly = Assembly.GetExecutingAssembly();
        // 
        // // assembly.CreateInstance("Lesson17_ReflectionAndAttribute.Student");
        // 
        // 
        // var types = assembly.GetTypes();
        // 
        // foreach (var type in types)
        // {
        //     Console.WriteLine(type.FullName);
        // 
        // 
        // 
        //     foreach (var propInfo in type.GetProperties())
        //     {
        //         Console.WriteLine(propInfo.Name);
        //         Console.WriteLine(propInfo.PropertyType.Name);
        //         Console.WriteLine(propInfo.PropertyType.IsPublic);
        //     }
        // 
        //     Console.WriteLine();
        // }
        #endregion




        #region Custom attribute

        var properties = typeof(Car).GetProperties();

        foreach (var property in properties)
        {
            if(Attribute.IsDefined(property, typeof(ColumnNameAttribute)))
                Console.WriteLine(property.GetCustomAttribute<ColumnNameAttribute>().Name);
            else
                Console.WriteLine(property.Name);
        }

        #endregion
    }
}