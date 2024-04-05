using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using firstsitecsharp.Models;

using Microsoft.Data.SqlClient;



namespace firstsitecsharp.Controllers;

public class HomeController : Controller
{


SqlConnection con=new SqlConnection();

SqlCommand com=new SqlCommand();

SqlDataReader?  dr;


    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();

    }
        [HttpGet]

    public IActionResult Login()
    {
        return View("Login","Home");
    }

    void ConnectionString(){

    con.ConnectionString="data source=192.168.1.240\\SQLEXPRESS; database=cad_ttb; user ID=CADBATCH01; Password=CAD@123pass; TrustServerCertificate=True; ";


    }
    [HttpPost]
    public IActionResult VerifyLogin(LoginModel lmodel){
        ConnectionString();
        con.Open();
        com.Connection=con;
        com.CommandText="select * from ttb_log where usr_name='" + lmodel.usr_name+"' and password='"+ lmodel.password +"' ";  

         dr=com.ExecuteReader();

        if(dr.Read()){
            con.Close();
            return View("Success");
        }else{
            con.Close();
            return View("Error");
        }
            /* if(lmodel.usr_name=="suthakar"){   
            return View("Success","Home");
            }

        else if (lmodel.usr_name=="chandran"){
            return View("Error","Home");
        }   
         } */
    }
        public IActionResult Contactus()
    {
        return View();
    }
    [HttpGet]
     public IActionResult Register ()
    {
        return View();
    }
     void conStr(){

    con.ConnectionString="data source=192.168.1.240\\SQLEXPRESS; database=cad_ttb; user ID=CADBATCH01; Password=CAD@123pass; TrustServerCertificate=True; ";
     }
      [HttpPost]
     public IActionResult RegisterDB(RegisterModel rmodel)

     {   

        {   

         conStr();
         com.Connection=con;
         com.CommandText="INSERT INTO ttb_reg (username, Email, password, new_password)VALUES (@username, @Email, @password, @new_password,);";
         


         if(true){
             return RedirectToAction("Login");
         }
         else{

             return RedirectToAction("Error");
         }
        return View();
        
    }
        return View();
        
    }
    
    
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
