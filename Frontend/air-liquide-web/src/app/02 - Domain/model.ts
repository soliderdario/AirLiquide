import { OperationType } from './types';

class CustomerModel {
  constructor(
    public Id: string = null,
    public Name: string = null,
    public Age: number = null,
    public Operation: OperationType = OperationType.Insert
  ) {}
}

export {
  CustomerModel
};
