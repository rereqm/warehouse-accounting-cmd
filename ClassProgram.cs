using System;
using System.IO;

class Program
{
    static Writer writer = new Writer();

    static void AddDataProduct()
    {
        Console.WriteLine("Enter ID: ");
        string ID = Console.ReadLine();
        Console.WriteLine("Enter Name: ");
        string name = Console.ReadLine();
        Console.WriteLine("Enter measure: ");
        string measure = Console.ReadLine();
        Console.WriteLine("Enter price: ");
        string price = Console.ReadLine();
        Console.WriteLine("Enter amount: ");
        string amount = Console.ReadLine();
        Console.WriteLine("Enter suppliercode: ");
        string suppliercode = Console.ReadLine();

        //Izsauc 
        int errorcode = Program.writer.NewdataProduct(ID ,name, measure, price, amount, suppliercode);

        switch (errorcode)
        {
            case 0:
                Console.WriteLine("Done!");
                break;
            case 1:
                Console.WriteLine("Name is too long!");
                break;
            case 2:
                Console.WriteLine("Measure is too long!");
                break;
            case 3:
                Console.WriteLine("Price is too long!");
                break;
            case 4:
                Console.WriteLine("Amount is too long!");
                break;
            case 5:
                Console.WriteLine("Suppliercode is too long!");
                break;
            default:
                Console.WriteLine("Something went wrong!");
                break;
        }
    }
    
      static void ShowDataProduct()
{
    Program.writer.ShowDataProduct();
}

static void SearchDataProduct()
{
    Console.WriteLine("Enter Object ID:");
    string idsearch = Console.ReadLine();
    // kļudu izvade ar case palidz.
    int searcherror = Program.writer.SearchDataProduct(idsearch);

    switch (searcherror)
    {
        case 0:
            Console.WriteLine("Done!");
            break;
        case 1:
            Console.WriteLine("Wrong ID!");
            break;
        default:
            Console.WriteLine("Something went wrong!");
            break;
    }
}
  static void DeleteDataProduct()
{
    //Tiek izvadīts jautājums un tiek nolasīta no konsoles atb.
    Console.WriteLine("Enter Object ID:");
    string idsearch = Console.ReadLine();
    // tiek nodots no citas klases parametrs
    int searcherror = Program.writer.DeleteDataProduct(idsearch);
    //kļudu izsniegšana ar case palidzību.
    switch (searcherror)
    {
        case 0:
            Console.WriteLine("Done!");
            break;
        case 1:
            Console.WriteLine("Wrong ID!");
            break;
        default:
            Console.WriteLine("Something went wrong!");
            break;
    }
}
    static void AddDataDelivery()
    {
        
        Console.WriteLine("Enter suppliercode: ");
        string suppliercode = Console.ReadLine();
        Console.WriteLine("Enter name: ");
        string name = Console.ReadLine();
        Console.WriteLine("Enter legaladdress: ");
        string legaladress = Console.ReadLine();

        int errorcode = Program.writer.NewdataDelivery(suppliercode, name, legaladress);



        switch (errorcode)
        {
            case 0:
                Console.WriteLine("Done!");
                break;
            case 1:
                Console.WriteLine("Suppliercode is too long!");
                break;
            case 2:
                Console.WriteLine("Name is too long!");
                break;
            case 3:
                Console.WriteLine("Legalddress is too long!");
                break;
            default:
                Console.WriteLine("Something went wrong!");
                break;
        }
    }
    static void ShowDataDelivery()
      {
        Program.writer.ShowDataDelivery();
      }
  
    static void SearchDataDelivery()
    {
      Console.WriteLine("Enter Object Suppliercode:");
      string suppliercodesearch = Console.ReadLine();

      int searcherror = Program.writer.SearchDataDelivery(suppliercodesearch);

      switch (searcherror)
      {
        case 0:
            Console.WriteLine("Done!");
            break;
        case 1:
            Console.WriteLine("Wrong Suppliercode!");
            break;
        default:
            Console.WriteLine("Something went wrong!");
            break;
      }
  }
    static void DeleteDataDelivery()
  {
    Console.WriteLine("Enter Object Suppliercode:");
    string idsearch = Console.ReadLine();

    int searcherror = Program.writer.DeleteDataDelivery(idsearch);

    switch (searcherror)
    {
        case 0:
            Console.WriteLine("Done!");
            break;
        case 1:
            Console.WriteLine("Wrong ID!");
            break;
        default:
            Console.WriteLine("Something went wrong!");
            break;
    }
}
    
  
  
