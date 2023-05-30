using System;
using System.IO;
using System.Collections.Generic;

public class Writer
{  //fields un Const Vardu limits
    private StreamWriter streamProduct;
    private StreamWriter streamDelivery;
    private StreamWriter streamWorker;
    private StreamReader streamReadProduct;
    private StreamReader streamReadDelivery;
    private StreamReader streamReadWorker;
    private const string PRODUCTFILENAME = "Product";
    private const string DELIVERYFILENAME = "Delivery";
    private const string WORKERFILENAME = "Worker";
    private const int PRODUCTNAMEMAXLEANGHT = 50;
    private const int PRODUCTMEASUREMAXLEANGHT = 20;
    private const int PRODUCTPRICEMAXLEANGHT = 7;
    private const int PRODUCTAMOUNTMAXLEANGHT = 10;
    private const int PRODUCTSUPPLIERCODEMAXLEANGHT = 15;
    private const int PRODUCTIDMAXLEANGHT = 10;
    private const int DELIVERYSUPPLIERCODEMAXLEANGHT = 20;
    private const int DELIVERYNAMEMAXLEANGHT = 50;
    private const int DELIVERYLEGALDDRESS = 50;
    private const int DELIVERYIDMAXLEANGHT = 20;
    private const int WORKERNAMEMAXLEANGHT = 50;
    private const int WORKERAGEMAXLEANGHT = 3;
    private const int WORKERPHONENUMBERMAXLEANGHT = 12;
    private const int WORKERSALARYMAXLEANGHT = 10;
    private const int WORKERIDMAXLEANGHT = 20;
    private int[] PRODUCTMAXLENS = {PRODUCTIDMAXLEANGHT,PRODUCTNAMEMAXLEANGHT,PRODUCTMEASUREMAXLEANGHT,PRODUCTPRICEMAXLEANGHT,PRODUCTAMOUNTMAXLEANGHT,PRODUCTSUPPLIERCODEMAXLEANGHT};
    private string[] PRODUCTNAMEOFFIELDS = {"ID","Name","Measure","Price","Amount","Suppliercode"};
    private int[] DELIVERYMAXLENS = {DELIVERYSUPPLIERCODEMAXLEANGHT,DELIVERYNAMEMAXLEANGHT,DELIVERYLEGALDDRESS};
    private string[] DELIVERYNAMEOFFIELDS = {"Suppliercode","Name","Legaladdress"};
    private int[] WORKERMAXLENS = {WORKERNAMEMAXLEANGHT,WORKERAGEMAXLEANGHT,WORKERPHONENUMBERMAXLEANGHT,WORKERSALARYMAXLEANGHT};
    private string[] WORKERNAMEOFFIELDS = {"Name","Age","Phonenumber","Salary"};

    public Writer()

    {  //konstruktors
        this.streamProduct = new StreamWriter(PRODUCTFILENAME,append:true);
        this.streamDelivery = new StreamWriter(DELIVERYFILENAME,append:true);
        this.streamWorker = new StreamWriter(WORKERFILENAME,append:true);
        this.streamReadProduct = new StreamReader(PRODUCTFILENAME);
        this.streamReadDelivery = new StreamReader(DELIVERYFILENAME);
        this.streamReadWorker = new StreamReader(WORKERFILENAME);
    }

