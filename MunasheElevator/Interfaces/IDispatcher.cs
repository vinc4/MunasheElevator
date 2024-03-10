﻿using MunasheElevator.Elevator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunasheElevator.Interfaces
{
    public interface IDispatcher
    {
        List<IElevator> Elevators { get; set; }
        Queue<Request> UnprocessedCallRequests { get; set; }

        void AddElevator(IElevator elevator);
        void AddUnprocessedCallRequest(Request request);
        Task ProcessRequests();
    }
}
