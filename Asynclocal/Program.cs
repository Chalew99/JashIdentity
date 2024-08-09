
using System;
using Asynclocal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Asynclocal
{
    class Program
    {
        static void Main(string[] args)
        {
            // See https://www.stevejgordon.co.uk/aspnet-core-dependency-injection-what-is-the-iservicecollection
            var services = new ServiceCollection();

            services.AddSingleton<ClassA>();
            services.AddSingleton<IThing, ClassB>();
            services.AddSingleton<Endpoint>(new Endpoint("Authorize", "/Authorize"));
            services.AddSingleton<Endpoint>(new Endpoint("AuthorizeCallback", "/AuthorizeCallback"));
            services.AddSingleton<Endpoint>(new Endpoint("createToken", "/createToken"));

            var TService = typeof(IThing);

            // See https://www.stevejgordon.co.uk/aspnet-core-dependency-injection-what-is-the-iserviceprovider-and-how-is-it-built
            var serviceProvider = services.BuildServiceProvider();

            Wrapdecorator.AddDecorator<IThing>(services);

            //var enumerables = IEnumerable<Endpoint>;
            //foreach(Endpoint enum in enumerables)
            //    {
            //        Console.WriteLine(enum.Name);
            //     }   

            Console.WriteLine("Done");
        }
    }

    public interface IThing
    {
        public void DoStuff();
    }

    public class ClassA
    {
        private readonly IThing _dependency;

        public ClassA(IThing thing) => _dependency = thing;

        public void DoWork() => _dependency.DoStuff();
    }

    public class ClassB : IThing
    {
        public void DoStuff()
        {
            // Imagine implementation
        }
    }

    public class Endpoint
    {
        public Endpoint(string name, string path)
        {
            Name = name;
            Path = path;

        }


        public string Name { get; set; }


        public string Path { get; set; }
    }
    }

//using System;
//using System.Reflection;
//using System.Collections.Generic;

//namespace Asynclocal;
//public class Test
//{
//    public static void Main()
//    {
//        Console.WriteLine("\r\n--- Create a constructed type from the generic Dictionary type.");

//        // Create a type object representing the generic Dictionary 
//        // type, by omitting the type arguments (but keeping the 
//        // comma that separates them, so the compiler can infer the
//        // number of type parameters).      
//        Type generic = typeof(Dictionary<,>);
//        DisplayTypeInfo(generic);

//        // Create an array of types to substitute for the type
//        // parameters of Dictionary. The key is of type string, and
//        // the type to be contained in the Dictionary is Test.
//        Type[] typeArgs = { typeof(string), typeof(Test) };

//        // Create a Type object representing the constructed generic
//        // type.
//        Type constructed = generic.MakeGenericType(typeArgs);
//        DisplayTypeInfo(constructed);

//        // Compare the type objects obtained above to type objects
//        // obtained using typeof() and GetGenericTypeDefinition().
//        Console.WriteLine("\r\n--- Compare types obtained by different methods:");

//        Type t = typeof(Dictionary<String, Test>);
//        Console.WriteLine("\tAre the constructed types equal? {0}", t == constructed);
//        Console.WriteLine("\tAre the generic types equal? {0}",
//            t.GetGenericTypeDefinition() == generic);

//        Type decorator = typeof(Decorator<,>);
//        DisplayTypeInfo(decorator);

//    }

//    private static void DisplayTypeInfo(Type t)
//    {
//        Console.WriteLine("\r\n{0}", t);

//        Console.WriteLine("\tIs this a generic type definition? {0}",
//            t.IsGenericTypeDefinition);

//        Console.WriteLine("\tIs it a generic type? {0}",
//            t.IsGenericType);

//        Type[] typeArguments = t.GetGenericArguments();
//        Console.WriteLine("\tList type arguments ({0}):", typeArguments.Length);
//        foreach (Type tParam in typeArguments)
//        {
//            Console.WriteLine("\t\t{0}", tParam);
//        }
//    }
//}



//namespace Asynclocal
//{

//using System;
//using System.Threading;
//using System.Threading.Tasks;

//class Example
//    {
//        static AsyncLocal<string> _asyncLocalString = new AsyncLocal<string>();

//        static ThreadLocal<string> _threadLocalString = new ThreadLocal<string>();

//        static async Task AsyncMethodA()
//        {
//            // Start multiple async method calls, with different AsyncLocal values.
//            // We also set ThreadLocal values, to demonstrate how the two mechanisms differ.
//            _asyncLocalString.Value = "Value 1";
//            _threadLocalString.Value = "Value 1";
//            var t1 = AsyncMethodB("Value 1");

//            _asyncLocalString.Value = "Value 2";
//            _threadLocalString.Value = "Value 2";
//            var t2 = AsyncMethodB("Value 2");

//            // Await both calls
//            await t1;
//            await t2;
//        }

//        static async Task AsyncMethodB(string expectedValue)
//        {
//            Console.WriteLine("Entering AsyncMethodB.");
//            Console.WriteLine("   Expected '{0}', AsyncLocal value is '{1}', ThreadLocal value is '{2}'",
//                              expectedValue, _asyncLocalString.Value, _threadLocalString.Value);
//            await Task.Delay(100);
//            Console.WriteLine("Exiting AsyncMethodB.");
//            Console.WriteLine("   Expected '{0}', got '{1}', ThreadLocal value is '{2}'",
//                              expectedValue, _asyncLocalString.Value, _threadLocalString.Value);
//        }

//        static async Task Main(string[] args)
//        {
//            await AsyncMethodA();
//        }
//    }
//    // The example displays the following output:
//    //   Entering AsyncMethodB.
//    //      Expected 'Value 1', AsyncLocal value is 'Value 1', ThreadLocal value is 'Value 1'
//    //   Entering AsyncMethodB.
//    //      Expected 'Value 2', AsyncLocal value is 'Value 2', ThreadLocal value is 'Value 2'
//    //   Exiting AsyncMethodB.
//    //      Expected 'Value 2', got 'Value 2', ThreadLocal value is ''
//    //   Exiting AsyncMethodB.
//    //      Expected 'Value 1', got 'Value 1', ThreadLocal value is ''
//}

