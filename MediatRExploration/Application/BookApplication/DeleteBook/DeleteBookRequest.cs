using MediatR;

namespace MediatRExploration.Application.BookApplication.DeleteBook
{  

    public class DeleteBookRequest : IRequest<bool>
    {
        public string Id { get; set; }
     
    }
}
