using Data.Common;
using Data.Model;
using Data.Repository.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Data.DataAccess.Queries
{
    public class GetUserByUserNameQuery :IRequest<RequestResult<User>>
    {
        public string UserName { get; set; }

        public class Handler : IRequestHandler<GetUserByUserNameQuery, RequestResult<User>>
        {
            private readonly IUserRepository _userRepository; 
            
            public Handler(IUserRepository userRepository)
            {
                _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            }

            public async Task<RequestResult<User>> Handle(GetUserByUserNameQuery request, CancellationToken cancellationToken)
            {
                if (request == null || request.UserName == null || request.UserName.Length <= 0)
                {
                    throw new ArgumentNullException(nameof(request));
                }

                var result = await _userRepository.GetUserByUserNameAsync(request.UserName).ConfigureAwait(false);

                return RequestResult.Success(result);
            }
        }
    }
}