    public int NewdataProduct(string ID,string name, string measure, string price, string amount, string suppliercode)
      //Tiek salīdzināts ievadītais vārds ar tā maksimālo limitu, ja tiek pārsniegts tad tiks izvadīta kļuda ja nē tad dotie dati tiks ierakstīti fila.
    {
        if (name.Length > PRODUCTNAMEMAXLEANGHT)
        {
            return 1;
        }
        if (measure.Length > PRODUCTMEASUREMAXLEANGHT)
        {
            return 2;
        }
        if (price.Length > PRODUCTPRICEMAXLEANGHT)
        {
            return 3;
        }
        if (amount.Length > PRODUCTAMOUNTMAXLEANGHT)
        {
            return 4;
        }
        if (suppliercode.Length > PRODUCTSUPPLIERCODEMAXLEANGHT)
        {
            return 5;
        }
        if (ID.Length > PRODUCTIDMAXLEANGHT)
        {
            return 6;
        }
        
        Field completename = new Field(PRODUCTNAMEMAXLEANGHT, name);
        Field completemeasure = new Field(PRODUCTMEASUREMAXLEANGHT, measure);
        Field completeprice = new Field(PRODUCTPRICEMAXLEANGHT, price);
        Field completeamount = new Field(PRODUCTAMOUNTMAXLEANGHT, amount);
        Field completesuppliercode = new Field(PRODUCTSUPPLIERCODEMAXLEANGHT, suppliercode);
        Field completeid = new Field(PRODUCTIDMAXLEANGHT, ID);
        //tiek izvadīti faila mūsu field + tiek pievienoti '~' lai vieglāk taisītu tabulu kā arī lai aizpildītu tukšās limita vietas ar dotajiem '~' simboliem.
        string res = completeid.completeField() +completename.completeField() + completemeasure.completeField() + completeprice.completeField() + completeamount.completeField() + completesuppliercode.completeField();
        streamProduct.WriteLine(res);
        streamProduct.Flush();


        return 0;

    }
    public int NewdataDelivery(string suppliercode, string name, string legalddress)
    {
        if (suppliercode.Length > DELIVERYSUPPLIERCODEMAXLEANGHT)
        {
            return 1;
        }
        if (name.Length > DELIVERYNAMEMAXLEANGHT)
        {
            return 2;
        }
        if (legalddress.Length > DELIVERYLEGALDDRESS)
        {
            return 3;
        }
        
        Field completesuppliercode = new Field(DELIVERYSUPPLIERCODEMAXLEANGHT, suppliercode);
        Field completename = new Field(DELIVERYNAMEMAXLEANGHT, name);
        Field completelegalddress = new Field(DELIVERYLEGALDDRESS, legalddress);
        string res = completesuppliercode.completeField() + completename.completeField() + completelegalddress.completeField();

        streamDelivery.WriteLine(res);
        streamDelivery.Flush();


        return 0;

    }
    public int NewdataWorker(string name, string age, string phonenumber, string salary)
    {
        if (name.Length > WORKERNAMEMAXLEANGHT)
        {
            return 1;
        }
        if (age.Length > WORKERAGEMAXLEANGHT)
        {
            return 2;
        }
        if (phonenumber.Length > WORKERPHONENUMBERMAXLEANGHT)
        {
            return 3;
        }
        if (salary.Length > WORKERSALARYMAXLEANGHT)
        {
            return 4;
        }
        Field completename = new Field(WORKERNAMEMAXLEANGHT, name);
        Field completeage = new Field(WORKERAGEMAXLEANGHT, age);
        Field completephonenumber = new Field(WORKERPHONENUMBERMAXLEANGHT, phonenumber);
        Field completesalary = new Field(WORKERSALARYMAXLEANGHT, salary);
        string res = completename.completeField() + completeage.completeField() + completephonenumber.completeField() + completesalary.completeField();

        streamWorker.WriteLine(res);
        streamWorker.Flush();

        return 0;
    }
  public int ShowDataProduct()
   {
     //tiek izmantots fails preetytable lai izveidotos skaista tabula kura atrastos dati.
    PrettyTable table = new PrettyTable(PRODUCTMAXLENS,PRODUCTNAMEOFFIELDS);
    //tabulas sākums
    table.start();
    
    //sāk no nulles
    streamReadProduct.BaseStream.Seek(0,SeekOrigin.Begin);
    //cikls lai nolasītu mainigo contents.
     while (!streamReadProduct.EndOfStream)
     {
       string contents = streamReadProduct.ReadLine();
    table.line(contents);
    
  }
  // tabulas beigas
  table.end();
    
    return 0;
    
  }
    public int SearchDataProduct(String idsearch)
{
  // tiek iesaistīta tabula.
  PrettyTable table = new PrettyTable(PRODUCTMAXLENS, PRODUCTNAMEOFFIELDS);
  //tabulas sākums
  table.start();
  //sāk no nulles(no sākuma)
  streamReadProduct.BaseStream.Seek(0, SeekOrigin.Begin);

  while (!streamReadProduct.EndOfStream)
  {
    // tiek id ir tukšs
    string id = "";
    //tiks nolasīts
    string contents = streamReadProduct.ReadLine();
    
    // domāts lai tiktu salīdzināts ievadīto simbolu skaits ar max garumu un lai tas ietu līdz "~" 
    // tik līdz notiek saskaršanās ar "~" tad tālak nekas netiek nolasīts, lai tabula būtu bez simboliem.
    for (int i = 0; i < PRODUCTIDMAXLEANGHT && contents[i] != '~'; i++)
    {
      id += contents[i];
      
    }
    // tiek salidzināts esošais id(faila) ar pieprasīto
    if (id == idsearch)
    {
      table.line(contents);
      table.end();
      return 0;
    }
    
  }
  table.end();
  return 1; 
  
}

  
  private void reopen(ref StreamWriter stream,ref StreamReader stream_read,string filename)
  {
    stream = new StreamWriter(filename,append:true);
    stream_read = new StreamReader(filename);
  }

private void DeleteData(String file_name,int ind,ref StreamReader stream_read)
{
  //sāk no sākuma
  stream_read.BaseStream.Seek(0, SeekOrigin.Begin);
  //fails kurā tiek pārvietoti visi izdzēstie dati.
  //faia nosaukums
  string tempFilePath = "tmp";  
    
    using (StreamWriter wrt = new StreamWriter(tempFilePath))
    {
      // principā izlasa līdz beigām
      for(int i=0;!stream_read.EndOfStream;i++)
      {
        string data = stream_read.ReadLine();
        if (i!=ind){wrt.WriteLine(data);}
      }
      wrt.Close();
    }
    //faila izušana un parvietošana.
    File.Delete(file_name);
    File.Move(tempFilePath, file_name);
  
}
  
  
  public int DeleteDataProduct(String idsearch)
{
  int numline=-1;
  //sāk no sākuma
  streamReadProduct.BaseStream.Seek(0, SeekOrigin.Begin);
  int j=0;
  while (!streamReadProduct.EndOfStream)
  {
    string id = "";
    string contents = streamReadProduct.ReadLine();
    
    
    for (int i = 0; i < PRODUCTIDMAXLEANGHT && contents[i] != '~'; i++)
    {
      //ja prasības ir sasniegtas tiek 
      id += contents[i];
    }
      //salīdzina faila id ar pieprasīto
      if (id == idsearch)
      {
        numline = j;
      }
    j++;
  }
  if (numline==-1){return 1;}
  DeleteData(PRODUCTFILENAME,numline,ref streamReadProduct);
  reopen(ref streamProduct,ref streamReadProduct,PRODUCTFILENAME);
  return 0; 
  
}
  
  
    
  
  
  
  
