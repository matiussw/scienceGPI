﻿using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using scienceGPI.API.Data;
using scienceGPI.shared.Entities;

namespace scienceGPI.API.Controllers
{
    [ApiController]
    [Route("/api/projects")]
    public class ProjectController: ControllerBase
    {

        private readonly DataContext _context;

        public ProjectController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {

            return Ok(await _context.Projects.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var projects = await _context.Projects.FirstOrDefaultAsync(x => x.Id == id);
            if (projects == null)
            {
                return NotFound();
            }
            return Ok(projects);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(Project project)
        {
            try
            {
                _context.Add(project);
                await _context.SaveChangesAsync();
                return Ok(project);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un Projecto con el mismo nombre.");
                }

                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }

        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(Project project)
        {
            try
            {
                _context.Update(project);
                await _context.SaveChangesAsync();
                return Ok(project);
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un Projecto con el mismo nombre.");
                }

                return BadRequest(dbUpdateException.Message);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }

        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var categories = await _context.Projects.FirstOrDefaultAsync(x => x.Id == id);
            if (categories == null)
            {
                return NotFound();
            }

            _context.Remove(categories);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}

