using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventBroker 
{
      class Program
      {
         static void Main(string[] args)
         {
               Console.WriteLine("Press X key to 'click' the button!");
               var key = Console.ReadLine();
               if (key == "x")
               {
                  XPressed();
               }
               else
               {
                  Console.WriteLine("You didn't press X!");
               }
         }

         static void XPressed()
         {
            Button button = new Button();
            button.Click += (src, args) =>
            {
            Console.WriteLine($"You X-pressed yourself, {args.Name}!");
            };
            button.OnClick(); 
         }
      }

      public class Button
      {
         public event EventHandler<CustomArgs> Click;
         public void OnClick()
         {
            CustomArgs args = new CustomArgs();
            args.Name = "Bill";
            Click.Invoke(this, args);
         }
      }

      // CustomArgs inherits from EventArgs
      public class CustomArgs: EventArgs
      {
         public string Name { get; set; }
      }
      
}


