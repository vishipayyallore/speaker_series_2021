import { IAddress } from './iaddress';

export interface IEmployee {

  id: string;
  
  fullName: string;

  pictureUrl: string;

  department: string;

  age: number;

  address: IAddress;

  rating?: number;
}
