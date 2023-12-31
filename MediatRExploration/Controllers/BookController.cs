﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using MediatRExploration.Application.BookApplication.AddBook;
using MediatRExploration.Application.BookApplication.GetBookById;
using MediatRExploration.Application.Common.Notifications.EmailNotification;

namespace MediatRExploration.Controllers
{
    [ApiController]
    [Route("Api/Books")]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetBook")]
        public async Task<IActionResult> GetBookById(string id)
        {
            var book = await _mediator.Send(new GetBookByIdRequest {BookId = id}); //instance of a book

            if (book == null)
                return NotFound();

            return Ok(book);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateBook(AddBookRequest request)
        {
            var command = await _mediator.Send(request);

            if (command)
            {
                await _mediator.Publish(new EmailNotification("admin@site.com", "A New Book Was Added"));

                return Ok();
            }
            return BadRequest();
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteBook(AddBookRequest request)
        {
            var command = await _mediator.Send(request.Id);

            if ((bool)command)
            {
                await _mediator.Publish(new EmailNotification("admin@site.com", "A Book Was deleted"));

                return Ok();
            }
            return BadRequest();
        }
    }
}
