using Model;

namespace Control
{
    public sealed class Controller
    {

        public List<Consumable> Product_List { get; set;}

        public Queue<int> Billetes { get; set;}
        private Controller()
        {

            Product_List = new List<Consumable>();

            Product_List.Add(new Consumable("pepsi", 2000, 20));
            Product_List.Add(new Consumable("Coca Cola", 2000, 15));
            Product_List.Add(new Consumable("papitas", 1500, 20));
            Product_List.Add(new Consumable("choco ramo", 2000, 7));

            Billetes = new Queue<int>();
        }

        private static Controller _instance;

        public static Controller GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Controller();
            }

            return _instance;
        }


        public int enqueue_cash()
        {
            Console.WriteLine("Ingrese billetes consecutivamente. Ingrese solo billetes de denominacion de peso colombiano como numeros enteros. Si no desea ingresar mas billetes, deje el campo vacio y presione ENTER");


            bool ingresar_billete = true;

            while (ingresar_billete)
            {
                string input_usuario = Console.ReadLine();

                if (input_usuario == "" && Billetes.Count != 0)
                {
                    ingresar_billete = false;
                }
                else if (input_usuario == "" && Billetes.Count == 0)
                {
                    Console.WriteLine("Ingrese por lo menos un billete");
                }
                else
                {

                    try
                    {
                        Billetes.Enqueue(Convert.ToInt32(input_usuario));
                    }
                    catch (FormatException) 
                    {
                        Console.WriteLine("Por favor ingresa un valor numerico adecuado");
                    }                   
                }
            }

            int total_billetes = 0;

            foreach (int billetes in Billetes)
            {
                total_billetes+= billetes;
            }

            return total_billetes;
        }

        
        public int cashback_algorithm(Consumable product,int monto_cliente)
        {
            product.Quantity = product.Quantity - 1;
            return monto_cliente - product.Price; //Valor de devolucion
        }
        public void llenarInventario(Consumable product, int cantidadporSurtir)
        {
            product.Quantity = product.Quantity + cantidadporSurtir;
          
        }

        public Consumable search_product(string input_selection)
        {
            foreach (Consumable producto in Product_List)
            {
                if (producto.Name == input_selection)
                {
                    return producto;
                }
            }
            throw new ProductNotFoundException("No se encontro el producto");
        }
    }

}