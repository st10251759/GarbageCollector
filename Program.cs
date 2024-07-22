namespace LU1__GarbageCollector
{
    class Program
    {
        static void Main(string[] args)
        {
            //create some objects (simukate memory collection)
            for (int i =0; i < 1000; i++)//loop for 1000 times
          {
                var obj = new SomeObject(i);
                //In each iteration, creates a new instance of SomeObject with the current loop index as its ID
                //Object is stored in the local variable 'obj' which will be out of scope & eligable for the
                //garbage collection after each iteration

            }//for
            
         GC.Collect(); //explcitly trigger garbage collection  to reclaim memory from objects that are no longer in use
        GC.WaitForPendingFinalizers();
            //Wait for the garbage collector to finalize objects that are eligable for clean-up

            Console.WriteLine("Garbage Collection Completed"); //Output message
        }
    }
    class SomeObject
        //Define a class called SomeObject that simulates objects being collected

    {
        private readonly int id; //Private field that stores the objects id

        public SomeObject(int id) //Constructor that takes an integer parameter to intialize the object's ID
        {
            this.id = id;//Assign the passed parameter to the private field
        }

        //Destructor (finalizer)
        ~SomeObject() 
            //Destructor method has a ~ that precedes the method name
            //Called before the garbage collector tidy up resources
        {
            Console.WriteLine($"Object {id} finzalized");
        }
    }
}
