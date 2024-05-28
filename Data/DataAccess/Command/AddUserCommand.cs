using Data.Common;
using Data.Model;
using Data.Repository.Interface;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Data.DataAccess.Command
{
    public class AddUserCommand : IRequest<RequestResult<Unit>>
    {
        public User user { get; set; }

        public class Handler : IRequestHandler<AddUserCommand, RequestResult<Unit>>
        {
            private readonly IUserRepository _userRepository;

            public Handler(IUserRepository userRepository)
            {
                _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            }
            public async Task<RequestResult<Unit>> Handle(AddUserCommand request, CancellationToken cancellationToken)
            {
                if (request == null || request.user == null)
                {
                    throw new ArgumentNullException(nameof(request));
                }

                await _userRepository.AddUserAsync(request.user).ConfigureAwait(false);

                return RequestResult.Success(Unit.Value);
            }
        }
    }
}
