using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Avaliacao_Tecnica.Application.EventSourcedNormalizers;
using Avaliacao_Tecnica.Application.Interfaces;
using Avaliacao_Tecnica.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetDevPack.Identity.Authorization;

namespace Avaliacao_Tecnica.Services.Api.Controllers
{
    //[Authorize]
    public class ClientController : ApiController
    {
        private readonly IClientAppService _clientAppService;

        public ClientController(IClientAppService clientAppService)
        {
            _clientAppService = clientAppService;
        }

        [AllowAnonymous]
        [HttpGet("client-management")]
        public async Task<IEnumerable<ClientViewModel>> Get()
        {
            return await _clientAppService.GetAll();
        }

        [AllowAnonymous]
        [HttpGet("client-management/{id}")]
        public async Task<ClientViewModel> Get(string id)
        {
            return await _clientAppService.GetById(Guid.Parse(id.ToString()));
        }

        //[CustomAuthorize("Clients", "Write")]
        [AllowAnonymous]
        [HttpPost("client-management")]
        public async Task<IActionResult> Post([FromBody] ClientViewModel clientViewModel)
        {
            if (clientViewModel.Id.HasValue == false)
            {
                clientViewModel.Id = Guid.NewGuid();
            }

            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _clientAppService.Register(clientViewModel));
        }

        //[CustomAuthorize("Clients", "Write")]
        [AllowAnonymous]
        [HttpPut("client-management")]
        public async Task<IActionResult> Put([FromBody] ClientViewModel clientViewModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _clientAppService.Update(clientViewModel));
        }

        //[CustomAuthorize("Clients", "Remove")]
        [AllowAnonymous]
        [HttpDelete("client-management/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return CustomResponse(await _clientAppService.Remove(id));
        }
    }
}
