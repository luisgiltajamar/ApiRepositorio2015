﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Repositorio.Model;
using Repositorio.Repositorio;
using Repositorio.ViewModel;

namespace ApiRepositorio.Controllers
{
    public class AlumnosController : ApiController
    {
        private cursosEntities context;
        private IRepositorio<Alumno, ViewModelAlumno> repo;

        public AlumnosController()
        {
            repo=new RepositorioEntity<Alumno, ViewModelAlumno>(context);
        }

        public ICollection<ViewModelAlumno> Get()
        {
            return repo.Get();

        } 

        [ResponseType(typeof(ViewModelAlumno))]
        public IHttpActionResult Get(String id)
        {
            var data = repo.Get(id);
            if (data == null)
                return NotFound();

            return Ok(data);
        }

    }
}
