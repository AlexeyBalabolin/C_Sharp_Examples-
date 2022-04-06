namespace Bank_System_Prototype
{
    interface IChangeable
    {
        void ChangeData(DataType dataType, WorkerType workerType, TypeOfChanges typeOfChanges);
    }
}
