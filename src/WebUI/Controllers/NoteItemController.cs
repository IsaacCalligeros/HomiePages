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
    public class NoteItemController : ApiControllerBase
    {
        private readonly INoteItemService _noteItemService;
        public NoteItemController(
            INoteItemService noteItemService
            )
        {
            _noteItemService = noteItemService;
        }

        [HttpPut]
        [Route("UpdateNotesOrder/{containerId}")]
        public Notes UpdateNotesOrder([ModelBinder] List<NoteItem> noteItems, long containerId)
        {
            var notes = _noteItemService.UpdateNotesOrder(noteItems, containerId);
            return notes;
        }

        [HttpPost]
        [Route("Add/{containerId}")]
        public NoteItem AddNoteItem([ModelBinder] NoteItem noteItem, long containerId)
        {
            return _noteItemService.AddNoteItem(noteItem, containerId);
        }

        [HttpPost]
        [Route("Update/{containerId}")]
        public NoteItem UpdateNoteItem([ModelBinder] NoteItem noteItem, long containerId)
        {
            return _noteItemService.UpdateNoteItem(noteItem, containerId);
        }

        [HttpDelete]
        [Route("Delete/{containerId}")]
        public bool Delete(long noteItemId)
        {
            return _noteItemService.DeleteNoteItem(noteItemId);
        }
    }
}