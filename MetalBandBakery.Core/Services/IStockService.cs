﻿using System.Collections.Generic;

namespace MetalBandBakery.Core.Services {
    public interface IStockService {
        bool CheckStock(string itemId);
        void IncreaseStock(string itemId, int ammount);
        void ReduceStock(string itemId);
        Dictionary<string, int> GetItemDictionary();
    }
}