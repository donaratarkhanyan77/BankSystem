using Microsoft.AspNetCore.Mvc;

namespace BankSystem.Controllers;

public class TransactionController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
