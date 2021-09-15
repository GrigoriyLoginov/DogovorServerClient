using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace DogService
{
    [ServiceContract]
    public interface IDogService
    {
        [OperationContract]
        void CheckActualDate(DateTime ActualDate);
        [OperationContract]
        void UpdateDog(Dogovor dog);
        [OperationContract]
        List<Dogovor> FillDataTable();
    }
}
