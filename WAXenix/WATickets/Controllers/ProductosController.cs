﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using WATickets.Models;
using WATickets.Models.Cliente;

namespace WATickets.Controllers
{
    [Authorize]
    public class ProductosController : ApiController
    {
        ModelCliente db = new ModelCliente();

    
        public HttpResponseMessage GetAll([FromUri] Filtros filtro) 
        {
            try
            {
                var Productos = db.Productos.ToList(); //Traemos el listado de productos

                if(!string.IsNullOrEmpty(filtro.CardCode))
                {
                    var Bodegas = db.Bodegas.Where(a => a.CodSuc != filtro.CardCode).ToList();
                    foreach(var item in Bodegas)
                    {
                        Productos = Productos.Where(a => a.idBodega != item.id).ToList();

                    }
                }
                if(filtro.Codigo1 > 0) // esto por ser integer
                {
                    Productos = Productos.Where(a => a.idBodega == filtro.Codigo1).ToList(); // filtramos por lo que traiga el codigo1 
                }
                if (filtro.Codigo2 > 0) // esto por ser integer
                {
                    Productos = Productos.Where(a => a.idProveedor == filtro.Codigo2).ToList(); 
                }



                return Request.CreateResponse(System.Net.HttpStatusCode.OK, Productos);
            }
            catch (Exception ex)
            {
                BitacoraErrores be = new BitacoraErrores();
                be.Descripcion = ex.Message;
                be.StrackTrace = ex.StackTrace;
                be.Fecha = DateTime.Now;
                be.JSON = JsonConvert.SerializeObject(ex);
                db.BitacoraErrores.Add(be);
                db.SaveChanges();

                return Request.CreateResponse(System.Net.HttpStatusCode.InternalServerError, ex);

            }

        }
        [Route("api/Productos/Consultar")]
        public HttpResponseMessage GetOne([FromUri] int id)
        {
            try
            {
                Productos productos = db.Productos.Where(a => a.id == id).FirstOrDefault();


                return Request.CreateResponse(System.Net.HttpStatusCode.OK, productos);
            }
            catch (Exception ex)
            {
                BitacoraErrores be = new BitacoraErrores();
                be.Descripcion = ex.Message;
                be.StrackTrace = ex.StackTrace;
                be.Fecha = DateTime.Now;
                be.JSON = JsonConvert.SerializeObject(ex);
                db.BitacoraErrores.Add(be);
                db.SaveChanges();

                return Request.CreateResponse(System.Net.HttpStatusCode.InternalServerError, ex);

            }

        }
        [Route("api/Productos/Insertar")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody] Productos productos)
        {
            try
            {
                Productos Producto = db.Productos.Where(a => a.id == productos.id).FirstOrDefault();
                if (Producto == null)
                {
                    Producto = new Productos();
                    Producto.id = productos.id;
                    Producto.Codigo = productos.Codigo;
                    Producto.idBodega = productos.idBodega;
                    Producto.idProveedor = productos.idProveedor;
                    Producto.idCategoria = productos.idCategoria;
                    Producto.Nombre = productos.Nombre;
                    Producto.PrecioUnitario = productos.PrecioUnitario;
                    Producto.Costo = productos.Costo;
                    Producto.Stock = productos.Stock;
                    db.Productos.Add(Producto);
                    db.SaveChanges();

                }
                else
                {
                    throw new Exception("Ya existe un producto con este ID");
                }

                return Request.CreateResponse(System.Net.HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                BitacoraErrores be = new BitacoraErrores();
                be.Descripcion = ex.Message;
                be.StrackTrace = ex.StackTrace;
                be.Fecha = DateTime.Now;
                be.JSON = JsonConvert.SerializeObject(ex);
                db.BitacoraErrores.Add(be);
                db.SaveChanges();

                return Request.CreateResponse(System.Net.HttpStatusCode.InternalServerError, ex);
            }
        }
        [Route("api/Productos/Actualizar")]
        [HttpPut]
        public HttpResponseMessage Put([FromBody] Productos productos)
        {
            try
            {
                Productos Productos = db.Productos.Where(a => a.id == productos.id).FirstOrDefault();
                if (Productos != null)
                {
                    db.Entry(Productos).State = System.Data.Entity.EntityState.Modified;
                    Productos.idBodega = productos.idBodega;
                    Productos.idProveedor = productos.idProveedor;
                    Productos.idCategoria = productos.idCategoria;
                    Productos.Nombre = productos.Nombre;
                    Productos.PrecioUnitario = productos.PrecioUnitario;
                    Productos.Costo = productos.Costo;
                    Productos.Stock = productos.Stock;
                    db.SaveChanges();

                }
                else
                {
                    throw new Exception("No existe un producto" +
                        " con este ID");
                }

                return Request.CreateResponse(System.Net.HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                BitacoraErrores be = new BitacoraErrores();
                be.Descripcion = ex.Message;
                be.StrackTrace = ex.StackTrace;
                be.Fecha = DateTime.Now;
                be.JSON = JsonConvert.SerializeObject(ex);
                db.BitacoraErrores.Add(be);
                db.SaveChanges();

                return Request.CreateResponse(System.Net.HttpStatusCode.InternalServerError, ex);
            }
        }
        [Route("api/Productos/Eliminar")]
        [HttpDelete]
        public HttpResponseMessage Delete([FromUri] int id)
        {
            try
            {
                Productos Productos = db.Productos.Where(a => a.id == id).FirstOrDefault();
                if (Productos != null)
                {
                    db.Productos.Remove(Productos);
                    db.SaveChanges();

                }
                else
                {
                    throw new Exception("No existe un producto con este ID");
                }

                return Request.CreateResponse(System.Net.HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                BitacoraErrores be = new BitacoraErrores();
                be.Descripcion = ex.Message;
                be.StrackTrace = ex.StackTrace;
                be.Fecha = DateTime.Now;
                be.JSON = JsonConvert.SerializeObject(ex);
                db.BitacoraErrores.Add(be);
                db.SaveChanges();

                return Request.CreateResponse(System.Net.HttpStatusCode.InternalServerError, ex);
            }
        }


    }
}