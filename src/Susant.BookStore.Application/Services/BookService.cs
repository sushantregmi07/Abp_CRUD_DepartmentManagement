using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Susant.BookStore.DTOs;
using Susant.BookStore.Entities;
using Susant.BookStore.Interfaces;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace Susant.BookStore.Services;

public class BookService : ApplicationService, IBookService
{
    private readonly IRepository<Book, long> _bookRepository;
    private readonly IMapper _mapper;

    public BookService(IRepository<Book, long> bookRepository, IMapper mapper)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<BookDto>> GetAllAsync()
    {
        var books = await _bookRepository.GetQueryableAsync();

        var bookDtos = await books.Include(b => b.Shelf).Select(b => new BookDto
        {
            Id = b.Id,
            Name = b.Name,
            Author = b.Author,
            RackName = b.Shelf.RackName
        }).ToListAsync();
        
        return bookDtos;

    }

    public async Task<BookDto> GetByIdAsync(long id)
    {
        var book = await _bookRepository.WithDetails(b => b.Shelf).FirstOrDefaultAsync(b => b.Id == id);

        if (book == null)
        {
            throw new EntityNotFoundException($"Book with ID {id} not found.");
        }

        var bookDto = new BookDto
        {
            Id = book.Id,
            Name = book.Name,
            Author = book.Author,
            RackName = book.Shelf.RackName
        };

        return bookDto;
    }

    public async Task<BookDto> AddAsync(CreateBookDto bookDto)
    {
        var book = _mapper.Map<CreateBookDto, Book>(bookDto);
        var createdBook = await _bookRepository.InsertAsync(book);
        return _mapper.Map<Book, BookDto>(createdBook);
    }

    public async Task UpdateAsync(long id, CreateBookDto bookDto)
    {
        var book = await _bookRepository.GetAsync(id);
        _mapper.Map(bookDto, book);
        await _bookRepository.UpdateAsync(book);
    }

    public async Task DeleteAsync(long id)
    {
        await _bookRepository.DeleteAsync(id);
    }
}