using BrasGreen.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BrasGreen.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentoController : ControllerBase
    {
        private readonly IDocumentoService _documentoService;
        public DocumentoController(IDocumentoService documentoService)
        {
            _documentoService = documentoService;
        }

        [HttpGet]
        [Route(nameof(ValidarRG))]
        public bool ValidarRG(string rg)
        {
            return _documentoService.ValidarRG(rg);
        }

        [HttpGet]
        [Route(nameof(ValidarCPF))]
        public bool ValidarCPF(string cpf)
        {
            return _documentoService.ValidarCPF(cpf);
        }

        [HttpGet]
        [Route(nameof(ValidarCNPJ))]
        public bool ValidarCNPJ(string cnpj)
        {
            return _documentoService.ValidarCnpj(cnpj);
        }
    }
}
