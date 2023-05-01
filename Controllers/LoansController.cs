﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HamroCarRental.Data;
using HamroCarRental.Models.ViewModels;
using HamroCarRental.Models;
using Microsoft.AspNetCore.Authorization;

namespace HamroCarRental.Controllers;

public class LoansController : Controller
{
    //getting the database context to the controller
    private readonly ApplicationDbContext _context;

    //defining the constructor
    public LoansController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var allLoans = await _context.Loans.Include(n => n.Member).ToListAsync();
        return View(allLoans);
    }

}