  public int ShowDataDelivery()
   {
     
    PrettyTable table = new PrettyTable(DELIVERYMAXLENS,DELIVERYNAMEOFFIELDS);
    table.start();
    
  
    streamReadDelivery.BaseStream.Seek(0,SeekOrigin.Begin);
  
     while (!streamReadDelivery.EndOfStream)
     {
       string contents = streamReadDelivery.ReadLine();
    table.line(contents);
    
  }

  table.end();
    
    

     
     
    return 0;
    
    
  }
   public int SearchDataDelivery(String suppliercodesearch)
{
  PrettyTable table = new PrettyTable(DELIVERYMAXLENS, DELIVERYNAMEOFFIELDS);
  table.start();

  streamReadDelivery.BaseStream.Seek(0, SeekOrigin.Begin);

  while (!streamReadDelivery.EndOfStream)
  {
    string suppliercode = "";
    string contents = streamReadDelivery.ReadLine();
    
    
    for (int i = 0; i < DELIVERYSUPPLIERCODEMAXLEANGHT && contents[i] != '~'; i++)
    {
      suppliercode += contents[i];
      
    }
      
    if (suppliercode == suppliercodesearch)
    {
      table.line(contents);
      table.end();
      return 0;
    }
    
  }
  table.end();
  return 1; 
  
}
  public int DeleteDataDelivery(String idsearch)
{
  int numline=-1;
  streamReadDelivery.BaseStream.Seek(0, SeekOrigin.Begin);
  int j=0;
  while (!streamReadDelivery.EndOfStream)
  {
    string id = "";
    string contents = streamReadDelivery.ReadLine();
    
    
    for (int i = 0; i < DELIVERYSUPPLIERCODEMAXLEANGHT && contents[i] != '~'; i++)
    {
      id += contents[i];
    }
      
      if (id == idsearch)
      {
        numline = j;
      }
    j++;
  }
  if (numline==-1){return 1;}
  DeleteData(DELIVERYFILENAME,numline,ref streamReadDelivery);
  reopen(ref streamDelivery,ref streamReadDelivery,PRODUCTFILENAME);
  return 0;  
  
}
  
