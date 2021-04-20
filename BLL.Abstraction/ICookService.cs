using System;
using Entities;

namespace BLL.Abstraction
{
    public interface ICookService
    {
        Cook GetReadyCook(DateTime starTimeOrder, int specilizationId);
    }
}