    static void AddDataWorker()
    {
        Console.WriteLine("Enter name: ");
        string name = Console.ReadLine();
        Console.WriteLine("Enter age: ");
        string age = Console.ReadLine();
        Console.WriteLine("Enter phonenumber: ");
        string phonenumber = Console.ReadLine();
        Console.WriteLine("Enter salary: ");
        string salary = Console.ReadLine();

        int errorcode = Program.writer.NewdataWorker(name, age, phonenumber, salary);

        switch (errorcode)
        {
            case 0:
                Console.WriteLine("Done!");
                break;
            case 1:
                Console.WriteLine("name is too long!");
                break;
            case 2:
                Console.WriteLine("age is too long!");
                break;
            case 3:
                Console.WriteLine("PhoneNumber is too long!");
                break;
            case 4:
                Console.WriteLine("salary is too long!");
                break;
            default:
                Console.WriteLine("Something went wrong!");
                break;
        }
    }    

    static string[] parse(string line)
    {
        string[] dataArray = line.Split(' ');
        return dataArray;
    }
    static void ShowDataWorker()
      {
        Program.writer.ShowDataWorker();
      }

    static void SearchDataWorker()
      {
        Console.WriteLine("Enter Worker Name:");
    string namesearch = Console.ReadLine();

    int searcherror = Program.writer.SearchDataWorker(namesearch);

    switch (searcherror)
    {
        case 0:
            Console.WriteLine("Done!");
            break;
        case 1:
            Console.WriteLine("Wrong Worker Name!");
            break;
        default:
            Console.WriteLine("Something went wrong!");
            break;
    }
      }
    static void DeleteDataWorker()
  {
    Console.WriteLine("Enter Object Name:");
    string idsearch = Console.ReadLine();

    int searcherror = Program.writer.DeleteDataWorker(idsearch);

    switch (searcherror)
    {
        case 0:
            Console.WriteLine("Done!");
            break;
        case 1:
            Console.WriteLine("Wrong ID!");
            break;
        default:
            Console.WriteLine("Something went wrong!");
            break;
    }
}

    static void FilterErrors(int status)
    {
      // tiek izvadīti filtra kļudas ar case palidzību
      switch (status)
      {
        case 0:
          Console.WriteLine("Done!");
        break;
        case 1:
          Console.WriteLine("ERROR: id was not found");
        break;
        case 2:
          Console.WriteLine("ERROR: invalid argument");
        break;
        case 3:
          Console.WriteLine("ERROR: operation mode");
        break;
        default:
          Console.WriteLine("Something went wrong!");
        break;
      }
    }
    // Šī metode liek lietotājam ievadīt filtra kritērijus un lauku nosaukumus, pēc tam objektā "writer" izsauc metodi datu filtrēšanai.
    static void DataFilterProduct(){
      //pēc kā filtrēsies 
      Console.WriteLine("Enter filter");
      string id = Console.ReadLine();
      Console.WriteLine("Enter field names through a space by which to filter");
      string line = Console.ReadLine();
      //// Aicina lietotājam ievadīt darbības režīmu (vai nu "vai" vai "un")
      Console.WriteLine("Enter operating mode: or/and");
      string oper_mode = Console.ReadLine();
      // Sadala lauku nosaukumus masīvā
      string[] field_arr = parse(line);
      // Objektā "writer" izsauc metodi, lai filtrētu datus, pamatojoties uz dotajiem kritērijiem un lauku nosaukumiem
      int status = Program.writer.DataFilterProduct(id,field_arr,oper_mode);
      FilterErrors(status);  
}



    static void DataFilterDelivery(){
      Console.WriteLine("Enter filter");
      string id = Console.ReadLine();
      Console.WriteLine("Enter field names through a space by which to filter");
      string line = Console.ReadLine();
      Console.WriteLine("Enter operating mode: or/and");
      string oper_mode = Console.ReadLine();
      string[] field_arr = parse(line);
      int status = Program.writer.DataFilterDelivery(id,field_arr,oper_mode);
      FilterErrors(status);
}



    static void DataFilterWorker(){
      Console.WriteLine("Enter filter");
      string id = Console.ReadLine();
      Console.WriteLine("Enter field names through a space by which to filter");
      string line = Console.ReadLine();
      Console.WriteLine("Enter operating mode: or/and");
      string oper_mode = Console.ReadLine();
      string[] field_arr = parse(line);
      int status = Program.writer.DataFilterWorker(id,field_arr,oper_mode);
      FilterErrors(status);
}
  



  
  static void ProgramClose()
  {

        

        Program.writer.ProgramClose();
        Console.WriteLine("Program Successfully Closed");
        
        
  }