  public int ShowDataWorker()
   {
     
    PrettyTable table = new PrettyTable(WORKERMAXLENS,WORKERNAMEOFFIELDS);
    table.start();
    
  
    streamReadWorker.BaseStream.Seek(0,SeekOrigin.Begin);
  
     while (!streamReadWorker.EndOfStream)
     {
       string contents = streamReadWorker.ReadLine();
      table.line(contents);
    
  }
  
  table.end();
    
    

     
     
    return 0;
    
  }


  private void NewFileSort(String path_to_file,List<string> list_of_lines)
  {
    string tempFilePath = "tmp";
    //Console.WriteLine(list_of_lines.Count);
    using (StreamWriter wrt = new StreamWriter(tempFilePath))
    {
      for(int i=0;i<list_of_lines.Count;i++)
      {
        wrt.WriteLine(list_of_lines[i]);

      }
      wrt.Close();
    }

    File.Delete(path_to_file);
    File.Move(tempFilePath, path_to_file);


    
  }
  // Šī metode sakārto veselu skaitļu ID sarakstu un atbilstošās rindas, pamatojoties uz doto nosacījumu
  private bool СonditionIdSort(bool cnd,int idi,int idi1)
  {
    if (cnd){return idi>idi1;}else{return !(idi>idi1);}
  }
  // Atkārto ID sarakstu, salīdzinot blakus esošos pārus un vajadzības gadījumā apmainot tos
  private void IdSort(List<int> list_of_id, List<string> list_of_lines, bool cnd,String file_name)
  {
    for(int j=0;j<list_of_id.Count;j++)
    {
      for (int i=0;i<list_of_id.Count-j-1;i++)
      {
        if (СonditionIdSort(cnd,list_of_id[i],list_of_id[i+1]))
        {
          // Apmaina ID un atbilstošās rindas, ja nosacījums ir patiess
          int tmp_id = list_of_id[i+1];
          string tmp_line = list_of_lines[i+1];
          list_of_id[i+1] = list_of_id[i];
          list_of_id[i] = tmp_id;
          
          list_of_lines[i+1] = list_of_lines[i];
          list_of_lines[i] = tmp_line;
        }
        
      }
    }
    // Izsauciet metodi ar nosaukumu "NewFileSort", lai ierakstītu sakārtotās rindas jaunā failā ar doto nosaukumu
    NewFileSort(file_name,list_of_lines);
  }
  
  
  public int DataSortingProduct(bool cnd)
  {
    // sāk no sākuma
    streamReadProduct.BaseStream.Seek(0, SeekOrigin.Begin);
    // izmantojot laukus izveidojam jaunu list int
    List<int> list_of_id = new List<int>();
    // izmantojot laukus izveidojam jaunu list sting
    List<string> list_of_lines = new List<string>();
    // izlasa līdz beigām
    while (!streamReadProduct.EndOfStream)
    {
      // mainigais līnija tiek nolasīta 
      string line = streamReadProduct.ReadLine();
      // id ir tukšums
      string id="";
      int start1 =0;
      // starts otrais mums ir produkta id garums
      int start2 =PRODUCTIDMAXLEANGHT;
      // domāts lai kods lasītos no 0 līdz simbolam '~'
      for(int i=start1;i<start2 && line[i]!='~';i++)
      {
        id+=line[i];
      }

      
      try{ list_of_id.Add( Convert.ToInt32(id));}
      catch (FormatException ex){return 1;}
      list_of_lines.Add(line);
      
   }
    IdSort(list_of_id,list_of_lines,cnd,PRODUCTFILENAME);
    reopen(ref streamProduct,ref streamReadProduct,PRODUCTFILENAME);
    return 0;
  }


