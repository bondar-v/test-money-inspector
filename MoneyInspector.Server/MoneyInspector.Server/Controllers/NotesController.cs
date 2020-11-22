using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoneyInspector.Server.Models;
using MoneyInspector.Server.Services.Interfaces;

namespace MoneyInspector.Server.Controllers
{
    [Route("api/notes")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INotesService notesService;
        private DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        public NotesController(INotesService notesService)
        {
            this.notesService = notesService;
        }

        [HttpPost("add")]
        public IActionResult AddNote([FromBody]NewNoteModel note)
        {
            notesService.AddNote(note);

            return Ok();
        }

        [HttpDelete("remove")]
        public IActionResult RemoveNote(int id)
        {
            notesService.RemoveNote(id);

            return Ok();
        }

        [HttpPut("update")]
        public IActionResult UpdateNote([FromBody]UpdateNoteModel note)
        {
            notesService.UpdateNote(note);

            return Ok();
        }

        [HttpGet("getByPeriod")]
        public IActionResult GetNotes(long startDateMs, long endDateMs)
        {
            return Ok();
        }

        [HttpGet("getAll")]
        public IActionResult GetAllNotes()
        {
            return Ok(notesService.GetAllNotes());
        }
    }
}
