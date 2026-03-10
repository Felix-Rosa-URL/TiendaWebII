using Microsoft.AspNetCore.Mvc;
using TiendaWeb.Models;

namespace TiendaWeb.Controllers;

public class ProductoController : Controller
{
    private static List<Producto> _bd = new()
    {
        new Producto { Id=1, Nombre="Teclado", Precio=2500, Stock=10, CodigoSku="TEC-0001", Descripcion="Teclado mecánico" },
        new Producto { Id=2, Nombre="Monitor", Precio=15000, Stock=5, CodigoSku="MON-0002", Descripcion="Monitor 27 pulgadas" }
    };

    private static int _nextId = 3;

    public IActionResult Index()
    {
        return View(_bd);
    }

    public IActionResult Detalle(int id)
    {
        var producto = _bd.FirstOrDefault(p => p.Id == id);

        if (producto == null)
            return NotFound();

        return View(producto);
    }

    public IActionResult Crear()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Crear(Producto modelo)
    {
        if (!ModelState.IsValid)
            return View(modelo);

        modelo.Id = _nextId++;
        _bd.Add(modelo);

        TempData["Exito"] = "Producto creado";

        return RedirectToAction("Index");
    }
}