  public int DataSortingWorker(bool cnd)
  {
    streamReadWorker.BaseStream.Seek(0, SeekOrigin.Begin);
    List<string> list_of_names = new List<string>();
    List<string> list_of_lines = new List<string>();
    while (!streamReadWorker.EndOfStream)
    {
      string line = streamReadWorker.ReadLine();
      string name="";
      int start1 =0;
      int start2 =WORKERNAMEMAXLEANGHT;
      for(int i=start1;i<start2 && line[i]!='~';i++)
      {        
        //Console.WriteLine(i);
        name+=line[i];

      }

      
      list_of_names.Add(name);
      list_of_lines.Add(line);
      
   }
    StringSort(list_of_names,list_of_lines,cnd,WORKERFILENAME);
    reopen(ref streamWorker,ref streamReadWorker,WORKERFILENAME);
    return 0;
  }


    private bool СonditionSortString(bool cnd,string str1,string str2)
  {
    int res = String.Compare(str1,str2);
    if (cnd){return res>0;}else{return !(res>0);}
  }
  private void StringSort(List<string> list_of_id, List<string> list_of_lines, bool cnd,string file_name)
  {
    for(int j=0;j<list_of_id.Count;j++)
    {
      for (int i=0;i<list_of_id.Count-j-1;i++)
      {
        if (СonditionSortString(cnd,list_of_id[i],list_of_id[i+1]))
        {
          string tmp_id = list_of_id[i+1];
          string tmp_line = list_of_lines[i+1];
          list_of_id[i+1] = list_of_id[i];
          list_of_id[i] = tmp_id;
          
          list_of_lines[i+1] = list_of_lines[i];
          list_of_lines[i] = tmp_line;
        }
        
      }
    }
    NewFileSort(file_name,list_of_lines);
  }
  
  
  public int DataSortingDelivery(bool cnd)
  {
    streamReadDelivery.BaseStream.Seek(0, SeekOrigin.Begin);
    List<int> list_of_splid = new List<int>();
    List<string> list_of_lines = new List<string>();
    while (!streamReadDelivery.EndOfStream)
    {
      string line = streamReadDelivery.ReadLine();
      string suplcode="";
      int start1 =3;
      int start2 =DELIVERYSUPPLIERCODEMAXLEANGHT;
      for(int i=start1;i<start2 && line[i]!='~';i++)
      {        
        //Console.WriteLine(i);
        suplcode+=line[i];

      }

      
      try{ list_of_splid.Add( Convert.ToInt32(suplcode));}
      catch (FormatException ex){return 1;}
      list_of_lines.Add(line);
      
   }
    IdSort(list_of_splid,list_of_lines,cnd,DELIVERYFILENAME);
    reopen(ref streamDelivery,ref streamReadDelivery,DELIVERYFILENAME);
    return 0;
  }



  
  
