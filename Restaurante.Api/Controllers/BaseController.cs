using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Domain.Notifications;
using Restaurante.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurante.Api.Controllers
{
    public class BaseController : Controller
    {
        private const string PAGE_INDEX = "pageindex";
        private const string PAGE_SIZE = "pagesize";
        private const string SORT = "sort";

        protected readonly IMediator _mediator;
        protected ValidationResult _validation;
        protected BaseController(IMediator mediator)
        {
            _mediator = mediator;
            _validation = new ValidationResult();
        }

        public int PageIndex
        {
            get
            {
                var pageIndex = 0;

                if (Request.Query.ContainsKey(PAGE_INDEX))
                    int.TryParse(Request.Query[PAGE_INDEX], out pageIndex);

                return pageIndex;
            }
        }

        public int PageSize
        {
            get
            {
                var pageSize = 10;

                if (Request.Query.ContainsKey(PAGE_SIZE))
                    int.TryParse(Request.Query[PAGE_SIZE], out pageSize);

                return pageSize;
            }
        }

        public string Sort
        {
            get
            {
                var sort = string.Empty;

                if (Request.Query.ContainsKey(SORT))
                    sort = Request.Query[SORT];

                return sort;
            }
        }

        protected bool IsValidOperation() => !_validation.Errors.Any();

        protected IActionResult ResponseInvalidModel(object data = null)
        {
            return BadRequest(new ResponseModel
            {
                Success = false,
                Data = data,
                Notifications = _validation.Errors
                    .Select(n => new ResponseModelNotification()
                    {
                        Key = n.ErrorCode,
                        Value = n.ErrorMessage
                    })
            });
        }

        protected new IActionResult Response(object data = null)
        {

            if (data is Notification dataQuery)
            {
                if (dataQuery.ValidationResult.IsValid)
                    return Ok(dataQuery);
                else
                {
                    return UnprocessableEntity(new ResponseModel
                    {
                        Success = false,
                        Data = data,
                        Notifications = dataQuery.ValidationResult.Errors
                            .Select(n => new ResponseModelNotification()
                            {
                                Key = n.ErrorCode,
                                Value = n.ErrorMessage,
                            })
                    });
                }
            }

            if (IsValidOperation())
            {
                if (data.GetType().IsGenericType
                    && data.GetType().GetGenericTypeDefinition() == typeof(QueryResult<>))
                {
                    return Ok(data);
                }

                return Ok(new ResponseModel
                {
                    Success = true,
                    Data = data
                });
            }

            return UnprocessableEntity(new ResponseModel
            {
                Success = false,
                Data = data,
                Notifications = _validation.Errors
                    .Select(n => new ResponseModelNotification()
                    {
                        Key = n.ErrorCode,
                        Value = n.ErrorMessage,
                    })
            });
        }
    }
}
