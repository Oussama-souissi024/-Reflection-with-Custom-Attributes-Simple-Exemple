using System;
using System.Reflection;
using System.Xml.Linq;

class Program
{
	// Step 1: Define the Custom Attribute
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
	public class MyCustomAttribute : Attribute
	{
		public string Description { get; }

		public MyCustomAttribute(string description)
		{
			Description = description;
		}
	}

	// Step 2: Apply the Custom Attribute
	[MyCustom("This is a class attribute")]
	class MyClass
	{
		[MyCustom("This is a method attribute")]
		public void MyMethod()
		{
			// Method implementation
		}
	}

	static void Main()
	{
		//Step 3: Retrieve Attribute Information at Runtime

		// Get the type of MyClass
		Type type = typeof(MyClass);

		// Get class-level attributes
		object[] classAttributes = type.GetCustomAttributes(typeof(MyCustomAttribute), false);

		foreach (MyCustomAttribute attribute in classAttributes)
		{
			Console.WriteLine($"Class Attribute: {attribute.Description}");
		}

		// Get method-level attributes
		MethodInfo methodInfo = type.GetMethod("MyMethod");
		object[] methodAttributes = methodInfo.GetCustomAttributes(typeof(MyCustomAttribute), false);

		foreach (MyCustomAttribute attribute in methodAttributes)
		{
			Console.WriteLine($"Method Attribute: {attribute.Description}");
		}

		Console.ReadKey();

		//Step 4: Compile and Run

		//   Compile the code and run it.
		//   The output should display the descriptions provided in the custom attributes.
		//   This is a basic example, and in real - world scenarios,
		//   custom attributes can be more complex and used for various purposes,
		//   such as configuration, validation, or documentation.
		//   The key is to apply them to the appropriate elements in your code and 
		//   use reflection to access the attribute information at runtime.


	}
}