  public int SearchDataWorker(String namesearch)
{
  PrettyTable table = new PrettyTable(WORKERMAXLENS, WORKERNAMEOFFIELDS);
  table.start();

  streamReadWorker.BaseStream.Seek(0, SeekOrigin.Begin);

  while (!streamReadWorker.EndOfStream)
  {
    string name = "";
    string contents = streamReadWorker.ReadLine();
    
    
    for (int i = 0; i < WORKERNAMEMAXLEANGHT && contents[i] != '~'; i++)
    {
      name += contents[i];
      
    }
      
    if (name == namesearch)
    {
      table.line(contents);
      table.end();
      return 0;
    }
    
  }
  table.end();
  return 1; 
  
}
  public int DeleteDataWorker(String idsearch)
{
int numline=-1;
  streamReadWorker.BaseStream.Seek(0, SeekOrigin.Begin);
  int j=0;
  while (!streamReadWorker.EndOfStream)
  {
    string name = "";
    string contents = streamReadWorker.ReadLine();
    
    
    for (int i = 0; i < WORKERNAMEMAXLEANGHT && contents[i] != '~'; i++)
    {
      name += contents[i];
    }
      
      if (name == idsearch)
      {
        numline = j;
      }
    j++;
  }
  if (numline==-1){return 1;}
  DeleteData(WORKERFILENAME,numline,ref streamReadWorker);
  reopen(ref streamWorker,ref streamReadWorker,WORKERFILENAME);
  return 0; 
    }
    
  
  // Šī metode izmanto divus virkņu masīvus kā ievadi: argunent_arr un name_fields.
  // Tā pārbauda, vai katrs elements argunent_arr eksistē name_fields.
  // Ja laukā name_fields kāds elements argunent_arr nepastāv, metode atgriež false.
  // Ja visi elementi argunent_arr eksistē laukā name_fields, metode atgriež true.
  private bool ArgumentChecker(string[] argunent_arr, string[] name_fields)
  {
        // Pāriet cauri katram elementam argunent_arr.
        foreach (string element in argunent_arr)
        {   // Ja pašreizējais elements neeksistē laukā name_fields, atgriež false.
            if (!Array.Exists(name_fields, e => e.Equals(element)))
            {
                return false;
            }
        }
        // Ja visi elementi argunent_arr eksistē name_fields, atgriež true.
        return true;
    
  }
  // Šī metode izmanto divus virkņu masīvus kā ievadi: argunent_arr un name_fields.
  // Tas atgriež veselu skaitļu sarakstu, kas attēlo elementu indeksus laukos name_fields, kas pastāv argunent_arr.
  private List<int> FindIndexes(string[] argunent_arr, string[] name_fields)
  {     // Inicializē tukšu sarakstu, lai saglabātu atbilstošo elementu indeksus.
        List<int> indexes = new List<int>();

        for (int i = 0; i < name_fields.Length; i++)
        {
            if (Array.IndexOf(argunent_arr, name_fields[i]) > -1)
            {
                indexes.Add(i);
            }
        }

        return indexes;
  }
    // Šī metode izmanto indeksu sarakstu un Būla masīvu kā ievadi.
    // Tas atgriež patiesu, ja vismaz viens no indeksiem atbilst patiesajai vērtībai masīvā, pretējā gadījumā atgriež false.
  private bool checker_filter_or (List<int> ind_arg, bool[] con)
    {
      // Inicializē karogu uz false.
      bool flag = false;
      // Pārlūko katru indeksu sarakstā.
        foreach (int index in ind_arg)
        {
          // Ja pašreizējā indeksa Būla vērtība ir patiesa, iestadu karogu uz True.
           if (con[index]==true){flag = true;}
                
        }
      // Atgriež karoga galīgo vērtību.
    return flag;
    }
    // Šī metode izmanto indeksu sarakstu un Būla masīvu kā ievadi.
    // Tas atgriež patiesu, ja visi indeksi atbilst patiesajām vērtībām masīvā, pretējā gadījumā atgriež false.
  private bool checker_filter_and (List<int> ind_arg, bool[] con)
    {
      // Inicializējiet karogu uz patiesu.
      bool flag = true;
        // Pārlūko katru indeksu sarakstā.
        foreach (int index in ind_arg)
        {
          // Ja pašreizējā indeksa Būla vērtība ir nepatiesa, iestadu karogu uz false un izeju no cilpas.
           if (con[index]==false){flag = false;}
                
        }
    return flag;
    }
  
