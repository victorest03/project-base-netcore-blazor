namespace SistemaVentas.Frontend.Pages
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Components;
    using Services;
    using SistemaVentas.Frontend.Components;
    using System;

    [Authorize]
    public class ProductoBase : ComponentBase
    {
        [Inject]
        protected IProductoService productoService { get; set; }

        public Modal productoModal { get; set; }

        //protected override Task OnAfterRenderAsync(bool firstRender)
        //{
        //    var r = new Producto()
        //    {
        //        cProducto = "Producto3",
        //        fkModelo = 1
        //    };
        //    var t = ait productoService.AddAsync(r);
        //}

        protected override void OnAfterRender(bool firstRender)
        {

            base.OnAfterRender(firstRender);
        }

        public void OnClickOpen()
        {
            productoModal.Open();
        }

        public void OnSaveProductoModal()
        {
            Console.WriteLine("hola");
        }
    }
}
