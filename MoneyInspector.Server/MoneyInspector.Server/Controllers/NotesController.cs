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
        private readonly IDateTimeParser dateTimeParser;

        public NotesController(INotesService notesService, IDateTimeParser dateTimeParser)
        {
            this.notesService = notesService;
            this.dateTimeParser = dateTimeParser;
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
            return Ok(notesService.GetNotesByPeriod(dateTimeParser.GetDateTimePeriod(startDateMs, endDateMs)));
        }

        [HttpGet("getAll")]
        public IActionResult GetAllNotes()
        {
            return Ok(notesService.GetAllNotes());
        }
    }
}