  public int DataFilterProduct(string uid, string[] argument_arr,string oper_mode)
  {
    // Inicializēju dažus mainīgos
    int flag_found_data = 0;
    int statusCode = 1;
    // Pārbaudu, vai norādītie lauku nosaukumi ir derīgi
    if (ArgumentChecker(argument_arr,PRODUCTNAMEOFFIELDS)==false){return 2;}
    // Nosaku darbības režīmu (UN vai VAI)
    int mod =-1;
    if (oper_mode == "and"){mod =1;}
    else if (oper_mode == "or"){mod =0;}
    else {return 3;}
    // Iegūstu filtrējamo lauku indeksus
    List<int> ind_arg = FindIndexes(argument_arr,PRODUCTNAMEOFFIELDS);
    // Atiestatu straumi uz faila sākumu
    streamReadProduct.BaseStream.Seek(0,SeekOrigin.Begin);
    // Izveidoju jaunu tabulu, lai parādītu filtrētos datus
    PrettyTable table = new PrettyTable(PRODUCTMAXLENS,PRODUCTNAMEOFFIELDS);
    // Pārlūkoju katru faila rindiņu līdz beigām.
    while (!streamReadProduct.EndOfStream)
    {
      //// nolasa rindiņu un parsē datus
      string line = streamReadProduct.ReadLine();
      string id="";
      string name ="";
      string measure="";
      string price="";
      string amount="";
      string suppliercode ="";
      int start1 =0;
      int start2 =PRODUCTIDMAXLEANGHT;
      int start3 =start2+PRODUCTNAMEMAXLEANGHT;
      int start4 =start3+PRODUCTMEASUREMAXLEANGHT;
      int start5 =start4+PRODUCTPRICEMAXLEANGHT;
      int start6 = start5+PRODUCTAMOUNTMAXLEANGHT;
      int end = start6 + PRODUCTSUPPLIERCODEMAXLEANGHT;
      // Izvelk datus no rindas
      for(int i=start1;i<start2 && line[i]!='~';i++)
      {
        id+=line[i];
      }
      for(int i=start2;i<start3 && line[i]!='~';i++)
      {
        name+=line[i];
      }
      for(int i=start3;i<start4 && line[i]!='~';i++)
      {
        measure+=line[i];
      }
      for(int i=start4;i<start5 && line[i]!='~';i++)
      {
        price+=line[i];
      }
      for(int i=start5;i<start6 && line[i]!='~';i++)
      {
        amount+=line[i];
      }
      for(int i=start6;i<end && line[i]!='~';i++)
      {
        suppliercode+=line[i];
      }
      //Console.WriteLine(id+" "+name+" "+measure+" "+price+" "+amount+" "+suppliercode);

      bool[] con = {id.Contains(uid),name.Contains(uid),measure.Contains(uid),price.Contains(uid),amount.Contains(uid),suppliercode.Contains(uid)};
      // Pārbauda, vai meklēšanas režīms ir "vai" un vai vismaz viens no meklēšanas laukiem atbilst meklēšanas atslēgvārdam
      if (mod==0 && checker_filter_or(ind_arg,con) )
      {
        //Console.WriteLine(line);
        // Iestadu karogu, lai norādītu, ka ir atrasta vismaz viena atbilstoša datu rindiņa
        if (flag_found_data==0){flag_found_data =1;}
        // Iestadu statusa kodu, lai norādītu uz panākumiem
        statusCode = 0;
        // Ja šī ir pirmā atbilstošā datu rinda, sāku izvades tabulu
        if (flag_found_data==1){table.start();flag_found_data = 2;}
        table.line(line);
      }else if (mod==1 && checker_filter_and(ind_arg,con))
      {
        if (flag_found_data==0){flag_found_data =1;}
        statusCode = 0;
        if (flag_found_data==1){table.start();flag_found_data = 2;}
        // Pievieno pašreizējo datu rindu izvades tabulai
        table.line(line);
      }

    }
    if (flag_found_data==2){table.end();}
    return statusCode;
    
  }




