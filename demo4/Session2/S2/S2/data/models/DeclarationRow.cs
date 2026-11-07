using System;

namespace S2.data.models
{
    /// <summary>
    /// One row of the declaration management list.
    /// </summary>
    public class DeclarationRow
    {
        public string declarationId;
        public string containerNumber;
        public string voyageNumber;
        public string cargoOwner;
        public string hsCode;
        public string originCountry;
        public string tradeMode;
        public decimal cargoAmount;
        public decimal dutyPayable;
        public string status;
        public DateTime declarationTime;
        public DateTime? approvedTime;
        public DateTime? rejectedTime;
        public string rejectReason;
        public int quantity;
        public string unitName;
        public string description;
        public DateTime? changeTime;

    }
}
