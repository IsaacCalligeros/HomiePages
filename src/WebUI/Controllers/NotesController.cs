using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HomiePages.Application.ServiceInterfaces;
using HomiePages.Domain.Entities;
using HomiePages.WebUI.Models.APIModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using HomiePages.Infrastructure.Services.EntityServices;

namespace HomiePages.WebUI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class NotesController : ApiControllerBase
    {
        private readonly INotesService _notesService;
        public NotesController(
            INotesService notesService
            )
        {
            _notesService = notesService;
        }

        [HttpPut]
        [Route("FindOrCreate/{containerId}")]
        public Notes FindOrCreate(long containerId)
        {
            var notes = _notesService.FindOrCreate(containerId);
            return notes;
        }

        [HttpDelete]
        [Route("Delete/{containerId}")]
        public bool Delete(long containerId)
        {
            return _notesService.DeleteNote(containerId);
        }
    }
}