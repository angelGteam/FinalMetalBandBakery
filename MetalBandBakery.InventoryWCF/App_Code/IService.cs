using System;
using System.Collections.Generic;
using System.ServiceModel;

[ServiceContract]
public interface IService {
    [OperationContract]
    int CheckStock(string itemId);

    [OperationContract]
    bool ReduceStock(string itemId, int quantity);
    [OperationContract]
    void IncreaseStock(string itemId, int quantity);

    [OperationContract]
    List<ItemStock> CheckCompleteStock();
}