  static void ProgramHelp()
  {
    Console.WriteLine("|°=-=-=-=-=-=-=-=-=-=-=-=-=-=-=°|");
    Console.WriteLine("    You are in the Help menu");
    Console.WriteLine("      Here are all commands: ");
    Console.WriteLine("|°=-=-=-=-=-=-=-=-=-=-=-=-=-=-=°|");
    Console.WriteLine("         AddDataProduct");
    Console.WriteLine("         AddDataDelivery");
    Console.WriteLine("         AddDataWorker");
    Console.WriteLine("|°=-=-=-=-=-=-=-=-=-=-=-=-=-=-=°|");
    Console.WriteLine("         ShowDataProduct");
    Console.WriteLine("         ShowDataDelivery");
    Console.WriteLine("         ShowDataWorker");
    Console.WriteLine("|°=-=-=-=-=-=-=-=-=-=-=-=-=-=-=°|");
    Console.WriteLine("         DeleteDataProduct");
    Console.WriteLine("         DeleteDataDelivery");
    Console.WriteLine("         DeleteDataWorker");
    Console.WriteLine("|°=-=-=-=-=-=-=-=-=-=-=-=-=-=-=°|");
    Console.WriteLine("         DataSearchProduct");
    Console.WriteLine("         DataSearchDelivery");
    Console.WriteLine("         DataSearchWorker");
    Console.WriteLine("|°=-=-=-=-=-=-=-=-=-=-=-=-=-=-=°|");
    Console.WriteLine("         DataFilterProduct");
    Console.WriteLine("         DataFilterDelivery");
    Console.WriteLine("         DataFilterWorker");
    Console.WriteLine("|°=-=-=-=-=-=-=-=-=-=-=-=-=-=-=°|");
    Console.WriteLine("         DataSortingProduct");
    Console.WriteLine("         DataSortingDelivery");
    Console.WriteLine("         DataSortingWorker");
    Console.WriteLine("|°=-=-=-=-=-=-=-=-=-=-=-=-=-=-=°|");
    Console.WriteLine("              Close");
    Console.WriteLine("|°=-=-=-=-=-=-=-=-=-=-=-=-=-=-=°|");
    Console.WriteLine();
  }

  static void DataSortingProduct()
  {
    Console.WriteLine("Enter descending order y/n");
    //lai nolasītu doto parametru
    string data = Console.ReadLine();
    bool cnd = data!="y";
    Program.writer.DataSortingProduct(cnd);
  }
  static void DataSortingDelivery()
  {
    Console.WriteLine("Enter descending order y/n");
    string data = Console.ReadLine();
    bool cnd = data!="y";
    Program.writer.DataSortingDelivery(cnd);
  }
  static void DataSortingWorker()
  {
    Console.WriteLine("Enter descending order y/n");
    string data = Console.ReadLine();
    bool cnd = data!="y";
    Program.writer.DataSortingWorker(cnd);
  }

  






  
  static void Main(string[] args)
    {
        Program.writer.Test();
        bool exit = true;

        while (exit)
        {
            Console.WriteLine("|°=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=°|");
            Console.WriteLine("            Welcome to Program");
            Console.WriteLine("    Have some problems? then type 'Help'");
            Console.WriteLine("|°=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=°|");
            Console.WriteLine("           Witch Option You Need?");

            string data = Console.ReadLine();

            switch (data)
            {

                case "AddDataProduct":
                    AddDataProduct();
                    break;
                case "AddDataDelivery":
                    AddDataDelivery();
                    break;
                case "AddDataWorker":
                    AddDataWorker();
                    break;
                case "ShowDataProduct":
                    ShowDataProduct();
                    break;
                case "ShowDataDelivery":
                    ShowDataDelivery();
                    break;
                case "ShowDataWorker":
                    ShowDataWorker();
                    break;
                case "DeleteDataProduct":
                    DeleteDataProduct();
                    break;
                case "DeleteDataDelivery":
                    DeleteDataDelivery();
                    break;
                case "DeleteDataWorker":
                    DeleteDataWorker();
                    break;
                case "SearchDataProduct":
                    SearchDataProduct();
                    break;
                case "SearchDataDelivery":
                    SearchDataDelivery();
                    break;
                case "SearchDataWorker":
                    SearchDataWorker();
                    break;
                case "DataFilterProduct":
                    DataFilterProduct();
                    break;
                case "DataFilterDelivery":
                    DataFilterDelivery();
                    break;
                case "DataFilterWorker":
                    DataFilterWorker();
                    break;
                case "DataSortingProduct":
                    DataSortingProduct();
                    break;
                case "DataSortingDelivery":
                    DataSortingDelivery();
                    break;
                case "DataSortingWorker":
                    DataSortingWorker();
                    break;
                case "Help":
                    ProgramHelp();
                    break;
                case "Close":
                    exit = false;
                    ProgramClose();
                    break;
                default:
                    Console.WriteLine("Invalid option selected");
                    break;
            }
        }
    }
}