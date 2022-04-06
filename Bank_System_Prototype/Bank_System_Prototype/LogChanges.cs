
using System;

namespace Bank_System_Prototype
{
    class LogChanges
    {
        public WorkerType workerType { get; set; }
        public DataType dataType { get; set; }
        public TypeOfChanges typeOfChanges { get; set; }

        public DateTime changesDateTime;

        public LogChanges(DataType dataType, WorkerType workerType, TypeOfChanges typeOfChanges)
        {
            this.dataType = dataType;
            this.workerType = workerType;
            this.typeOfChanges = typeOfChanges;
            changesDateTime = DateTime.UtcNow;

            Console.WriteLine($"Changes: {changesDateTime}, {typeOfChanges}, {dataType}, {workerType}");
        }
    }
}
