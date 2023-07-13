using Control;
using Model;

internal static class ViewHelpers
{
    private static void Main(string[] args)
    {
        Controller controller = Controller.GetInstance();
        Console.WriteLine("Bienvenido a la maquina expendora");
        string input_cliente = "";
        int total_cash_global;
        do
        {
            Console.WriteLine("Ingrese si es cliente o proveedor: [C] o [P]");

            input_cliente = Console.ReadLine();

            if (input_cliente == "C" || input_cliente == "P")
            {
                break;
            }
            else
            {
                Console.WriteLine("Ingrese un valor correcto");
            }

        } while (true);

        Console.WriteLine("Estos son nuestros productos:");

        Action<string> print = (texto) => Console.WriteLine(texto);

        foreach (Consumable producto in controller.Product_List)
        {
            print(producto.ToString());
        }

        if (input_cliente == "C")
        {
            Consumable producto_escogido = null;
            while (true)
            {
                total_cash_global = 0;
                int total_cash = controller.enqueue_cash();
                total_cash_global = total_cash;

                Console.WriteLine("El total de dinero ingresado es: " + total_cash);

                Console.WriteLine("Seleccione uno de los productos indicando su nombre.Si desea ingresar mas billetes,escriba [0]");

                string input_selection = Console.ReadLine();

                if (input_selection == "B")
                {
                    continue;
                }
                try
                {
                    producto_escogido = controller.search_product(input_selection);
                    if (producto_escogido != null)
                    {
                        break;
                    }
                }
                catch (ProductNotFoundException e)
                {
                    Console.WriteLine("Ingrese el nombre del producto correcto.");
                }
            }




            Console.WriteLine("La devuelta es: " + controller.cashback_algorithm(producto_escogido, total_cash_global));
            //Final codigo cliente 

        }
        else if (input_cliente == "P")
        {


            Consumable producto_escogido = null;
            bool continuar = true;
            while (continuar)
            {


                Console.WriteLine("Seleccione que producto desea surtir");

                string input_selection = Console.ReadLine();
                if (input_selection == "B")
                {
                    continue;
                }


                try
                {
                    producto_escogido = controller.search_product(input_selection);
                    if (producto_escogido != null)
                    {
                        continuar = false;
                    }
                }
                catch (ProductNotFoundException e)
                {
                    Console.WriteLine("Ingrese el nombre del producto correcto.");
                }
                

            }
            controller.llenarInventario(producto_escogido, 2);

            Console.WriteLine("productos actualizados:");

            Action<string> printInventario = (texto) => Console.WriteLine(texto);

            foreach (Consumable producto in controller.Product_List)
            {
                printInventario(producto.ToString());
            }

        }
    }
}