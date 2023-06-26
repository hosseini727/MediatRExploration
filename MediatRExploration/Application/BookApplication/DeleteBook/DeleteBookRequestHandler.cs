using MediatR;
using MediatRExploration.Data.Model;
using MediatRExploration.Data.Repositories.BookRepository;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRExploration.Application.BookApplication.DeleteBook
{
    
    public class DeleteBookRequestHandler : IRequestHandler<DeleteBookRequest, bool>
    {
        private readonly IBookRepository _bookRepository;

        public DeleteBookRequestHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public Task<bool> Handle(DeleteBookRequest request, CancellationToken cancellationToken)
        {
            _bookRepository.DeleteBook(request.Id);
            return Task.FromResult(true);
        }
    }
}
