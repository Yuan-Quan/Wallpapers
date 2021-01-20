using CommandDotNet;

namespace cli
{
    class Program
    {
        static void Startup()
        {
           //debug code here
            
        }
        static int Main(string[] args)
        {
            //Startup();
            return new AppRunner<MainEntry>()
                .UseDefaultMiddleware()
                .Run(args);
            
            //return 0;
        }   
    }
}