    public int DataFilterDelivery(string uid, string[] argument_arr,string oper_mode)
  {
    
    int flag_found_data = 0;
    int statusCode = 1;
    if (ArgumentChecker(argument_arr,DELIVERYNAMEOFFIELDS)==false){return 2;}
    int mod =-1;
    if (oper_mode == "and"){mod =1;}
    else if (oper_mode == "or"){mod =0;}
    else {return 3;}
    List<int> ind_arg = FindIndexes(argument_arr,DELIVERYNAMEOFFIELDS);
    //foreach (int index in ind_arg)
    //    {
    //        Console.WriteLine(index);
    //    }
    streamReadDelivery.BaseStream.Seek(0,SeekOrigin.Begin);
    PrettyTable table = new PrettyTable(DELIVERYMAXLENS,DELIVERYNAMEOFFIELDS);

    while (!streamReadDelivery.EndOfStream)
    {
      string line = streamReadDelivery.ReadLine();
      string suppliercode="";
      string name ="";
      string legaladdress="";
      int start1 =0;
      int start2 =DELIVERYSUPPLIERCODEMAXLEANGHT;
      int start3 =start2+DELIVERYNAMEMAXLEANGHT;
      int end = start3 + DELIVERYLEGALDDRESS;

      
      for(int i=start1;i<start2 && line[i]!='~';i++)
      {
        suppliercode+=line[i];
      }
      for(int i=start2;i<start3 && line[i]!='~';i++)
      {
        name+=line[i];
      }
      for(int i=start3;i<end && line[i]!='~';i++)
      {
        legaladdress+=line[i];
      }



      bool[] con = {suppliercode.Contains(uid),name.Contains(uid),legaladdress.Contains(uid)};
      
      if (mod==0 && checker_filter_or(ind_arg,con) )
      {
        //Console.WriteLine(line);
        if (flag_found_data==0){flag_found_data =1;}
        statusCode = 0;
        if (flag_found_data==1){table.start();flag_found_data = 2;}
        table.line(line);
      }else if (mod==1 && checker_filter_and(ind_arg,con))
      {
        if (flag_found_data==0){flag_found_data =1;}
        statusCode = 0;
        if (flag_found_data==1){table.start();flag_found_data = 2;}
        table.line(line);
      }

    }
    if (flag_found_data==2){table.end();}
    return statusCode;
    
  }


  public int DataFilterWorker(string uid, string[] argument_arr,string oper_mode)  {
    
    int flag_found_data = 0;
    int statusCode = 1;
    if (ArgumentChecker(argument_arr,WORKERNAMEOFFIELDS)==false){return 2;}
    int mod =-1;
    if (oper_mode == "and"){mod =1;}
    else if (oper_mode == "or"){mod =0;}
    else {return 3;}
    List<int> ind_arg = FindIndexes(argument_arr,WORKERNAMEOFFIELDS);
    //foreach (int index in ind_arg)
    //    {
    //        Console.WriteLine(index);
    //    }
    streamReadWorker.BaseStream.Seek(0,SeekOrigin.Begin);
    PrettyTable table = new PrettyTable(WORKERMAXLENS,WORKERNAMEOFFIELDS);

    while (!streamReadWorker.EndOfStream)
    {
      string line = streamReadWorker.ReadLine();
      string name="";
      string age ="";
      string phonenumber="";
      string salary="";
      int start1 =0;
      int start2 =WORKERNAMEMAXLEANGHT;
      int start3 =start2+WORKERAGEMAXLEANGHT;
      int start4 =start3+WORKERPHONENUMBERMAXLEANGHT;
      int end = start4 + WORKERSALARYMAXLEANGHT;

      
      for(int i=start1;i<start2 && line[i]!='~';i++)
      {
        name+=line[i];
      }
      for(int i=start2;i<start3 && line[i]!='~';i++)
      {
        age+=line[i];
      }
      for(int i=start3;i<start4 && line[i]!='~';i++)
      {
        phonenumber+=line[i];
      }
      for(int i=start4;i<end && line[i]!='~';i++)
      {
        salary+=line[i];
      }



      bool[] con = {name.Contains(uid),age.Contains(uid),phonenumber.Contains(uid),salary.Contains(uid)};
      
      if (mod==0 && checker_filter_or(ind_arg,con) )
      {
        //Console.WriteLine(line);
        if (flag_found_data==0){flag_found_data =1;}
        statusCode = 0;
        if (flag_found_data==1){table.start();flag_found_data = 2;}
        table.line(line);
      }else if (mod==1 && checker_filter_and(ind_arg,con))
      {
        if (flag_found_data==0){flag_found_data =1;}
        statusCode = 0;
        if (flag_found_data==1){table.start();flag_found_data = 2;}
        table.line(line);
      }

    }
    if (flag_found_data==2){table.end();}
    return statusCode;
    
  }
  
  
  public void Test(){}

  
  
  public void ProgramClose()
  {

    streamProduct.Close();
    streamDelivery.Close();
    streamWorker.Close();
    streamReadProduct.Close();
    streamReadDelivery.Close();
    streamReadWorker.Close();
  
  }
}